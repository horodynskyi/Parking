using AutoMapper;
using Parking.BLL.DTO;
using Parking.DAL.Models;

namespace Parking.BLL.Mapper;

public class AutoMapping:Profile
{
    public AutoMapping()
    {
        
        CreateMap<CarDto, Car>();
        CreateMap<Car, CarDto>();
        
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
        
        CreateMap<Status, StatusDto>();
        CreateMap<StatusDto, Status>();
        
        CreateMap<Tariff, TariffDto>();
        CreateMap<TariffDto, Tariff>();
        
        CreateMap<Arrival, ArrivalDto>();
        CreateMap<ArrivalDto, Arrival>();
    }
    
}