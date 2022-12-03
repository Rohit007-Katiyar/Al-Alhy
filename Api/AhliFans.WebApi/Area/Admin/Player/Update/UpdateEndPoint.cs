using AhliFans.Core.Feature.Admin.Player.Update.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Player.Update;

public class UpdateEndPoint : EndpointBaseAsync
  .WithRequest<UpdateRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public UpdateEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPut(UpdateRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Update Player",
    Description = "Admin Update Player",
    OperationId = "Admin.UpdatePlayer",
    Tags = new[] { "Player Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] UpdateRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new UpdatePlayerEvent(request.PlayerId, request.PositionId, request.Number, request.Name,
        request.NameAr, request.BirthDate, request.Height, request.Weight,request.CityOfBirth, request.Biography, 
        request.BiographyAr,request.DateSigned, request.TeamCategoryId,request.FaceBookAccount,request.InstaAccount,request.TwitterAccount), cancellationToken);
}
