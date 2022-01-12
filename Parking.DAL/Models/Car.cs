namespace Parking.DAL.Models;

public class Car:IEntity<long>
{
    public long Id { get; set; }
    public long? UserId { get; set; }
    public string? CarNumber { get; set; }
    public User? User { get; set; }
    public List<Arrival>? Arrivals { get; set; }
}