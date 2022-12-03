using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public record ToggleMembershipCardEvent(int CardId) : IRequest<ActionResult>;
