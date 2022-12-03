using AhliFans.Core.Feature.Admin.Notification.Manual.Send.Events;

namespace AhliFans.Core.Feature.Admin.Notification.Manual.Send.Mapper;

public class MapNotification : AutoMapper.Profile
{
  public MapNotification()
  {
    CreateMap<SendNotificationEvent, Entities.Notification>()
      .ForMember(dest => dest.SendTime,
        src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.Icon,
        src => src.MapFrom(src => src.Icon.FileName))
      .ReverseMap();
  }
}
