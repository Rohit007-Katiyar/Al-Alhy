using AhliFans.Core.Feature.Admin.Player.Position.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public class EditEndPoint : EndpointBaseAsync
  .WithRequest<EditRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(EditRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Player Position",
    Description = "Admin Edit PlayerPosition",
    OperationId = "Admin.EditPlayerPosition",
    Tags = new[] { "Player Position Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditPositionEvent(request.PositionId,request.GeneralPositionId, request.Name, request.NameAr, request.Symbol),
      cancellationToken);
}
