using FluentValidation;
using iTextSharp.text.pdf;
using Parking.DAL.Models;

namespace Parking.BLL.Validators;

public class TariffValidator:AbstractValidator<Tariff>
{
    public TariffValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name of tariff must be not empty")
            .MinimumLength(2).WithMessage("Name is too short")
            .MaximumLength(20).WithMessage("Name is too long")
            .Matches(@"^[A-Za-z]*$").WithMessage("Invalid name");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        
    }
}