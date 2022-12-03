using System.Security.Claims;
using AhliFans.Core.Feature.Admin.MediaPhoto.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.Add;

public class AddPhotoEndPoint : EndpointBaseAsync
  .WithRequest<AddPhotoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddPhotoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddPhotoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Photo",
    Description = "Admin Add Photo",
    OperationId = "Admin.AddPhoto",
    Tags = new[] { "Photo Endpoints" })
  ]

  public override async Task<ActionResult> HandleAsync([FromForm] AddPhotoRequest request, CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddPhotoEvent(request.SeasonId, request.Month, request.PhotoLink, request.MatchId, request.LeagueId,
        request.Description, request.DescriptionAr, request.PlayerId, request.CoachId, request.CategoryId, request.IsExclusiveContent,
        request.Photo,User.FindFirstValue("User Id")), cancellationToken);
}

