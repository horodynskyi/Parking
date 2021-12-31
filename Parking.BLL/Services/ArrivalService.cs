using Parking.BLL.Interfaces;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class ArrivalService :IArrivalService
{
    private readonly IArrivalRepository _repository;

    public ArrivalService(IArrivalRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(Arrival arrival)
    {
        await _repository.Create(arrival);
    }

    public async Task<IEnumerable<Arrival>> Get()
    {
        return await _repository.Get();
    }

    public async Task<Arrival> GetById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task Update(Arrival arrival)
    {
        await _repository.Update(arrival);
    }

    public async Task Delete(long id)
    {
        await _repository.Delete(id);
    }
}