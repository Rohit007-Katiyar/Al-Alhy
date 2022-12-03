
using System.Security.Claims;
using AhliFans.Core.Feature.Admin.MediaPhoto.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.ChangeStatus;

public class ChangePhotoStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangePhotoStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangePhotoStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPatch(ChangePhotoStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Photo",
    Description = "Admin Delete/Retrieve Photo",
    OperationId = "Admin.ChangeStatusPhoto",
    Tags = new[] { "Photo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangePhotoStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangePhotoStatusEvent(request.PhotoId,User.FindFirstValue("User Id")), cancellationToken);
}
