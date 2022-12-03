namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class EditStatisticMapper : AutoMapper.Profile
{
  public EditStatisticMapper()
  {
    CreateMap<EditStatisticEvent, Entities.MatchStatistic>()
    .ForMember(dest => dest.ModifiedOn, src => src.MapFrom(s => DateTime.Now))
    .ReverseMap();
  }
}
