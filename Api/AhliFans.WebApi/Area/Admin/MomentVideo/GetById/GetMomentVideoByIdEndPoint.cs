using AhliFans.Core.Feature.Admin.MomentVideo.GetById.DTO;
using AhliFans.Core.Feature.Admin.MomentVideo.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MomentVideo.GetById;

public class GetMomentVideoByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetMomentVideoByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetMomentVideoByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetMomentVideoByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MomentVideoDetailsDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get MomentVideo by Id",
    Description = "Admin Get MomentVideo by Id",
    OperationId = "Admin.GetMomentVideo",
    Tags = new[] { "MomentVideo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetMomentVideoByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetMomentVideoByIdEvent(request.MomentVideoId, request.Lang), cancellationToken);

}
