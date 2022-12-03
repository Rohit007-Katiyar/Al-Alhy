using AhliFans.Core.Feature.Admin.Stadium.Add.Events;

namespace AhliFans.Core.Feature.Admin.Stadium.Add.Mapper;

public class StadiumMapper : AutoMapper.Profile
{
  public StadiumMapper()
  {
    CreateMap<AddStadiumEvent, Entities.Stadium>()
      .ForMember(dest => dest.Date, src => src.MapFrom(src => DateTime.Now))
      .ReverseMap();
  }
    
}
