using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Core.Common;

public abstract class Entity
{
    protected static void Validate<T>(AbstractValidator<T> validator, T data)
    {
        var validationResult = validator.Validate(data);
        ThrowIfNotValid(validationResult);
    }

    protected static async Task ValidateAsync<T>(AbstractValidator<T> validator, T data,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(data, cancellationToken);
        ThrowIfNotValid(validationResult);
    }

    private static void ThrowIfNotValid(ValidationResult validationResult)
    {
        // TODO: Add exception handlers
        if (!validationResult.IsValid) throw new Exception();
    }
}