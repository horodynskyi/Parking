using Microsoft.EntityFrameworkCore;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.DAL.Repositories;

public class CarRepository:GenericRepository<Car,long>, ICarRepository
{
    public CarRepository(DataContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<Car>> Get()
    {
        return await DbSet
            .Include(x => x.User)
            .ToListAsync();
    }
    public override async Task<Car?> GetById(long id)
    {
        return await DbSet
            .Include(x => x.User)
            .FirstOrDefaultAsync(x =>x.Id ==id);
    }
}