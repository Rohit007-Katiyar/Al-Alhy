using AhliFans.Core.Feature.Admin.Coach.Honor.Add.Events;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.Add.Mapper;

public class CoachHonorMapper : AutoMapper.Profile
{
  public CoachHonorMapper()
  {
    CreateMap<AddCoachHonorEvent, Entities.Honor>()
      .ForMember(dest => dest.Date,
        src => src.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.IsDeleted,
        src => src.MapFrom(src =>false))
      .ReverseMap();
  }
}
