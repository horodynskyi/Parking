using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.DAL.Repositories;

public class PaymentRepository:GenericRepository<Payment,long>, IPaymentRepository
{
    public PaymentRepository(DataContext context) : base(context)
    {
    }

    public override async Task<Payment?> GetById(long id)
    {
        return await DbSet
            .Include(x => x.Arrival)
            .Include(x => x.Tariff)
            .FirstOrDefaultAsync(x =>x.Id==id);
    }

    public async Task<IEnumerable<Payment>> GetPaymentsInRange(DateTime start, DateTime end)
    {
        return  await DbSet
            .Include(x => x.Arrival)
            .Include(x => x.Tariff)
            .Where(x => DateTime.Parse(x.EndPark) >= start && DateTime.Parse(x.EndPark) <= end)
            .ToListAsync();
       
    }

    public async Task<IEnumerable<Payment>> FindByCondition(Expression<Func<Payment, bool>> expression)
    {
        return DbSet.Where(expression).ToList();
    }

    public override async Task<IEnumerable<Payment>> Get()
    {
        return await DbSet
            .Include(x => x.Arrival)
            .Include(x => x.Tariff)
            .ToListAsync();
    }
}