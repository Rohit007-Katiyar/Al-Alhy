using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AhliFans.WebApi.Area.Client.DynamicModules.GetAllLegent;
public class GetAllLegend : Controller
{
    private readonly IMediator _mediator;
    public GetAllLegend(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[Authorize]
    [HttpGet($"{DTO.RoutesConfig.ClientGetAllLegent}")]
    [ApiExplorerSettings(GroupName = nameof(Areas.Client))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AdminResponse))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(AdminResponse))]
    [SwaggerOperation(Summary = "Get All Legend Data", Description = "Get All Legend Data",
      OperationId = "Admin.GetDynamicModules", Tags = new[] { "Dynamic Modules Endpoints" })]
    public async Task<ActionResult> Get([FromQuery] DTO.GetDataByModuleType model, CancellationToken cancellationToken = default)
    {
        model.Type = (int)Areas.Client;
        return await _mediator.Send(model, cancellationToken);
    }
}

