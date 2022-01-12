namespace Parking.BLL.DTO;

public class ArrivalDto
{
    public long Id { get; set; }
    public int CarId { get; set; }
    public DateTime? StartPark { get; set; } = DateTime.Now;
    public int StatusId { get; set; }
}
