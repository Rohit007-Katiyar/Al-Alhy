namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class AddMatchGoalMapper : AutoMapper.Profile
{
    public AddMatchGoalMapper()
    {
        CreateMap<AddMatchGoalEvent, Entities.MatchGoal>()
        .ForMember(dest => dest.CreatedOn, s => s.MapFrom(src => DateTime.Now))
        .ForMember(dest => dest.ModifiedOn, s => s.MapFrom(src => DateTime.Now))
        .ForMember(dest => dest.IsEnabled, s => s.MapFrom(src => true))
        .ReverseMap();
    }
}