using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.ChangeStatus.Events;
public record ChangeLeagueStatusEvent(int LeagueId):IRequest<ActionResult>;
