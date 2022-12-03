using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.GetAll.Events;

public record GetAllCoachesEvent(string? SearchWord, string Lang, int PageIndex, int PageSize,bool IsDeleted) :IRequest<ActionResult>;
