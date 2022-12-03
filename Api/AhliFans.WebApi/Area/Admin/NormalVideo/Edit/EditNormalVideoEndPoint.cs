using System.Security.Claims;
using AhliFans.Core.Feature.Admin.NormalVideo.Edit.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace AhliFans.WebApi.Area.Admin.NormalVideo.Edit;

public class EditNormalVideoEndPoint : EndpointBaseAsync
  .WithRequest<EditNormalVideoRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public EditNormalVideoEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(EditNormalVideoRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update NormalVideo",
    Description = "Admin Update NormalVideo",
    OperationId = "Admin.UpdateNormalVideo",
    Tags = new[] { "NormalVideo Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] EditNormalVideoRequest request,
    CancellationToken cancellationToken = default) =>
   await _mediator.Send(
      new EditNormalVideoEvent(request.NormalVideoId, request.SeasonId, request.Month, request.VideoURL, request.MatchId, request.LeagueId,
      request.Description, request.DescriptionAr, request.PlayerId, request.CoachId, request.CategoryId, User.FindFirstValue("User Id")), cancellationToken);

}
