using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.Add.Events;

public record AddSeasonEvent(string Name, string NameAr, DateTime StartDate, DateTime EndDate):IRequest<ActionResult>;
