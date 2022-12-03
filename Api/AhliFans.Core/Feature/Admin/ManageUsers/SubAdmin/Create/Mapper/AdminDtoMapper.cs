using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.Create.Events;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.Create.Mapper;
public class AdminDtoMapper : AutoMapper.Profile
{
  public AdminDtoMapper()
  {
    CreateMap<CreateEvent, Security.Entities.Admin>()
      .ForMember(dest => dest.RegistrationDate,
        src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.UserName,
        src => src.MapFrom(src =>src.PhoneNumber))
      .ForMember(dest => dest.Email,
        src => src.MapFrom(src =>string.IsNullOrEmpty(src.Email)? src.PhoneNumber+RootAdmin.TempEmail:src.Email))
      .ForMember(dest => dest.IsActive,
        src => src.MapFrom(src =>false))
      .ReverseMap();
  }
}
