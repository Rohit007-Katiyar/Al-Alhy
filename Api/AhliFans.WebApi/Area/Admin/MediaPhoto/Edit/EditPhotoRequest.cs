using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.Edit;

public class EditPhotoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MediaPhoto";
  public int PhotoId { get; set; }
  public int SeasonId { get; set; }
  public string Month { get; set; }
  public string? PhotoLink { get; set; } = ""!;
  public int MatchId { get; set; }
  public int LeagueId { get; set; }
  public string Description { get; set; }
  public string DescriptionAr { get; set; }
  public int? PlayerId { get; set; } = 0;
  public int? CoachId { get; set; } = 0;
  public int CategoryId { get; set; }

  public bool? IsExclusiveContent { get; set; } = false;
}
