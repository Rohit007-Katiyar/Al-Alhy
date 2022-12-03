using System.Text;
using AhliFans.Core.Feature.Admin.Match.Media.Images.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Match.Media.Images.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Match.Media.Images.GetAll;

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
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<MediaImagesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get Match Media Images",
    Description = "Admin Get Match Media Images",
    OperationId = "Admin.GetMediaImages",
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
