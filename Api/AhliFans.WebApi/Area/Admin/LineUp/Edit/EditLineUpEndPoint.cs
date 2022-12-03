using AhliFans.Core.Feature.Admin.LineUp.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public class EditLineUpEndPoint : EndpointBaseAsync
  .WithRequest<EditLineUpRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditLineUpEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(EditLineUpRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Edit LineUp",
    Description = "Admin Edit LineUp",
    OperationId = "Admin.EditLineUp",
    Tags = new[] {"LineUp Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync(EditLineUpRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(
      new EditLineUpEvent(request.MatchId, request.PlayersList, request.PositionList, request.IsSubstitute),
      cancellationToken);
}
