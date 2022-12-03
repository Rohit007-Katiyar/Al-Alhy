using AhliFans.Core.Feature.Admin.Trophy.TrophyType.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy.TrophyType;

public class ChangeTrophyStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeTrophyStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeTrophyStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeTrophyStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Trophy Type",
    Description = "Admin Delete/Retrieve Trophy Type",
    OperationId = "Admin.ChangeStatusTrophyType",
    Tags = new[] { "Trophy Type Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeTrophyStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeTrophyTypeStatusEvent(request.TypeId), cancellationToken);
}
