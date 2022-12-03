using System.Security.Claims;
using AhliFans.Core.Feature.Admin.Jersey.ChangeStatus.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public class ChangeJerseyStatusEndPoint : EndpointBaseAsync
  .WithRequest<ChangeJerseyStatusRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public ChangeJerseyStatusEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPatch(ChangeJerseyStatusRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Change Status Jersey",
    Description = "Admin Delete/Retrieve Jersey",
    OperationId = "Admin.ChangeStatusJersey",
    Tags = new[] { "Jersey Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] ChangeJerseyStatusRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new ChangeJerseyStatusEvent(request.JerseyId, User.FindFirstValue("User Id")), cancellationToken);
  }
}
