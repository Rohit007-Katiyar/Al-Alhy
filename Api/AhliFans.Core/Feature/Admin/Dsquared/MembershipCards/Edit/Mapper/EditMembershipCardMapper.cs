namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;

public class EditMembershipCardMapper : AutoMapper.Profile
{
  public EditMembershipCardMapper()
  {
    CreateMap<EditMembershipCardEvent, Entities.MembershipCard>()
      .ForMember(dest => dest.ModifiedOn, s => s.MapFrom(src => DateTime.Now))
      .ReverseMap();
  }
}
