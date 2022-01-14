namespace Parking.Client.Data;

public class Arrival
{
    public long Id { get; set; }
    public int CarId { get; set; }
    public int StatusId { get; set; } = 0;
}