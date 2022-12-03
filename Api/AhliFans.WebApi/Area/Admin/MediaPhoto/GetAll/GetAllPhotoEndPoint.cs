using System.Web;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.DTO;
using AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.GetAll;

public class GetAllPhotoEndPoint : EndpointBaseAsync
  .WithRequest<GetAllPhotoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllPhotoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetAllPhotoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<PhotoDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Photo",
    Description = "Admin Get All Photo",
    OperationId = "Admin.AllPhotos",
    Tags = new[] { "Photo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery] GetAllPhotoRequest request,
    CancellationToken cancellationToken = default)
  {
    var decodedWord = HttpUtility.UrlDecode(request.SearchWord);
    return await _mediator.Send(new GetAllPhotoEvent(decodedWord, request.Lang, request.PageIndex, request.PageSize, request.IsDeleted),
      cancellationToken);
  }

}
