using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface ITariffService:IBaseService<Tariff>
{
    Task Create(Tariff tariff);
    Task<IEnumerable<Tariff>> Get();
    Task<Tariff> GetById(long id);
    Task Update(Tariff tariff);
    Task Delete(long id);
}