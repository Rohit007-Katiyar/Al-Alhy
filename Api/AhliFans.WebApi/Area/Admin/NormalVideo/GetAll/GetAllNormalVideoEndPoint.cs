using System.Web;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.DTO;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Events;
using AhliFans.Core.Feature.Admin.NormalVideo.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.NormalVideo.GetAll;

public class GetAllNormalVideoEndPoint : EndpointBaseAsync
  .WithRequest<GetAllNormalVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllNormalVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetAllNormalVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<PhotoDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All NormalVideo",
    Description = "Admin Get All NormalVideo",
    OperationId = "Admin.AllNormalVideo",
    Tags = new[] { "NormalVideo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllNormalVideoRequest request,
    CancellationToken cancellationToken = default)
  {
    var decodedWord = HttpUtility.UrlDecode(request.SearchWord);
    return await _mediator.Send(new GetAllNormalVideoEvent(decodedWord, request.Lang, request.PageIndex, request.PageSize, request.IsDeleted),
      cancellationToken);
  }
}
