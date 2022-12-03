using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MomentVideo.Edit;

public class EditMomentVideoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MomentVideo";
  public int MomentVideoId { get; set; }
  public int SeasonId { get; set; }
  public string Month { get; set; }
  public string VideoURL { get; set; } 
  public int MatchId { get; set; }
  public int LeagueId { get; set; }
  public string Description { get; set; }
  public string DescriptionAr { get; set; }
  public int PlayerId { get; set; }
  public string VideoType { get; set; }
  public int Time { get; set; }
  public int CategoryId { get; set; }
}
