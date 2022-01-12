using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface IArrivalService:IBaseService<Arrival>
{
    Task Create(Arrival arrival);
    Task<IEnumerable<Arrival>> Get();
    Task<Arrival> GetById(long id);
    Task Update(Arrival arrival);
    Task SetEndDate(long id);
    Task Delete(long id);
}