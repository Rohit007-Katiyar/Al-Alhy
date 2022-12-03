using AhliFans.Core.Feature.Fan.Profile.Image.Get.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Profile;

public class GetProfileImageEndPoint : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetProfileImageEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetProfileImageRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IFormFile))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Fan Get his Profile Image",
    Description = "Fan Get his Profile Image Al-Ahly",
    OperationId = "Client.ProfileImage",
    Tags = new[] { "Fan Profile Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetProfileImageEvent(), cancellationToken);
}
