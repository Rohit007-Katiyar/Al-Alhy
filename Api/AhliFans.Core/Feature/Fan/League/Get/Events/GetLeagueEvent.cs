using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.League.Get.Events;

public record GetLeagueEvent(int? LeagueId, string? LeagueName,string Lang):IRequest<ActionResult>;
