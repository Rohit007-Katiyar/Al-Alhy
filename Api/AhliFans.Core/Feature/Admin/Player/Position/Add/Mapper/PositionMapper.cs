using AhliFans.Core.Feature.Admin.Player.Position.Add.Events;

namespace AhliFans.Core.Feature.Admin.Player.Position.Add.Mapper;
public class PositionMapper : AutoMapper.Profile
{
  public PositionMapper()
  {
    CreateMap<AddPositionEvent,Entities.Position>()
      .ForMember(dest => dest.Date,
        src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.GeneralPositionId,
        src => src.MapFrom(src => src.GeneralPositionId))
      .ReverseMap();
  }
}
