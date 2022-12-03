using AhliFans.Core.Feature.Fan.VotePanel.Player.GetAll.DTO;
using AhliFans.Core.Feature.Fan.VotePanel.Player.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.VotePanel.Player.GetAllByMatch;

public class GetAllPlayersToVoteEndPoint : EndpointBaseAsync
  .WithRequest<GetAllPlayerToVoteRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllPlayersToVoteEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetAllPlayerToVoteRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<VotePlayersDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client get all players to vote for one",
    Description = "Client get all players to vote for one",
    OperationId = "Client.GetAllPlayersToVote",
    Tags = new[] {"Vote Engine Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllPlayerToVoteRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllPlayersToVoteEvent(request.MatchId,request.Lang), cancellationToken);
}
