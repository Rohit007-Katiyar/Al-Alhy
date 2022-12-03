using AhliFans.Core.Feature.Admin.BroadcastChannel.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.BroadcastChannel.Add;

public class AddChannelEndPoint : EndpointBaseAsync
  .WithRequest<AddChannelRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddChannelEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddChannelRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Broadcast Channel",
    Description = "Admin Add Broadcast Channel",
    OperationId = "Admin.AddBroadcastChannel",
    Tags = new[] { "Broadcast Channel Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(AddChannelRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddChannelEvent(request.Name, request.NameAr), cancellationToken);
}
