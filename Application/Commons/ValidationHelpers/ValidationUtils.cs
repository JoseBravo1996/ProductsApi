using Domain.Exceptions;
using FluentValidation.Results;

namespace Application.Commons.ValidationHelpers;

public static class ValidationUtils
{
    public static void ValidateAndThrow(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage);
            throw new BadRequestException(string.Join(" ", errors));
        }
    }
}
