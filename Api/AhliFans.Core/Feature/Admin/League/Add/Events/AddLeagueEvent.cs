using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.Add.Events;

public record AddLeagueEvent(string Name, string NameAr, List<int> LeagueDateTimes) : IRequest<ActionResult>;
