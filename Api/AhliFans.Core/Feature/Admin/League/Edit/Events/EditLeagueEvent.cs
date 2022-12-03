using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.Edit.Events;

public record EditLeagueEvent(int LeagueId, string? Name, string? NameAr, List<int>? LeagueDateTimes) : IRequest<ActionResult>;
