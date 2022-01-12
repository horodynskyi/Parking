using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Parking.DAL;
using Parking.DAL.Models;

namespace Parking.BLL.Validators;

public class UserValidator:AbstractValidator<User>
{
    private readonly DataContext _context;
    public UserValidator(DataContext context)
    {
        _context = context;
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name must be not empty")
            .MinimumLength(1).WithMessage("Name is too short")
            .MaximumLength(20).WithMessage("Name is too long")
            .Matches(@"^[A-Za-z]*$").WithMessage("Invalid name");
        RuleFor(x => x.Patronumic)
            .NotEmpty().WithMessage("Name must be not empty")
            .MinimumLength(1).WithMessage("Name is too short")
            .MaximumLength(20).WithMessage("Name is too long")
            .Matches(@"^[A-Za-z]*$").WithMessage("Invalid name");
        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Name must be not empty")
            .MinimumLength(1).WithMessage("Name is too short")
            .MaximumLength(20).WithMessage("Name is too long")
            .Matches(@"^[A-Za-z]*$").WithMessage("Invalid name");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Name must be not empty")
            .Matches(@"^\+380\d{9}$").WithMessage("Invalid phone number")
            .MustAsync(IsExist).WithMessage("This number is exist");
        

    }

    private async Task<bool> IsExist(string phone, CancellationToken token)
    {
        return !await _context.Set<User>().AnyAsync(x => x.PhoneNumber == phone, cancellationToken: token);
    }
}