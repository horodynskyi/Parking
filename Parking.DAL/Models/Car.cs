namespace Parking.DAL.Models;

public class Car:IEntity
{
    public long Id { get; set; }
    public User? UserId { get; set; }
    public string? CarNumber { get; set; }
}