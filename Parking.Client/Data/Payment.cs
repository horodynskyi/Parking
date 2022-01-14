namespace Parking.Client.Data;

public class Payment
{
    public long Id { get; set; }
    public int TariffId { get; set;}
    public int? ArrivalId { get; set;  }
    public float? Sum { get; set; }
}