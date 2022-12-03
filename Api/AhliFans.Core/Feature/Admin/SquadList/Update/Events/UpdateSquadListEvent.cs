using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.SquadList.Update.Events;

public record UpdateSquadListEvent : IRequest<ActionResult>
{
  public UpdateSquadListEvent(IReadOnlyList<int> playersIds, int matchId)
  {
    PlayersIds = playersIds;
    MatchId = matchId;
  }

  public IReadOnlyList<int> PlayersIds { get; set; }

  public int MatchId { get; set; }
}
