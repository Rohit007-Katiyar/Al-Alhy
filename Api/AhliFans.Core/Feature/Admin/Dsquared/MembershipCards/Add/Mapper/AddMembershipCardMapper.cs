namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public class AddMembershipCardMapper : AutoMapper.Profile
{
  public AddMembershipCardMapper()
  {
    CreateMap<AddMembershipCardEvent, Entities.MembershipCard>()
      .ForMember(dest => dest.CreatedOn, s => s.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.ModifiedOn, s => s.MapFrom(src => DateTime.Now))
      .ForMember(dest => dest.IsEnabled, s => s.MapFrom(src => true))
      .ReverseMap();
  }
}
