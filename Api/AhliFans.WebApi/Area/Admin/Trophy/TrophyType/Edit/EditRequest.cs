#nullable disable
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Trophy.TrophyType;

public record EditRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Type";
  [FromHeader] public int TypeId { get; set; }
  [CanBeNull] public string Name { get; set; }
  [CanBeNull] public string NameAr { get; set; }
}
