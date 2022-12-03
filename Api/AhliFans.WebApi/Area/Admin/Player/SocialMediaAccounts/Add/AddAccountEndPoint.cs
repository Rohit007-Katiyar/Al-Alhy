using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.SocialMediaAccounts.Add;

public class AddAccountEndPoint : EndpointBaseAsync
  .WithRequest<AddAccountRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddAccountEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddAccountRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Player Account",
    Description = "Admin Add Player Account",
    OperationId = "Admin.AddPlayerAccount",
    Tags = new[] {"Player Social Media Accounts Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddAccountRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddPlayerAccountsEvent(request.PlayerId, request.FaceBookAccount,request.InstaAccount,request.TwitterAccount), cancellationToken);
}
