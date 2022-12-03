using AhliFans.Core.Feature.Admin.Match.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

public class EditMatchEndPoint : EndpointBaseAsync
  .WithRequest<EditMatchRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditMatchEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(AddMatchRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Match",
    Description = "Admin Edit Match",
    OperationId = "Admin.EditMatch",
    Tags = new[] {"Match Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditMatchRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(
      new EditMatchEvent(request.MatchId,request.SeasonId, request.OpponentTeamId, request.StadiumId, request.RefereeId, request.IsAway,
        request.MatchDate, request.Time, request.Score, request.OpponentScore,request.LeagueId, request.LeagueDateId,request.MatchType,
        request.JerseyId,request.PlannedTime,request.PlannedDate,request.ActualTime,request.ActualDate,request.MatchStatus,request.BroadcastChannelId), cancellationToken);
}
