using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Dsquared.MembershipCards;

public record EditMembershipCardRequest(int Id, string Type, string TypeAr, string Description, string DescriptionAr, decimal Price, int Months)
{
    public const string Route = $"{nameof(Areas.Admin)}/Dsquared/MembershipCards";
};
