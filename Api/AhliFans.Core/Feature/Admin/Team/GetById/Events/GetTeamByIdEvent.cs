using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.GetById.Events;

public record GetTeamByIdEvent(int TeamId,string Lang):IRequest<ActionResult>;
