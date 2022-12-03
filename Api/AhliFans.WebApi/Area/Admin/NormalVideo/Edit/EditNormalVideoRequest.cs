using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.NormalVideo.Edit;

public class EditNormalVideoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/NormalVideo";
  public int NormalVideoId { get; set; }
  public int SeasonId { get; set; }
  public string Month { get; set; }
  public string VideoURL { get; set; } 
  public int MatchId { get; set; }
  public int LeagueId { get; set; }
  public string Description { get; set; }
  public string DescriptionAr { get; set; }
  public int? PlayerId { get; set; } = 0;
  public int? CoachId { get; set; } = 0;
  public int CategoryId { get; set; }
}
