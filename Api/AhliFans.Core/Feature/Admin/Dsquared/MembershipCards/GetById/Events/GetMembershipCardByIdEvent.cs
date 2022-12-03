using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public record GetMembershipCardByIdEvent(int CardId) : IRequest<ActionResult>;
