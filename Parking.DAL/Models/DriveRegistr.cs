namespace Parking.DAL.Models;

public class DriveRegistr:IEntity
{
    public long Id { get; set; }
    public Car? CarId { get; set; }
    public DateTime? StartPark { get; set; }
    public DateTime? EndPark { get; set; }
    public Status? StatusId { get; set; }
}