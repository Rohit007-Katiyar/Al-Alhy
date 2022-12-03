#nullable disable
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Trophy;

public record EditRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy";
  [FromHeader]public int TrophyId { get; set; }
  public int TrophyTypeId { get; set; }
  [CanBeNull] public string Name { get; set; }
  [CanBeNull] public string NameAr { get; set; }
  [CanBeNull] public List<int> HistoryYears { get; set; } 
}
