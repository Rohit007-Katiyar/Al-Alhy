using AhliFans.Core.Feature.Admin.Match.ChangeAvailability.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

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
    Summary = "Admin Change Availability Match",
    Description = "Admin Disable/Active Match",
    OperationId = "Admin.ChangeAvailabilityMatch",
    Tags = new[] {"Match Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]ChangeAvailabilityRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeMatchAvailabilityEvent(request.MatchId), cancellationToken);
}
