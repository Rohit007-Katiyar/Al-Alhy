using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.GetAll.Events;

public record GetAllTrophyEvent(int PageIndex, int PageSize, int? TrophyTypeId, string? Name, bool? IsAvailable, bool IsDeleted, string Lang) :IRequest<ActionResult>;
