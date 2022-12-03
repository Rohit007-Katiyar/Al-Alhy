using AhliFans.Core.Feature.Admin.Coach.Honor.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.Honor.ChangeStatus;

public class ChangeHonorStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeHonorStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeHonorStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeHonorStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Coach Honor",
    Description = "Admin Change Status Coach Honor",
    OperationId = "Admin.ChangeStatusCoachHonor",
    Tags = new[] { "Coach Honor Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]ChangeHonorStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeCoachHonorStatusEvent(request.HonorId), cancellationToken);
}
