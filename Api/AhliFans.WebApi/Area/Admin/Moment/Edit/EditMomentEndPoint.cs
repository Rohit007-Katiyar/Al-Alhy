using AhliFans.Core.Feature.Admin.Moment.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Moment.Edit;

public class EditMomentEndPoint : EndpointBaseAsync
  .WithRequest<EditMomentRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditMomentEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditMomentRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit Moment",
    Description = "Admin Edit Moment",
    OperationId = "Admin.EditMoment",
    Tags = new[] { "Moment Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]EditMomentRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new EditMomentEvent(request.MomentId,request.PlayerId, request.MatchId, request.MomentTime, request.Type, request.VotingStartFrom,
        request.To), cancellationToken);
}
