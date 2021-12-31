

namespace Parking.DAL.Models;

public class Payment:IEntity<long>
{
    public long Id { get; set; }
    public Tariff? TariffId { get; set;}
    public Arrival? RegistrId { get; set;  }
    public float? Sum { get; set; }
}