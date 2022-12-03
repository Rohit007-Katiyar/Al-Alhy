using AhliFans.Core.Feature.Fan.VotePanel.Moment.Vote.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.VotePanel.Moment.Vote;

public class VoteForMomentEndPoint : EndpointBaseAsync
  .WithRequest<VoteForMomentRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public VoteForMomentEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(VoteForMomentRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client vote for Moment",
    Description = "Client vote for Moment",
    OperationId = "Client.VoteForMoment",
    Tags = new[] {"Vote Engine Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(VoteForMomentRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new VoteForMomentEvent(request.MomentId), cancellationToken);
}
