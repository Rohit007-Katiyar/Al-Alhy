using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.Add.Events;

public record AddTeamEvent(int TypeId, int RegionId, string Name, string NameAr, IFormFile? Logo) :IRequest<ActionResult>;
