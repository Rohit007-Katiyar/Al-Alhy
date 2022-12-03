using System.Security.Claims;
using AhliFans.Core.Feature.Admin.NormalVideo.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.NormalVideo.ChangeStatus;

public class ChangeNormalVideoStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeNormalVideoStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeNormalVideoStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPatch(ChangeNormalVideoStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status NormalVideo",
    Description = "Admin Delete/Retrieve NormalVideo",
    OperationId = "Admin.ChangeStatusNormalVideo",
    Tags = new[] { "NormalVideo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeNormalVideoStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeNormalVideoStatusEvent(request.NormalVideoId, User.FindFirstValue("User Id")), cancellationToken);

}
