using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.SocialMediaAccounts.Edit;

public class EditCoachAccountEndPoint : EndpointBaseAsync
  .WithRequest<EditCoachAccountRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditCoachAccountEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditCoachAccountRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Coach Account",
    Description = "Admin Edit Coach Account",
    OperationId = "Admin.EditCoachAccount",
    Tags = new[] { "Coach Social Media Accounts Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditCoachAccountRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditCoachAccountEvent(request.CoachId, request.FaceBookAccount,request.InstaAccount,request.TwitterAccount), cancellationToken);
}
