

namespace Parking.DAL.Models;

public class Payment:IEntity
{
    public long Id { get; set; }
    public Tariff? TariffId { get; set;}
    public DriveRegistr? RegistrId { get; set;  }
    public float? Sum { get; set; }
}