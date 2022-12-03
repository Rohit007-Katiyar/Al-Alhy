using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions.Subscribe;

public record SubscribeEvent(int MembershipCardId, string Email, string CardNumber, int Cvv, string ExpiryYear, string ExpiryMonth, string Language = Languages.Ar) : IRequest<ActionResult>;
