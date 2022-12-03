using System.Security.Claims;
using AhliFans.Core.Feature.Admin.Jersey.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Jersey;

public class AddJerseyEndPoint : EndpointBaseAsync
  .WithRequest<AddJerseyRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddJerseyEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddJerseyRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Jersey",
    Description = "Admin Add Jersey",
    OperationId = "Admin.AddJersey",
    Tags = new[] { "Jersey Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] AddJerseyRequest request, CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddJerseyEvent(request.Picture, request.IsHome, User.FindFirstValue("User Id")), cancellationToken);

}
