using System.Text;
using AhliFans.Core.Feature.Fan.MatchCenter;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.MatchCenter;

public class GetAllImagesEndPoint : EndpointBaseAsync
  .WithRequest<GetAllImagesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllImagesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetAllImagesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MediaImagesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(FanResponse))]
  [SwaggerOperation(
    Summary = "Client Get Match Media Images",
    Description = "Client Get Match Media Images",
    OperationId = "Client.GetMediaImages",
    Tags = new[] { "Match Media Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllImagesRequest request, CancellationToken cancellationToken = default)
  {
    var imageBaseUrl = new StringBuilder(Request.Scheme).Append("://")
      .Append(Request.Host)
      .Append(Request.PathBase.ToString()).Append("/")
      .Append(GetImageByIdRequest.Route.Replace("{ImageId}", ""))
      .ToString();
    return await _mediator.Send(new GetAllMatchImagesEvent(request.MatchId,imageBaseUrl),cancellationToken);
  }
}
