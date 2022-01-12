namespace Parking.DAL.Models;

public class User:IEntity<long>
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronumic { get; set; }
    public string? PhoneNumber { get; set;}
    public List<Car>? Cars { get; set; }
}