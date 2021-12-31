namespace Parking.BLL.DTO;

public class ArrivalDto
{
    public long Id { get; set; }
    public int CarId { get; set; }
    public DateTime? StartPark { get; set; }
    public DateTime? EndPark { get; set; }
    public int StatusId { get; set; }
}
