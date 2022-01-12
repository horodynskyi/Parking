namespace Parking.DAL.Models;

public class Status:IEntity<long>
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public List<Arrival>? Arrivals { get; set; }
}