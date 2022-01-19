using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Parking.DAL;
using Parking.DAL.Models;

namespace Parking.BLL.Validators;

public class CarValidator:AbstractValidator<Car>
{
    private readonly DataContext _context;
    public CarValidator(DataContext context)
    {
        _context = context;
        RuleFor(x => x)
            .NotNull().WithMessage("User must be not null")
            .MustAsync(IsExist).WithMessage("User doesn't exist in database");
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than 0");
        
        RuleFor(x => x.CarNumber)
            .NotEmpty().WithMessage("Registration car number must be not null")
            .Matches("^[A-Z]{2}[0-9]{4}[A-Z]{2}$")
            .WithMessage("Car registration number is wrong");
    }
    private async Task<bool> IsExist(Car car, CancellationToken token) 
    {
        return await _context.Set<User>().AnyAsync(x => x.Id == car.UserId,CancellationToken.None);
    }
}