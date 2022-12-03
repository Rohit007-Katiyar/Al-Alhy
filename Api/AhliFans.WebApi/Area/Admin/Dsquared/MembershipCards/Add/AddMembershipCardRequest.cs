using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Dsquared.MembershipCards;

public record AddMembershipCardRequest(string Type, string TypeAr, string Description, string DescriptionAr, int Months, decimal Price)
{
    public const string Route = $"{nameof(Areas.Admin)}/Dsquared/MembershipCards";
};
