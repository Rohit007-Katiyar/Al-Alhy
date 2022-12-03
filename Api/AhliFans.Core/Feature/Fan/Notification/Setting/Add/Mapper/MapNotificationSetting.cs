using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Notification.Setting.Add.Events;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Add.Mapper;

public class MapNotificationSetting : AutoMapper.Profile
{
  public MapNotificationSetting()
  {
    CreateMap<AddSettingEvent, NotificationSetting>()
      .ReverseMap();
  }
}
