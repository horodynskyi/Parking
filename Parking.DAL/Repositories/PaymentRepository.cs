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
            .Include(x => x.RegistrId)
            .Include(x => x.TariffId)
            .FirstOrDefaultAsync(x =>x.Id==id);
    }

    public override async Task<IEnumerable<Payment>> Get()
    {
        return await DbSet
            .Include(x => x.RegistrId)
            .Include(x => x.TariffId)
            .ToListAsync();
    }
}