using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.DAL.Repositories;

public class StatusRepository:GenericRepository<Status,long>, IStatusRepository
{
    public StatusRepository(DataContext context) : base(context)
    {
    }
}