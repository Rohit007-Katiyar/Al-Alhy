using System.Web;
using AhliFans.Core.Feature.Admin.Referee.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Referee.GetAll.Events;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Admin.Referee;

public class GetAllEndPoint : EndpointBaseAsync
  .WithRequest<GetAllRequest>
  .WithActionResult
{
  private readonly IMediator _mediator;

  public GetAllEndPoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  [Authorize]
  [HttpGet(GetAllRequest.Route)]
  [ApiExplorerSettings(GroupName = nameof(Areas.Admin))]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<RefereesDto>))]
  [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
  [SwaggerOperation(
    Summary = "Admin Get All Referees",
    Description = "Admin Get All Referees",
    OperationId = "Admin.AllReferees",
    Tags = new[] { "Referee Endpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromQuery]GetAllRequest request,
    CancellationToken cancellationToken = default)
  {
    var decodedWord = HttpUtility.UrlDecode(request.SearchWord);
    return await _mediator.Send(new GetAllRefereesEvent(decodedWord, request.Lang, request.PageIndex, request.PageSize, request.IsDeleted),
      cancellationToken);
  }
    
}
