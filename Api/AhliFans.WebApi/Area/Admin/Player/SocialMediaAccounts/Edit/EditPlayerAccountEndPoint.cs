using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.SocialMediaAccounts.Edit;

public class EditPlayerAccountEndPoint : EndpointBaseAsync
  .WithRequest<EditPlayerAccountRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditPlayerAccountEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditPlayerAccountRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Player Account",
    Description = "Admin Edit Player Account",
    OperationId = "Admin.EditPlayerAccount",
    Tags = new[] { "Player Social Media Accounts Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditPlayerAccountRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditPlayerAccountEvent(request.PlayerId, request.FaceBookAccount, request.InstaAccount, request.TwitterAccount), cancellationToken);
}
