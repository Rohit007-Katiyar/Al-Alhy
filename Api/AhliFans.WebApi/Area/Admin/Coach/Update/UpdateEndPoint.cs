using AhliFans.Core.Feature.Admin.Coach.Update.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach;

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
    Summary = "Admin Update Coach",
    Description = "Admin Update Coach",
    OperationId = "Admin.UpdateCoach",
    Tags = new[] { "Coach Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm] UpdateRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(
      new UpdateCoachEvent(request.CoachId,request.NationalityId,request.CountryId, request.CityId, request.TitleId, request.FirstName, request.FirstNameAr,
        request.LastName, request.LastNameAr, request.BirthDate, request.DateSigned, request.Biography,
        request.BiographyAr, request.IsCurrent, request.TeamCategoryId,request.FaceBookAccount,request.InstaAccount,
        request.TwitterAccount), cancellationToken);
}
