using AhliFans.Core.Feature.Admin.Match.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

public class ChangeMatchStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeMatchStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Match",
    Description = "Admin Delete/Retrieve Match",
    OperationId = "Admin.ChangeStatusMatch",
    Tags = new[] { "Match Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeMatchStatusEvent(request.MatchId), cancellationToken);
}
