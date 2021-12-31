namespace Parking.BLL.DTO;

public class PaymentDto
{
    public long Id { get; set; }
    public int TariffId { get; set;}
    public int? ArrivalId { get; set;  }
    public float? Sum { get; set; }
}