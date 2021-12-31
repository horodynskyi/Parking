using AutoMapper;
using Parking.BLL.Mapper;
using Parking.DAL.Models;

namespace Parking.BLL.DTO;

public class CarDto :IMapTo<Car>
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public string? CarNumber { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CarDto, Car>()
            .ForMember(dest => dest.User,
                map => map.MapFrom(src => new User
                {
                    Id = src.UserId
                }));
        profile.CreateMap<Car, CarDto>()
            .ForMember(dest => dest.UserId,
                map => map.MapFrom(src => src.User.Id));
    }
}