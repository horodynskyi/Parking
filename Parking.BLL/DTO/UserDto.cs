using AutoMapper;
using Parking.BLL.Mapper;
using Parking.DAL.Models;

namespace Parking.BLL.DTO;

public class UserDto:IMapTo<User>
{
      public long Id { get; set; }
    public string? Name { get; set; }
    /*public string? Surname { get; set; }
    public string? Patronumic { get; set; }*/
    public string? PhoneNumber { get; set;}
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserDto, User>()
            .ForMember(dest => dest.Name,
                map => map.MapFrom(src => SplitName(src.Name)[0]))
            .ForMember(dest => dest.Surname,
                map => map.MapFrom(src => SplitName(src.Name)[1]))
            .ForMember(dest => dest.Patronumic,
                map => map.MapFrom(src => SplitName(src.Name)[2]));
        profile.CreateMap<User, UserDto>()
            .ForMember(dest => dest.Name,
                map => map.MapFrom(src => $"{src.Name} {src.Surname} {src.Patronumic}"));
    }
    private string[] SplitName(string name)
    {
        return name.Split(" ");
    }
}