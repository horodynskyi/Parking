using FluentValidation;
using Parking.BLL.Interfaces;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class ArrivalService :BaseService<Arrival>,IArrivalService
{
    private readonly IArrivalRepository _repository;

    public ArrivalService(IValidator<Arrival> validator, IArrivalRepository repository) : base(validator)
    {
        _repository = repository;
    }

    public async Task Create(Arrival arrival)
    {
        await _repository.Create(arrival);
        await _repository.Complete();
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
        await _repository.Complete();
    }

    public async Task SetEndDate(long id)
    {
        await _repository.SetEndDate(id);
        await _repository.Complete();
    }

    public async Task Delete(long id)
    {
        await _repository.Delete(id);
    }

   
}