using AhliFans.Core.Feature.Admin.Stadium.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Stadium;

public class ChangeStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Stadium",
    Description = "Admin Delete/Retrieve Stadium",
    OperationId = "Admin.ChangeStatusStadium",
    Tags = new[] { "Stadium Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]ChangeStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeStadiumStatusEvent(request.StadiumId),cancellationToken);
}
