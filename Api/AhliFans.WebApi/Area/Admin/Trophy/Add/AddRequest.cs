#nullable disable
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy;

public record AddRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy";
  public int TrophyTypeId { get; set; }
  public string Name { get; set; } 
  public string NameAr { get; set; }
  public List<int> HistoryYears { get; set; }
  [CanBeNull] public IFormFile Picture { get; set; }
}
