using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.Edit.Events;

public record EditSeasonEvent(int SeasonId, string? Name, string? NameAr, DateTime? StartDate, DateTime? EndDate):IRequest<ActionResult>;
