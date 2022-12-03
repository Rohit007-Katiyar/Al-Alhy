using AhliFans.Core.Feature.Admin.Region.Add.Events;

namespace AhliFans.Core.Feature.Admin.Region.Add.Mapper;

public class MapRegion : AutoMapper.Profile
{
  public MapRegion()
  {
    CreateMap<AddRegionEvent, Entities.Region>()
      .ForMember(dest =>dest.Date,src=>src.MapFrom(src=>DateTime.Now))
      .ReverseMap();
  }
}
