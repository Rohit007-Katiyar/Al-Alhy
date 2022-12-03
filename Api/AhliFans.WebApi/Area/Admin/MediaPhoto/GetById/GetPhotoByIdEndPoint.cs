using AhliFans.Core.Feature.Admin.MediaPhoto.GetById.DTO;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.GetById;

public class GetPhotoByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetPhotoByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetPhotoByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetPhotoByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PhotoDetailsDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Photo by Id",
    Description = "Admin Get Photo by Id",
    OperationId = "Admin.GetPhoto",
    Tags = new[] { "Photo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetPhotoByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetPhotoByIdEvent(request.PhotoId, request.Lang), cancellationToken);
}
