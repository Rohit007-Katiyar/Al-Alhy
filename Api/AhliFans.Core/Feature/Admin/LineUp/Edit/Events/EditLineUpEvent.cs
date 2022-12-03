using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.LineUp.Edit.Events;

public record EditLineUpEvent(int MatchId, List<int> PlayersList, List<int> PositionList, List<bool> IsSubstitute) :IRequest<ActionResult>;
