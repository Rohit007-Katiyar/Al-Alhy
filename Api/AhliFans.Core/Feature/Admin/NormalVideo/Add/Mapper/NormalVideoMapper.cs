using AhliFans.Core.Feature.Admin.NormalVideo.Add.Events;

namespace AhliFans.Core.Feature.Admin.NormalVideo.Add.Mapper;
public class NormalVideoMapper : AutoMapper.Profile
{
  public NormalVideoMapper()
  {
    CreateMap<AddNormalVideoEvent, Entities.NormalVideo>()
      .ForMember(dest => dest.SeasonId,
        src => src.MapFrom(src => src.SeasonId))
      .ForMember(dest => dest.MatchId,
        src => src.MapFrom(src => src.MatchId))
      .ForMember(dest => dest.CategoryId,
        src => src.MapFrom(src => src.CategoryId))
      .ForMember(dest => dest.LeagueId,
        src => src.MapFrom(src => src.LeagueId))
       .ForMember(dest => dest.PlayerId,
        src => src.MapFrom(src => src.PlayerId))
        .ForMember(dest => dest.CoachId,
        src => src.MapFrom(src => src.CoachId))

      .ForMember(dest => dest.Season,
        src => src.Ignore())
      .ForMember(dest => dest.Match,
        src => src.Ignore())
       .ForMember(dest => dest.Category,
        src => src.Ignore())
        .ForMember(dest => dest.League,
         src => src.Ignore())
         .ForMember(dest => dest.Player,
        src => src.Ignore())
          .ForMember(dest => dest.Coach,
        src => src.Ignore())

        .ForMember(dest => dest.CreatedOn,
        src => src.MapFrom(src => DateTime.Now))
       .ForMember(dest => dest.CreatedById,
        src => src.MapFrom(src => Guid.Parse(src.AdminId)))
       .ForMember(dest => dest.IsDeleted,
        src => src.MapFrom(src => false))

      .ReverseMap();
  }
}
