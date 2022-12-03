using AhliFans.Core.Feature.Fan.VotePanel.Player.Vote.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.VotePanel.Player.Vote;

public class VoteForPlayerEndPoint : EndpointBaseAsync
  .WithRequest<VoteForPlayerRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public VoteForPlayerEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(VoteForPlayerRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client vote for player",
    Description = "Client vote for player",
    OperationId = "Client.VoteForPlayer",
    Tags = new[] {"Vote Engine Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(VoteForPlayerRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new VoteForPlayerEvent(request.PlayerId, request.MatchId), cancellationToken);
}
