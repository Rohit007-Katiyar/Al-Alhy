namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class AddStatisticMapper : AutoMapper.Profile
{
  public AddStatisticMapper()
  {
    CreateMap<AddStatisticEvent, Entities.MatchStatistic>()
    .ForMember(dest => dest.CreatedOn, src => src.MapFrom(s => DateTime.Now))
    .ForMember(dest => dest.ModifiedOn, src => src.MapFrom(s => DateTime.Now))
    .ReverseMap();
  }
}
