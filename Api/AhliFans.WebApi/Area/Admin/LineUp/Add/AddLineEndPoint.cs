using AhliFans.Core.Feature.Admin.LineUp.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public class AddLineEndPoint : EndpointBaseAsync
  .WithRequest<AddLineUpRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddLineEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddLineUpRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add LineUp",
    Description = "Admin Add LineUp",
    OperationId = "Admin.AddLineUp",
    Tags = new[] {"LineUp Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(AddLineUpRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(
      new AddLineUpEvent(request.PlayersList, request.PositionList,request.MatchId, request.IsSubstitute), cancellationToken);
}
