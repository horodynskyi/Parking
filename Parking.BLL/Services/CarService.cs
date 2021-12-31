using Parking.BLL.Interfaces;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class CarService:ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IUserRepository _userRepository;

    public CarService(ICarRepository repository, IUserRepository userRepository)
    {
        _carRepository = repository;
        _userRepository = userRepository;
    }

    public async Task Create(Car user)
    {
        await _carRepository.Create(user);
    }

    public async Task Create(Car car, User user)
    {
        var res = await _userRepository.GetById(user.Id);
        if (res == null)
        {
            
        }
    }

    public async Task<IEnumerable<Car>> Get()
    {
        return await _carRepository.Get();
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