namespace Parking.DAL.Models;

public class Arrival:IEntity<long>
{
    public long Id { get; set; }
    public long? CarId { get; set; }
    public string StartPark { get; set; } = DateTime.Now.ToString("yy-MM-dd");
    public long? StatusId { get; set; }

    public Status? Status { get; set; }
    public Car? Car { get; set; }
    public List<Payment>? Payments { get; set; }
}