using Parking.DAL.Models;

namespace Parking.DAL.Interface;

public interface IArrivalRepository:IGenericRepository<Arrival,long>
{
    Task SetEndDate(long id);
}