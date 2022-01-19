using FluentValidation.Results;
using Parking.BLL.Params;
using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface ICarService:IBaseService<Car>
{
    Task Create(Car car);
    Task Create(Car car,User user);
    Task<IEnumerable<Car>> Get(CarParams carParams);
    Task<Car> GetById(long id);
    Task Update(Car user);
    Task Delete(long id);
    Task<ValidationResult> Validation(Car car);
}