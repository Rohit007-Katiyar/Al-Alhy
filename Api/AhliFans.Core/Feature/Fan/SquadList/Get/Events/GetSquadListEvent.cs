using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.SquadList.Get.Events;

public class GetSquadListEvent : IRequest<ActionResult>
{
  public GetSquadListEvent(int matchId, string language, int? generalPositionId)
  {
    MatchId = matchId;
    if (!string.IsNullOrEmpty(language))
    {
      Language = language;
    }
    GeneralPositionId = generalPositionId;
  }
  public int MatchId { get; set; }

  public int? GeneralPositionId { get; set; }

  public string Language { get; set; } = Languages.Ar;
}
