namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class EditStatisticGroupCoefficentMapper : AutoMapper.Profile
{
  public EditStatisticGroupCoefficentMapper()
  {
    CreateMap<EditStatisticGroupCoefficientEvent, Entities.MatchStatisticsTypeCoefficient>()
    .ForMember(dest => dest.ModifiedOn, src => src.MapFrom(s => DateTime.Now))
    .ReverseMap();
  }
}
