using AhliFans.Core.Feature.Security.Enums;
using AhliFans.Core.Feature.Security.LinkSocialMedia.Fan.Gmail;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.Account.LinkSocialMedia.LinkGmail;

public class LinkGmailEndPoint : EndpointBaseAsync
  .WithRequest<LinkGmailRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public LinkGmailEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(LinkGmailRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FanResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client link his gmail account",
    Description = "Client link his gmail account ",
    OperationId = "Client.gmailLink",
    Tags = new[] {"Client Account Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(LinkGmailRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new LinkGmailEvent(request.Email), cancellationToken);
}
