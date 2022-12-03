using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.GetDates.Events;

public record GetLeagueDateEvent(int LeagueId):IRequest<ActionResult>;
