using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public class AvailabilityEndPoint : EndpointBaseAsync
  .WithRequest<AvailabilityRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AvailabilityEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(AvailabilityRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Super Admin Change Other Admins Status",
    Description = "Super Admin can active them or deactivate",
    OperationId = "Admin.AdminAvailability",
    Tags = new[] { "SubAdmin Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]AvailabilityRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new ChangeAdminStatusEvent(request.AdminId), cancellationToken);
}
