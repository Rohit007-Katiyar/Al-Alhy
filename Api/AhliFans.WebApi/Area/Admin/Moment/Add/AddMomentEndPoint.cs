using AhliFans.Core.Feature.Admin.Moment.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Moment.Add;

public class AddMomentEndPoint : EndpointBaseAsync
  .WithRequest<AddMomentRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddMomentEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(AddMomentRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Moment",
    Description = "Admin Add Moment",
    OperationId = "Admin.AddMoment",
    Tags = new[] { "Moment Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddMomentRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddMomentEvent(request.PlayerId, request.MatchId, request.MomentTime, request.Type,
      request.MomentVideo, request.VotingStartFrom, request.To), cancellationToken);
}
