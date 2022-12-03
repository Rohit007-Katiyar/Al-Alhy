using AhliFans.Core.Feature.Admin.Moment.Add.Events;

namespace AhliFans.Core.Feature.Admin.Moment.Add.Mapper;

public class MomentMapper : AutoMapper.Profile
{
  public MomentMapper()
  {
    CreateMap<AddMomentEvent, Entities.Moment>()
      .ForMember(dest => dest.MediaFileName,
        src => src.MapFrom(src => src.MomentVideo == null ? "": src.MomentVideo.FileName)) 
      .ForMember(dest => dest.IsAvailable,
        src => src.MapFrom(src => true))
      .ReverseMap();
  }
}
