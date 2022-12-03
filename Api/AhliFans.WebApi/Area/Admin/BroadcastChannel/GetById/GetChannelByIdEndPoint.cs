using AhliFans.Core.Feature.Admin.BroadcastChannel.GetById.DTO;
using AhliFans.Core.Feature.Admin.BroadcastChannel.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.BroadcastChannel.GetById;

public class GetChannelByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetChannelByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetChannelByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpGet(GetChannelByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChannelDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get By Id Broadcast Channel",
    Description = "Admin Get By Id Broadcast Channel",
    OperationId = "Admin.GetByIdBroadcastChannel",
    Tags = new[] {"Broadcast Channel Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetChannelByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetChannelByIdEvent(request.ChannelId),cancellationToken);
}
