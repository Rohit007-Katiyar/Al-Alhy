using AhliFans.Core.Feature.Admin.Player.GetById.DTO;
using AhliFans.Core.Feature.Admin.Player.Image.Update.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.Image;

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
    Summary = "Admin Update Player Image By His Id",
    Description = "Admin Update Player Image By His Id",
    OperationId = "Admin.UpdatePlayerImage",
    Tags = new[] { "Player Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]UpdateImageRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new UpdateImageEvent(request.PlayerId,request.PlayerImage), cancellationToken);
}
