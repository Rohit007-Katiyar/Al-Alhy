using System.Security.Claims;
using AhliFans.Core.Feature.Admin.MomentVideo.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace AhliFans.WebApi.Area.Admin.MomentVideo.Edit;

public class EditMomentVideoEndPoint : EndpointBaseAsync
  .WithRequest<EditMomentVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditMomentVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(EditMomentVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update MomentVideo",
    Description = "Admin Update MomentVideo",
    OperationId = "Admin.UpdateMomentVideo",
    Tags = new[] { "MomentVideo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] EditMomentVideoRequest request,
    CancellationToken cancellationToken = default) =>
   await _mediator.Send(
      new EditMomentVideoEvent(request.MomentVideoId, request.SeasonId, request.Month, request.VideoURL, request.MatchId, request.LeagueId,
      request.Description, request.DescriptionAr, request.PlayerId, request.VideoType, request.Time, request.CategoryId, User.FindFirstValue("User Id")), cancellationToken);

}
