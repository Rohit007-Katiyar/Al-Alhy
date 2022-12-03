using System.Text;
using AhliFans.Core.Feature.Fan.MatchCenter.Videos;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter.media.Videos;

public class GetAllVideoEndPoint : EndpointBaseAsync
  .WithRequest<GetAllVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetAllVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MediaVideosDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Match Media Videos",
    Description = "Client Get Match Media Videos",
    OperationId = "Client.GetMediaVideos",
    Tags = new[] { "Match Media Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllVideoRequest request, CancellationToken cancellationToken = default)
    => await _mediator.Send(new GetAllMatchVideosEvent(request.MatchId),cancellationToken);
  
}
