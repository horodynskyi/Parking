using Microsoft.EntityFrameworkCore;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.DAL.Repositories;

public class ArrivalRepository:GenericRepository<Arrival,long>, IArrivalRepository
{
    public ArrivalRepository(DataContext context) : base(context)
    {
    }

    public override async Task<Arrival> GetById(long id)
    {
        return await DbSet
            .Include(x => x.Car)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<IEnumerable<Arrival>> Get()
    {
        return await DbSet
            .Include(x => x.Car)
            .ToListAsync();
    }
}