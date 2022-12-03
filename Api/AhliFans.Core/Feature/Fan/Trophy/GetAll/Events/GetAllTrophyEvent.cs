using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Trophy.GetAll.Events;

public record GetAllTrophyEvent(int PageIndex, int PageSize, int? TrophyTypeId, string? Name, string Lang) :IRequest<ActionResult>;
