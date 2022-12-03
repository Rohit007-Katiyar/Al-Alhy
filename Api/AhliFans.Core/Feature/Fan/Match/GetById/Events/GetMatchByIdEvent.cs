using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Match.GetById.Events;

public class GetMatchByIdEvent : IRequest<ActionResult>
{
  public GetMatchByIdEvent(int id, string language)
  {
    MatchId = id;
    Language = language;
  }
  public int MatchId { get; set; }

  public string Language { get; set; } = Languages.Ar;
}
