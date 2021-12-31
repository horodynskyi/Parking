using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.DAL.Repositories;

public class TariffRepository:GenericRepository<Tariff,long>,ITariffRepository
{
    public TariffRepository(DataContext context) : base(context)
    {
    }
    
}