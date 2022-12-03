using AhliFans.Core.Feature.Fan.Player.GetGeneralPosition.DTO;
using AhliFans.Core.Feature.Fan.Player.GetGeneralPosition.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Player;

public class GetAllGeneralPositionEndPoint : EndpointBaseAsync
  .WithRequest<GetAllGeneralPositionRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllGeneralPositionEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetAllGeneralPositionRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<GeneralPositionDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get General Position",
    Description = "Client Get General Position",
    OperationId = "Client.GetGeneralPosition",
    Tags = new[] {"Player Position Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllGeneralPositionRequest request, CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllGeneralPositionsEvent(request.Lang), cancellationToken);
}
