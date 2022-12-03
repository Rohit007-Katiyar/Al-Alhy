using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Season.GetAll.Events;
public record GetAllSeasonsEvent(int PageIndex, int PageSize, string? Name, DateTime? StartDate, DateTime? EndDate, string Lang,bool IsDeleted) :IRequest<ActionResult>;
