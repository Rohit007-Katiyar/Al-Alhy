using AhliFans.Core.Feature.Admin.Match;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match;

public class GetVideoByIdEndPoint: EndpointBaseAsync
  .WithRequest<GetVideoByIdRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetVideoByIdEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [AllowAnonymous]
  [HttpGet(GetVideoByIdRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Match Media Video By Id",
    Description = "Admin Get Match Media Video By Id",
    OperationId = "Admin.GetMediaVideo",
    Tags = new[] {"Match Media Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] GetVideoByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetMatchVideoEvent(request.VideoId), cancellationToken);
}
