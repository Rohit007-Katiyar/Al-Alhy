using AhliFans.Core.Feature.Admin.Trophy.Image.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy.Image;

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
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Trophy Image By Id",
    Description = "Admin Get Trophy Image By Id",
    OperationId = "Admin.GetTrophyImage",
    Tags = new[] { "Trophy Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute]GetImageRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetTrophyImageEvent(request.TrophyId), cancellationToken);
}
