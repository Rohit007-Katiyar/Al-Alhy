using AhliFans.Core.Feature.Admin.Trophy.ChangeAvailability.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy;

public class ChangeAvailabilityEndPoint :EndpointBaseAsync
  .WithRequest<ChangeAvailabilityRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeAvailabilityEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeAvailabilityRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Availability Trophy",
    Description = "Admin Disable/Active Trophy",
    OperationId = "Admin.ChangeAvailabilityTrophy",
    Tags = new[] { "Trophy Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]ChangeAvailabilityRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeTrophyAvailabilityEvent(request.MatchId), cancellationToken);
}
