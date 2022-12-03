using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.SocialMediaAccounts.ChangeStatus;

public class ChangeAccountStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeAccountStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeAccountStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeAccountStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Coach Account Status",
    Description = "Admin Change Coach Account Status",
    OperationId = "Admin.ChangeCoachAccountStatus",
    Tags = new[] { "Coach Social Media Accounts Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]ChangeAccountStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeAccountStatusEvent(request.AccountId),cancellationToken);
}
