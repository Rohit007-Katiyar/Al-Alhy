using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Match.GetByMatchId.Events;

public class GetMatchByIdEvents : IRequest<ActionResult>
{
    public GetMatchByIdEvents(int id, string language)
    {
        MatchId = id;
        Language = language;
    }
    public int MatchId { get; set; }

    public string Language { get; set; } = Languages.Ar;
}
