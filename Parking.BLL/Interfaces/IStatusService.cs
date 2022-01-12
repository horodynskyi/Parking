using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface IStatusService:IBaseService<Status>
{
    Task Create(Status status);
    Task<IEnumerable<Status>> Get();
    Task<Status> GetById(long id);
    Task Update(Status status);
    Task Delete(long id);
}