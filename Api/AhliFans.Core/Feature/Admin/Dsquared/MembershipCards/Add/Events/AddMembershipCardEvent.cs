using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;

public record AddMembershipCardEvent(decimal Price, string Description, string DescriptionAr, string Type, string TypeAr, int Months) : IRequest<ActionResult>;
