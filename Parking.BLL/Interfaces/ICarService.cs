using FluentValidation.Results;
using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface ICarService
{
    Task Create(Car car);
    Task Create(Car car,User user);
    Task<IEnumerable<Car>> Get();
    Task<Car> GetById(long id);
    Task Update(Car user);
    Task Delete(long id);
    Task<ValidationResult> Validation(Car car);
}