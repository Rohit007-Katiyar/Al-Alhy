using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Preferences.Add.Events;

namespace AhliFans.Core.Feature.Fan.Preferences.Add.Mapper;

public class PreferencesMapper : AutoMapper.Profile
{
  public PreferencesMapper()
  {
    CreateMap<AddPreferencesEvent, FanPreference>()
      .ForMember(dest => dest.Date,
        src => src.MapFrom(src => DateTime.Now))
      .ReverseMap();
  }
}
