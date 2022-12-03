using AhliFans.Core.Feature.Admin.Trophy.Add.Events;

namespace AhliFans.Core.Feature.Admin.Trophy.Add.Mapper;

public class TrophyMapper : AutoMapper.Profile
{
  public TrophyMapper()
  {
    CreateMap<AddTrophyEvent, Entities.Trophy>()
      .ForMember(dest=>dest.CreatedOn,src=>src.MapFrom(src=> DateTime.Now))
      .ForMember(dest=>dest.Picture,src=>src.MapFrom(src=> src.Picture!.FileName))
      .ReverseMap();

  }
}
