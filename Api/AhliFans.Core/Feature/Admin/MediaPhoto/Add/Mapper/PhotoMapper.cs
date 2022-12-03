using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Admin.Coach.Add.Events;
using AhliFans.Core.Feature.Admin.MediaPhoto.Add.Events;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Add.Mapper;
public class PhotoMapper : AutoMapper.Profile
{
  public PhotoMapper()
  {
    CreateMap<AddPhotoEvent, Entities.MediaPhoto>()
      .ForMember(dest => dest.Photo,
        src => src.MapFrom(src => src.Photo!.FileName))

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
