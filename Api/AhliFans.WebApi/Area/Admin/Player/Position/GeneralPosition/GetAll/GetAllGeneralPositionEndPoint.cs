using AhliFans.Core.Feature.Admin.Player.Position.GetGeneralPosition.DTO;
using AhliFans.Core.Feature.Admin.Player.Position.GetGeneralPosition.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.Position.GeneralPosition;

public class GetAllGeneralPositionEndPoint : EndpointBaseAsync
  .WithRequest<GetAllGeneralPositionRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllGeneralPositionEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetAllGeneralPositionRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<GeneralPositionDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get General Position",
    Description = "Admin Get General Position",
    OperationId = "Admin.GetGeneralPosition",
    Tags = new[] {"Player Position Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllGeneralPositionRequest request, CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllGeneralPositionsEvent(request.Lang), cancellationToken);
}
