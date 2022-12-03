using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.LinkSocialMedia.Fan.FaceBook;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.LinkSocialMedia.LinkFaceBook;

public class LinkFaceBookEndPoint : EndpointBaseAsync
  .WithRequest<LinkFaceBookRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public LinkFaceBookEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(LinkFaceBookRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client link his facebook account",
    Description = "Client link his facebook account ",
    OperationId = "Client.FBLink",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(LinkFaceBookRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new LinkFaceBookAccountEvent(request.AccessToken), cancellationToken);
}
