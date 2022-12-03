using AhliFans.Core.Feature.Admin.Referee.Add.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Referee;

public class AddRefereeEndPoint : EndpointBaseAsync
  .WithRequest<AddRefereeRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public AddRefereeEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpPost(AddRefereeRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Add Referee",
    Description = "Admin Add Referee",
    OperationId = "Admin.AddReferee",
    Tags = new[] { "Referee Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromForm]AddRefereeRequest request, CancellationToken cancellationToken = default)
    => await _mediator.Send(new AddRefereeEvent(request.NationalityId,request.RegionId,request.Name,request.NameAr),
      cancellationToken);
}
