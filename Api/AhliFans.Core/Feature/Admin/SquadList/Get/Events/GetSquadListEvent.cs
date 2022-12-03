using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.SquadList.Get.Events;

public class GetSquadListEvent : IRequest<ActionResult>
{
  public GetSquadListEvent(int matchId, string language)
  {
    MatchId = matchId;
    if (!string.IsNullOrEmpty(language))
    {
      Language = language;
    }
  }
  public int MatchId { get; set; }

  public string Language {get; set;} = Languages.Ar;
}
