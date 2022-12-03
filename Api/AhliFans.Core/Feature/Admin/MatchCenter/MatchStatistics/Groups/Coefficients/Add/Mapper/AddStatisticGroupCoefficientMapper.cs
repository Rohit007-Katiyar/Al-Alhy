namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class AddStatisticGroupCoefficientMapper : AutoMapper.Profile
{
  public AddStatisticGroupCoefficientMapper()
  {
    CreateMap<AddStatisticGroupCoefficientEvent, Entities.MatchStatisticsTypeCoefficient>()
    .ForMember(dest => dest.CreatedOn, src => src.MapFrom(s => DateTime.Now))
    .ForMember(dest => dest.ModifiedOn, src => src.MapFrom(s => DateTime.Now))
    .ForMember(dest => dest.MatchStatisticsTypeId, src => src.MapFrom(s => s.StatisticTypeId))
    .ReverseMap();
  }
}
