using System.Security.Claims;
using AhliFans.Core.Feature.Admin.Jersey.Update.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public class UpdateJerseyEndPoint : EndpointBaseAsync
  .WithRequest<UpdateJerseyRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public UpdateJerseyEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPut(UpdateJerseyRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update Jersey",
    Description = "Admin Update Jersey",
    OperationId = "Admin.UpdateJersey",
    Tags = new[] { "Jersey Endpoints" })
  ]
  public async override Task<ActionResult> HandleAsync([FromForm] UpdateJerseyRequest request, CancellationToken cancellationToken = default)
  {
    return await _mediator.Send(new UpdateJerseyEvent(request.JerseyId, request.IsHome, User.FindFirstValue("User Id")), cancellationToken);
  }
}
