namespace Parking.Client.Data;

public class Car
{
    public long Id { get; set; }
    public long? UserId { get; set; }
    public string? CarNumber { get; set; }
}