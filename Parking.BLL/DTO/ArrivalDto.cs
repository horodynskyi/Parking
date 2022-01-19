namespace Parking.BLL.DTO;

public class ArrivalDto
{
    public long Id { get; set; }
    public int CarId { get; set; }
    public string? StartPark { get; set; }
    public int StatusId { get; set; }
}
