using Parking.BLL.Interfaces;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class StatusService:IStatusService
{
    private readonly IStatusRepository _repository;

    public StatusService(IStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(Status status)
    {
        await _repository.Create(status);
    }

    public async Task<IEnumerable<Status>> Get()
    {
        return await _repository.Get();
    }

    public async Task<Status> GetById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task Update(Status status)
    {
        await _repository.Update(status);
    }

    public async Task Delete(long id)
    {
        await _repository.Delete(id);
    }
}