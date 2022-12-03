using AhliFans.Core.Feature.Admin.Coach.Title.Add.Events;

namespace AhliFans.Core.Feature.Admin.Coach.Title.Add.Mapper;
public class TitleMapper : AutoMapper.Profile
{
  public TitleMapper()
  {
    CreateMap<AddTitleEvent,Entities.Title>()
      .ForMember(dest => dest.Date,
        src => src.MapFrom(src => DateTime.Now))
      .ReverseMap();
  }
}
