using AhliFans.Core.Feature.Entities;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class AddMatchCardMapper : AutoMapper.Profile
{
    public AddMatchCardMapper()
    {
        CreateMap<AddMatchCardEvent, MatchCard>()
        .ForMember(dest => dest.CreatedOn, s => s.MapFrom(src => DateTime.Now))
        .ForMember(dest => dest.ModifiedOn, s => s.MapFrom(src => DateTime.Now))
        .ForMember(dest => dest.IsEnabled, s => s.MapFrom(src => true))
        .ReverseMap();
    }
}