using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions;

public record GetSubscriptionsEvent(string Language = Languages.Ar) : IRequest<ActionResult>;
