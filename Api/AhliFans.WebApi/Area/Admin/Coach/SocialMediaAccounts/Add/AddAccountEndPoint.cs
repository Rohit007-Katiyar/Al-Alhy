using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.SocialMediaAccounts.Add;

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
    Summary = "Admin Add Coach Account",
    Description = "Admin Add Coach Account",
    OperationId = "Admin.AddCoachAccount",
    Tags = new[] { "Coach Social Media Accounts Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddAccountRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddCoachAccountsEvent(request.CoachId, request.FaceBookAccount,request.InstaAccount,request.TwitterAccount), cancellationToken);
}
