using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;

public record GetAllMembershipCardsEvent(bool IsEnabled, int PageIndex, int PageSize, string Language = Languages.Ar) : IRequest<ActionResult>;
