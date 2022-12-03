using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Stadium.Get.Events;

public class GetStadiumByIdEvent : IRequest<ActionResult>
{
  public GetStadiumByIdEvent(int stadiumId, string language)
  {
    StadiumId = stadiumId;
    if (!string.IsNullOrEmpty(language))
    {
      Language = language;
    }
  }

  public int StadiumId { get; set; }

  public string Language { get; set; } = Languages.Ar;
}
