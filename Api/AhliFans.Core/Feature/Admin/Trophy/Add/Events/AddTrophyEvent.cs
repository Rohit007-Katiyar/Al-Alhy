using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.Add.Events;

public record AddTrophyEvent(int TrophyTypeId, string Name, string NameAr, List<int> HistoryYears, IFormFile? Picture) : IRequest<ActionResult>;
