namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class EditStatisticsGroupsMapper : AutoMapper.Profile
{
  public EditStatisticsGroupsMapper()
  {
    CreateMap<EditStatisticGroupEvent, Entities.MatchStatisticsType>()
    .ForMember(dest => dest.ModifiedOn, src => src.MapFrom(s => DateTime.Now))
    .ReverseMap();
  }
}
