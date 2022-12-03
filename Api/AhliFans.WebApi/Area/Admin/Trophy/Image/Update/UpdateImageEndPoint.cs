using AhliFans.Core.Feature.Admin.Trophy.Image.Update.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy.Image;

public class UpdateImageEndPoint : EndpointBaseAsync
  .WithRequest<UpdateImageRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public UpdateImageEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(UpdateImageRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update Trophy Image By Id",
    Description = "Admin Update Trophy Image By Id",
    OperationId = "Admin.UpdateTrophyImage",
    Tags = new[] { "Trophy Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]UpdateImageRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new UpdateImageEvent(request.TrophyId, request.TrophyImage), cancellationToken);
}
