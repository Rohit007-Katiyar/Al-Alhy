using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipCards;

public record GetMembershipCardByIdEvent(int CardId, string Language = Languages.Ar) : IRequest<ActionResult>;
