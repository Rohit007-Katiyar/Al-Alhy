using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.Logo.Update.Events;

public record UpdateTeamLogoEvent(int TeamId, IFormFile TeamLogo) :IRequest<ActionResult>;
