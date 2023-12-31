using FluentValidation;

namespace ProductHW.Models.FluentValidators;

public class ProductFluentValidator : AbstractValidator<Product>
{
    public ProductFluentValidator()
    {
        RuleFor(p => p.Name)
            .MinimumLength(2).WithMessage("Length must be longer than 2")
            .NotEmpty().WithMessage("Required");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Required")
            .MinimumLength(5).WithMessage("Length must be longer than 5");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}
