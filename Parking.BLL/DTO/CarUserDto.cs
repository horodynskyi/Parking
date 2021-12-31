using Parking.BLL.Mapper;

namespace Parking.BLL.DTO;

public class CarUserDto
{
    public long CarId { get; set; }
    public long UserId { get; set; }
    public string? CarNumber { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronumic { get; set; }
    public string? PhoneNumber { get; set;}
}