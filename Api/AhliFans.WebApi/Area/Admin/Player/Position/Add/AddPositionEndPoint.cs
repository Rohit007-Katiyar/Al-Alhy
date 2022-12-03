using AhliFans.Core.Feature.Admin.Player.Position.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public class AddPositionEndPoint : EndpointBaseAsync
  .WithRequest<AddPositionRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddPositionEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(AddPositionRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Player Position",
    Description = "Admin Add PlayerPosition",
    OperationId = "Admin.AddPlayerPosition",
    Tags = new[] { "Player Position Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddPositionRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddPositionEvent(request.Name,request.NameAr,request.Symbol, request.GeneralPositionId), cancellationToken);
}
