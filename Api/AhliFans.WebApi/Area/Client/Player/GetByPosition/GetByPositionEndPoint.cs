using AhliFans.Core.Feature.Fan.Player.GetByPosition.DTO;
using AhliFans.Core.Feature.Fan.Player.GetByPosition.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Player;

public class GetByPositionEndPoint : EndpointBaseAsync
  .WithRequest<GetByPositionRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetByPositionEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetByPositionRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<PlayersByPositionDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Players By Position",
    Description = "Client Get Players By Position",
    OperationId = "Client.PlayersPosition",
    Tags = new[] {"Player Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetByPositionRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetPlayerByPositionEvent(request.TeamId,request.GeneralPosition,request.Lang),cancellationToken);
}
