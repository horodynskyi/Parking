using AutoMapper;
using Parking.BLL.Mapper;
using Parking.DAL.Models;

namespace Parking.BLL.DTO;

public class UserDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronumic { get; set; }
    public string? PhoneNumber { get; set;}
}