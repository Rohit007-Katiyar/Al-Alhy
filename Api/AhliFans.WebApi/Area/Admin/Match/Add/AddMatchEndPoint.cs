using AhliFans.Core.Feature.Admin.Match.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

public class AddMatchEndPoint : EndpointBaseAsync
  .WithRequest<AddMatchRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddMatchEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddMatchRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Match",
    Description = "Admin Add Match",
    OperationId = "Admin.AddMatch",
    Tags = new[] {"Match Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddMatchRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(
      new AddMatchEvent(request.SeasonId, request.OpponentTeamId, request.StadiumId, request.RefereeId,request.LeagueId,request.LeagueDateId,request.IsAway,
        request.Time, request.Score, request.OpponentScore, request.MatchType,request.JerseyId,
        request.PlannedTime,request.PlannedDate,request.ActualTime,request.ActualDate,request.BroadcastChannelId,request.MatchStatus), cancellationToken);
}
