using System.Security.Claims;
using AhliFans.Core.Feature.Admin.MediaPhoto.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace AhliFans.WebApi.Area.Admin.MediaPhoto.Edit;

public class EditPhotoEndPoint : EndpointBaseAsync
  .WithRequest<EditPhotoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditPhotoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(EditPhotoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update Phot",
    Description = "Admin Update Phot",
    OperationId = "Admin.UpdatePhot",
    Tags = new[] { "Phot Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] EditPhotoRequest request,
    CancellationToken cancellationToken = default) =>
   await _mediator.Send(
      new EditPhotoEvent(request.PhotoId, request.SeasonId, request.Month, request.PhotoLink, request.MatchId, request.LeagueId,
      request.Description, request.DescriptionAr, request.PlayerId, request.CoachId, request.CategoryId, request.IsExclusiveContent,User.FindFirstValue("User Id")), cancellationToken);
}
