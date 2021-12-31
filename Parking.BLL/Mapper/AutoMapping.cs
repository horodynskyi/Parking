using AutoMapper;
using Parking.BLL.DTO;
using Parking.DAL.Models;

namespace Parking.BLL.Mapper;

public class AutoMapping:Profile
{
    public AutoMapping()
    {
        
        CreateMap<CarUserDto, Car>()
            .ForMember(dest => dest.User,
                map => map.MapFrom(
                    src => new User()
                    {
                        Id = src.UserId
                    }))
            .ForMember(dest => dest.Id,
                map => map.MapFrom(
                    src => src.CarId));
        CreateMap<CarUserDto, User>()
            .ForMember(dest => dest.Id,
                map => map.MapFrom(
                    src => src.UserId));
        CreateMap<CarDto, Car>()
            .ForMember(dest => dest.User,
                map => map.MapFrom(src => new User
                {
                    Id = src.UserId
                }));
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.UserId,
                map => map.MapFrom(src => src.User.Id));
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.Name,
                map => map.MapFrom(src => SplitName(src.Name)[0]))
            .ForMember(dest => dest.Surname,
                map => map.MapFrom(src => SplitName(src.Name)[1]))
            .ForMember(dest => dest.Patronumic,
                map => map.MapFrom(src => SplitName(src.Name)[2]));
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Name,
                map => map.MapFrom(src => $"{src.Name} {src.Surname} {src.Patronumic}"));
        CreateMap<Status, StatusDto>();
        CreateMap<StatusDto, Status>();
        CreateMap<Tariff, TariffDto>();
        CreateMap<TariffDto, Tariff>();
    }

    public string[] SplitName(string name)
    {
        return name.Split(" ");
    }
}