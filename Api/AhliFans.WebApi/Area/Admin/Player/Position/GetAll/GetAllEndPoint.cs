using AhliFans.Core.Feature.Admin.Player.Position.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Player.Position.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public class GetAllEndPoint : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetAllRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<PositionsDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Player Position",
    Description = "Admin Get All PlayerPosition",
    OperationId = "Admin.GetAllPlayerPosition",
    Tags = new[] { "Player Position Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllPositionsEvent(request.Lang, request.Name,request.IsDeleted),
      cancellationToken);
}
