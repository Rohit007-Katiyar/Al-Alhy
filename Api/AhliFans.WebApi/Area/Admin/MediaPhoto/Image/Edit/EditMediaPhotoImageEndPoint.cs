using AhliFans.Core.Feature.Admin.MediaPhoto.Image.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.Image.Edit;

public class EditMediaPhotoImageEndPoint : EndpointBaseAsync
  .WithRequest<EditMediaPhotoImageRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;
  public EditMediaPhotoImageEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(EditMediaPhotoImageRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update Photo Image By His Id",
    Description = "Admin Update Photo Image By His Id",
    OperationId = "Admin.UpdatePhotoImage",
    Tags = new[] { "Photo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] EditMediaPhotoImageRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new UpdateMediaPhotoImageEvent(request.PhotoId, request.PhotoImage), cancellationToken);
}
