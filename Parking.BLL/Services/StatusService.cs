using FluentValidation;
using Parking.BLL.Helpers;
using Parking.BLL.Interfaces;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class StatusService:BaseService<Status>,IStatusService
{
    private readonly IStatusRepository _repository;

    public StatusService(IStatusRepository repository,IValidator<Status> validator,ISortHelper<Status> sortHelper):base(validator,sortHelper)
    {
        _repository = repository;
    }

    public async Task Create(Status status)
    {
        await _repository.Create(status);
        await _repository.Complete();
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