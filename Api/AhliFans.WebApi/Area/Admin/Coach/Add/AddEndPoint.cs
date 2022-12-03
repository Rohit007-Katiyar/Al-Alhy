using AhliFans.Core.Feature.Admin.Coach.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach;

public class AddEndPoint : EndpointBaseAsync
  .WithRequest<AddRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  [Authorize]
  [HttpPost(AddRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Coach",
    Description = "Admin Add Coach",
    OperationId = "Admin.AddCoach",
    Tags = new[] {"Coach Endpoints"})
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddRequest request, CancellationToken cancellationToken = default) =>
    await _mediator.Send(new AddCoachEvent( request.CityId,request.CountryId, request.TitleId, request.FirstName, request.FirstNameAr,
        request.LastName, request.LastNameAr, request.BirthDate, request.DateSigned, request.Biography,
        request.BiographyAr, request.Pic, request.IsCurrent, request.TeamCategoryId,request.FaceBookAccount,
        request.InstaAccount,request.TwitterAccount),cancellationToken);

}
