using CilinicAppointmentSystem.Attributes;
using FluentAssertions;

namespace CAS.Interface.WebApi.Tests;

public class NationalityCodeValidationAttributeTests
{
    private NationalityCodeValidationAttribute _validation;

    public NationalityCodeValidationAttributeTests()
    {
        _validation = new NationalityCodeValidationAttribute();
    }

    [Theory]
    [InlineData("8210100106")]
    [InlineData("6542100016")]
    [InlineData("9001111106")]
    [InlineData("1100100008")]
    public void should_be_valid_for_valid_nationality_code(string nationalityCode)
    {
        var isValid = _validation.IsValid(nationalityCode);

        isValid.Should().BeTrue();
    }

    [Fact]
    public void should_be_invalid_when_nationality_code_is_not_a_string()
    {
        var isValid = _validation.IsValid(new object());
        
        isValid.Should().BeFalse();
    }
}