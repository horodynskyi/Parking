namespace Parking.DAL.Models;

public class User:IEntity
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronumic { get; set; }
    public string? PhoneNumber { get; set;}
}