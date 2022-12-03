using AhliFans.Core.Feature.Admin.Location.Cities.DTO;
using AhliFans.Core.Feature.Admin.Location.Cities.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Locations;

public class GetAllCitiesEndPoint : EndpointBaseAsync
  .WithRequest<GetAllCitiesRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllCitiesEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [AllowAnonymous]
  [HttpGet(GetAllCitiesRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<CitiesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin get all Cities",
    Description = "List of ALl Cities In Arabic or English, Its Flag, Call Code And Filter By Name",
    OperationId = "Admin.GetAllCities",
    Tags = new[] { "Location Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllCitiesRequest request,
    CancellationToken cancellationToken = default) =>
    await _mediator.Send(new GetAllCitiesEvent(request.CountryId,request.Lang,request.Name), cancellationToken);
}
