using AhliFans.Core.Feature.Admin.Moment;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Moment;

public class ChangeMomentStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeMomentStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPatch(ChangeStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Moment",
    Description = "Admin Delete/Retrieve Moment",
    OperationId = "Admin.ChangeStatusMoment",
    Tags = new[] { "Moment Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeMomentStatusEvent(request.MomentId), cancellationToken);
}
