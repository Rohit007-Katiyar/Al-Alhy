using AhliFans.Core.Feature.Fan.MatchCenter.Videos;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter.media.Videos;

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
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Match Media Video By Id",
    Description = "Client Get Match Media Video By Id",
    OperationId = "Client.GetMediaVideo",
    Tags = new[] {"Match Media Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute]GetVideoByIdRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetMatchVideoEvent(request.VideoId), cancellationToken);
}
