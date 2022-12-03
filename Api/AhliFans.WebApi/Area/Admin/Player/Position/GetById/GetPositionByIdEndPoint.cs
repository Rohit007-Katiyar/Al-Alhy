using AhliFans.Core.Feature.Admin.Player.Position.GetById.DTO;
using AhliFans.Core.Feature.Admin.Player.Position.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public class GetPositionByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetPositionByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetPositionByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetPositionByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PositionDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Player Position By Id",
    Description = "Admin Get PlayerPosition By Id",
    OperationId = "Admin.GetPlayerPosition",
    Tags = new[] {"Player Position Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetPositionByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetPositionByIdEvent(request.PositionId), cancellationToken);
}
