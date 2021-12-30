namespace Parking.DAL.Models;

public class Status:IEntity
{
    public long Id { get; set; }
    public string? Name { get; set; }
}