namespace Parking.DAL.Models;

public class Arrival:IEntity<long>
{
    public long Id { get; set; }
    public Car? Car { get; set; }
    public DateTime? StartPark { get; set; }
    public DateTime? EndPark { get; set; }
    public Status? Status { get; set; }
}