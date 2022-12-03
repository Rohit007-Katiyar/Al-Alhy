using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.Logo.Get.Events;
public record GetTeamLogoEvent(int TeamId) :IRequest<ActionResult>;
