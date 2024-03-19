using Core.Domain.Products.Data;
using FluentValidation;

namespace Core.Domain.Products.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductData>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(p => p.Price)
            .GreaterThan(0);
    }
}