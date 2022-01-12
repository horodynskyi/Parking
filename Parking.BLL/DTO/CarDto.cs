using AutoMapper;
using Parking.BLL.Mapper;
using Parking.DAL.Models;

namespace Parking.BLL.DTO;

public class CarDto 
{
    public long Id { get; set; }
    public long? UserId { get; set; }
    public string? CarNumber { get; set; }
}