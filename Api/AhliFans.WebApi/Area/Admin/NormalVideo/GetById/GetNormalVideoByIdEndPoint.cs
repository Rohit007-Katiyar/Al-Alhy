using AhliFans.Core.Feature.Admin.NormalVideo.GetById.DTO;
using AhliFans.Core.Feature.Admin.NormalVideo.GetById.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.NormalVideo.GetById;

public class GetNormalVideoByIdEndPoint : EndpointBaseAsync
  .WithRequest<GetNormalVideoByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetNormalVideoByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetNormalVideoByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NormalVideoDto))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get NormalVideo by Id",
    Description = "Admin Get NormalVideo by Id",
    OperationId = "Admin.GetNormalVideo",
    Tags = new[] { "NormalVideo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetNormalVideoByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetNormalVideoByIdEvent(request.NormalVideoId, request.Lang), cancellationToken);

}
