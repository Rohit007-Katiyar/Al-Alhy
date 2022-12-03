using AhliFans.Core.Feature.Admin.Coach.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach;

public class ChangeStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeCoachStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPatch(ChangeCoachStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Coach",
    Description = "Admin Delete/Retrieve Coach",
    OperationId = "Admin.ChangeStatusCoach",
    Tags = new[] { "Coach Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeCoachStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeCoachStatusEvent(request.CoachId), cancellationToken);
}
