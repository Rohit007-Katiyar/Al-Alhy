using AhliFans.Core.Feature.Fan.Profile.Image.Update.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Profile;

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
  [HttpPatch(UpdateImageRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Fan Update Profile Photo",
    Description = "Fan Update Profile Photo in Al-Ahly",
    OperationId = "Client.UpdatePhoto",
    Tags = new[] { "Fan Profile Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] UpdateImageRequest request,
    CancellationToken cancellationToken = default)
    => await _mediator.Send(new UpdateImageEvent(request.ProfileImage), cancellationToken);
}
