using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.SquadList.Add.Events;

public record AddSquadListEvent(IReadOnlyList<int> PlayersIds, int MatchId) : IRequest<ActionResult>;
