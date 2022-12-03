using AhliFans.Core.Feature.Admin.Moment;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Moment;

public class UpdateVideoEndPoint : EndpointBaseAsync
  .WithRequest<UpdateVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public UpdateVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(UpdateVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update Moment Video By Id",
    Description = "Admin Moment Player Video By Id",
    OperationId = "Admin.UpdateMomentVideo",
    Tags = new[] { "Moment Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] UpdateVideoRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new UpdateViedoEvent(request.MomentId,request.MomentVideo), cancellationToken);
}
