using AhliFans.Core.Feature.Security.Registration.Fan.Events;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AutoMapper;

namespace AhliFans.Core.Feature.Security.Registration.Fan.Mapper;
public class FanMapper : Profile
{
  public FanMapper()
  {
    CreateMap<RegistrationEvent, Entities.Fan>()
      .ForMember(dest => dest.RegistrationDate,
        src => src.MapFrom(src => DateTime.Now))
       .ForMember(dest => dest.City,
        src =>src.Ignore())
      .ForMember(dest => dest.CityId,
        src =>src.MapFrom(src=>src.City))
      .ForMember(dest => dest.Email,
        src => src.MapFrom(src => string.IsNullOrEmpty(src.Email)?src.PhoneNumber+RootAdmin.TempEmail:src.Email))
      .ForMember(dest => dest.BirthDate,
        src => src.MapFrom(src => src.BirthDate))
      .ForMember(dest => dest.UserName,
        src => src.MapFrom(src => src.PhoneNumber))
      .ForMember(dest => dest.FullName,
        src => src.MapFrom(src => src.FullName))
      .ForMember(dest => dest.ProfilePic,
        src => src.MapFrom(src => src.ProfilePic!.FileName))
      .ForMember(dest => dest.IsBlocked,
        src => src.MapFrom(src => false)) 
      .ForMember(dest => dest.IsActive,
        src => src.MapFrom(src => false))
      .ReverseMap();
  }
}
