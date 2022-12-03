using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.GetAll.Events;

public record GetAllCoachesEvent(string? SearchWord, bool IsCurrent, string Lang, int PageIndex, int PageSize,bool IsDeleted) :IRequest<ActionResult>;
