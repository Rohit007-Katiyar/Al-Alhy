using AhliFans.Core.Feature.Admin.Jersey.Image.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Jersey.Image;

public class GetImageEndPoint : EndpointBaseAsync
  .WithRequest<GetImageRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetImageEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetImageRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IFormFile))]
  [SwaggerOperation(
    Summary = "Admin Get Jersey Image By Id",
    Description = "Admin Get Jersey Image By Id",
    OperationId = "Admin.GetJerseyImage",
    Tags = new[] { "Jersey Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetImageRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetJerseyImageEvent(request.JerseyId), cancellationToken);
}
