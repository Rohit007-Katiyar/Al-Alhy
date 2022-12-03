using AhliFans.Core.Feature.Admin.Referee.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Referee;

public class ChangeRefereeStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeRefereeStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Referee",
    Description = "Admin Delete/Retrieve Referee",
    OperationId = "Admin.ChangeStatusReferee",
    Tags = new[] { "Referee Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]ChangeStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeRefereeStatusEvent(request.RefereeId), cancellationToken);
}
