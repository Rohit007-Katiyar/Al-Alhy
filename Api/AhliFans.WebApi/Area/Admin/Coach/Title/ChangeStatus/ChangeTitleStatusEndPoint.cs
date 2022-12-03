using AhliFans.Core.Feature.Admin.Coach.Title.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach.Title;

public class ChangeTitleStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeTitleStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Title",
    Description = "Admin Delete/Retrieve Title",
    OperationId = "Admin.ChangeStatusTitle",
    Tags = new[] { "Coach Titles Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]ChangeStatusRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new ChangeTitleStatusEvent(request.TitleId), cancellationToken);
}
