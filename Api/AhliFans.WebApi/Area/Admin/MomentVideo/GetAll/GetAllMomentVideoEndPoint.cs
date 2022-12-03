using System.Web;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.DTO;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Events;
using AhliFans.Core.Feature.Admin.MomentVideo.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MomentVideo.GetAll;

public class GetAllMomentVideoEndPoint : EndpointBaseAsync
  .WithRequest<GetAllMomentVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllMomentVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetAllMomentVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<PhotoDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All MomentVideo",
    Description = "Admin Get All MomentVideo",
    OperationId = "Admin.AllMomentVideo",
    Tags = new[] { "MomentVideo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllMomentVideoRequest request,
    CancellationToken cancellationToken = default)
  {
    var decodedWord = HttpUtility.UrlDecode(request.SearchWord);
    return await _mediator.Send(new GetAllMomentVideoEvent(decodedWord, request.Lang, request.PageIndex, request.PageSize, request.IsDeleted),
      cancellationToken);
  }
}
