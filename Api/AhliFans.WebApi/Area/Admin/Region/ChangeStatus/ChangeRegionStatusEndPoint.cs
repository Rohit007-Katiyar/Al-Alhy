using AhliFans.Core.Feature.Admin.Region.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Region.ChangeStatus;

public class ChangeRegionStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeRegionStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeRegionStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeRegionStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Region",
    Description = "Admin Delete/Retrieve Region",
    OperationId = "Admin.ChangeStatusRegion",
    Tags = new[] {"Region Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(ChangeRegionStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeRegionStatusEvent(request.RegionId), cancellationToken);
}
