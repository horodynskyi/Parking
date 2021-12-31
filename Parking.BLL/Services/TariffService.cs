using Parking.BLL.Interfaces;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class TariffService:ITariffService
{
    private readonly ITariffRepository _repository;

    public TariffService(ITariffRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(Tariff tariff)
    {
        await _repository.Create(tariff);
    }

    public async Task<IEnumerable<Tariff>> Get()
    {
        return await _repository.Get();
    }

    public async Task<Tariff> GetById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task Update(Tariff tariff)
    {
        await _repository.Update(tariff);
    }

    public async Task Delete(long id)
    {
        await _repository.Delete(id);
    }
}