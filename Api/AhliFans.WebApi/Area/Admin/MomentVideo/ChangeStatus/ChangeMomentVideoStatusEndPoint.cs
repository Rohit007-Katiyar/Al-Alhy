using System.Security.Claims;
using AhliFans.Core.Feature.Admin.MomentVideo.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MomentVideo.ChangeStatus;

public class ChangeMomentVideoStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeMomentVideoStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeMomentVideoStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPatch(ChangeMomentVideoStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status MomentVideo",
    Description = "Admin Delete/Retrieve MomentVideo",
    OperationId = "Admin.ChangeStatusMomentVideo",
    Tags = new[] { "MomentVideo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeMomentVideoStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeMomentVideoStatusEvent(request.MomentVideoId, User.FindFirstValue("User Id")), cancellationToken);

}
