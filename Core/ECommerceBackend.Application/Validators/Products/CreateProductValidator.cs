using ECommerceBackend.Application.ViewModels.Produccts;
using FluentValidation;

namespace ECommerceBackend.Application.Validators.Products
{
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("name can not be empty")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("lenght mus be between 5 to 150 characters");

            RuleFor(c => c.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("stock can not be empty")
                .Must(s => s >= 0)
                    .WithMessage("stock can not be negative number");

            RuleFor(c => c.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("price can not be empty")
                .Must(s => s >= 0)
                    .WithMessage("price can not be negative number");

        }
    }
}
