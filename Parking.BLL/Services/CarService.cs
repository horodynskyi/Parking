using FluentValidation;
using FluentValidation.Results;
using Parking.BLL.Helpers;
using Parking.BLL.Interfaces;
using Parking.BLL.Params;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class CarService:BaseService<Car>,ICarService
{
    private readonly ICarRepository _carRepository;
   
    public CarService(ICarRepository repository, IValidator<Car> validator,ISortHelper<Car> sortHelper) : base(validator,sortHelper)
    {
        _carRepository = repository;
    }

    public async Task Create(Car user)
    {
        await _carRepository.Create(user);
        await _carRepository.Complete();
    }

    public async Task Create(Car car, User user)
    {
      
    }

    public async Task<IEnumerable<Car>> Get(CarParams carParams)
    {
        var cars = await _carRepository.Get();
        return PageHelper<Car>.ToPagedList(cars,carParams);
    }

    public async Task<Car> GetById(long id)
    {
        return await _carRepository.GetById(id);
    }

    public async Task Update(Car user)
    {
        await _carRepository.Update(user);
    }

    public async Task Delete(long id)
    {
        await _carRepository.Delete(id);
    }
    
}