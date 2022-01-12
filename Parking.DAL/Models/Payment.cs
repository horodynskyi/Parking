

namespace Parking.DAL.Models;

public class Payment:IEntity<long>
{
    public long Id { get; set; }
    public long? TariffId { get; set; }
    public long? ArrivalId { get; set;  }
    public DateTime EndPark { get; set; } = DateTime.Now;
    public float? Sum { get; set; }
    
    public Arrival? Arrival { get; set;  }
    public Tariff? Tariff { get; set;}
}