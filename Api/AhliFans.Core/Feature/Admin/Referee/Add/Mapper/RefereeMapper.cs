using AhliFans.Core.Feature.Admin.Referee.Add.Events;

namespace AhliFans.Core.Feature.Admin.Referee.Add.Mapper;

public class RefereeMapper : AutoMapper.Profile
{
  public RefereeMapper()
  {
    CreateMap<AddRefereeEvent, Entities.Referee> ()
      .ForMember(dest => dest.Date,
        src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.IsDeleted,
        src => src.MapFrom(src => false))
      .ReverseMap();
  }
}
