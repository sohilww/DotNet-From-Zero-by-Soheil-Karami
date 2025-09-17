namespace CAS.Domain.Abstractions.Result;
public record DomainError(string Message, string KeyCode,int StatusCode);