using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.Edit.Events;

public record EditTrophyEvent(int TrophyId, int TrophyTypeId,string? Name, string? NameAr, List<int>? HistoryYears) : IRequest<ActionResult>;

