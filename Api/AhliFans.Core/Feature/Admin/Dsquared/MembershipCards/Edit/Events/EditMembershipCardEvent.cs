using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;

public record EditMembershipCardEvent(int CardId, string Description, string DescriptionAr, string Type, string TypeAr, decimal Price, int Months) : IRequest<ActionResult>;
