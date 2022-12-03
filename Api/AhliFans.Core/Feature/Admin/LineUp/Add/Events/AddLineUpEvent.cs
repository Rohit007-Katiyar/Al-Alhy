using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.LineUp.Add.Events;

public record AddLineUpEvent(List<int> PlayersList,List<int> PositionList,int MatchId, List<bool> IsSubstitute) :IRequest<ActionResult>;
