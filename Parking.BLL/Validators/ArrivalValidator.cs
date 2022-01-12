using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Parking.DAL;
using Parking.DAL.Models;

namespace Parking.BLL.Validators;

public class ArrivalValidator:AbstractValidator<Arrival>
{
    private readonly DataContext _context;
    
    public ArrivalValidator(DataContext context)
    {
        _context = context;
        RuleFor(x => x.CarId)
            .GreaterThan(0).WithMessage("Car id must be greater than 0");
        RuleFor(x => x.StatusId)
            .GreaterThan(0).WithMessage("Car id must be greater than 0");
        RuleFor(x => x)
            .MustAsync(IsExist).WithMessage("Car or status don't exist in db");
        
    }

    private async Task<bool> IsExist(Arrival arrival, CancellationToken token) 
    {
        if (await _context.Set<Car>().FirstOrDefaultAsync(x => x.Id == arrival.CarId) ==null || await _context.Set<Status>().FirstOrDefaultAsync(x => x.Id == arrival.StatusId) ==null)
        {
            return false;
        }
        return true;
    }
}