using AhliFans.Core.Feature.Admin.MediaPhoto.Image.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.Image.Get;

public class GetMediaPhotoImageEndPoint : EndpointBaseAsync
  .WithRequest<GetMediaPhotoImageRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetMediaPhotoImageEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetMediaPhotoImageRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IFormFile))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Photo Image By His Id",
    Description = "Admin Get Photo Image By His Id",
    OperationId = "Admin.GetPhotoImage",
    Tags = new[] { "Photo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetMediaPhotoImageRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetMediaPhotoImageEvent(request.PhotoId), cancellationToken);
}
