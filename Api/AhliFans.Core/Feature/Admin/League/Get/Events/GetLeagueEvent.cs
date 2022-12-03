using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.League.Get.Events;

public record GetLeagueEvent(int? LeagueId, string? LeagueName,string Lang,bool IsDeleted):IRequest<ActionResult>;
