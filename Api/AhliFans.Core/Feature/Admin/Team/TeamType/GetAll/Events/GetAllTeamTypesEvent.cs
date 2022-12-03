using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.GetAll.Events;

public record GetAllTeamTypesEvent(string Lang, bool IsDeleted) : IRequest<ActionResult>;
