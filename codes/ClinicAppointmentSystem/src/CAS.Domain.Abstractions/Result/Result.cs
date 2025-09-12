namespace CAS.Domain.Abstractions.Result;
public readonly struct Result<TValue, TError>
{
    private readonly TValue? _value;
    private readonly TError? _error;
    private readonly bool _isSuccess;

    public TValue? Value => _value;
    public TError? Error => _error;

    public bool IsSuccess => _isSuccess;
    public bool IsError => !_isSuccess;

    private Result(TValue value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        _value = value;
        _error = default;
        _isSuccess = true;
    }

    private Result(TError error)
    {
        ArgumentNullException.ThrowIfNull(error, nameof(error));

        _error = error;
        _value = default;
        _isSuccess = false;
    }

    public static Result<TValue, TError> Ok(TValue value) => new(value);
    public static Result<TValue, TError> Fail(TError error) => new(error);

    public static implicit operator Result<TValue, TError>(TValue value) => Ok(value);
    public static implicit operator Result<TValue, TError>(TError error) => Fail(error);

    public TResult Match<TResult>(Func<TValue, TResult> success, Func<TError, TResult> failure) =>
        _isSuccess ? success(_value!) : failure(_error!);

    public ValueTask<TResult> MatchAsync<TResult>(
        Func<TValue, ValueTask<TResult>> success,
        Func<TError, ValueTask<TResult>> failure) =>
        _isSuccess ? success(_value!) : failure(_error!);

    public void Handle(Action<TValue> success, Action<TError> failure)
    {
        if (_isSuccess) success(_value!);
        else failure(_error!);
    }

    public ValueTask HandleAsync(Func<TValue, ValueTask> success, Func<TError, ValueTask> failure) =>
        _isSuccess ? success(_value!) : failure(_error!);

    public override string ToString() =>
        _isSuccess ? $"Success: {_value}" : $"Error: {_error}";
}