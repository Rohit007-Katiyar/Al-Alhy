using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.DynamicModules.GetById;
public class GetByIdEventHandler : IRequestHandler<DTO.GetById, ActionResult>
{
    private readonly IRepository<Entities.DynamicModules> _DynamicModulesRepo;

    public GetByIdEventHandler(IRepository<Entities.DynamicModules> DynamicModulesRepo)
    {
        _DynamicModulesRepo = DynamicModulesRepo;
    }

    public async Task<ActionResult> Handle(DTO.GetById request, CancellationToken cancellationToken)
    {
        var dynamicModules = await _DynamicModulesRepo.GetByIdAsync(request.Id, cancellationToken);
        if (dynamicModules is null)
        {
            return new BadRequestObjectResult(new AdminResponse("Request has been not valid.", ResponseStatus.Error));
        }
        int? applicationType = request.Type;
        var response = ValidateRequest.ValidateRequestPayload(new DTO.DynamicModules
        {
            Id = dynamicModules.Id,
            IsDelete = dynamicModules.IsDeleted,
            ModuleType = dynamicModules.ModuleType,
            Section = dynamicModules.Section,
            SectionType = dynamicModules.SectionType,
        }, applicationType);
        if (request.Type == (int)Areas.Client)
        {
            return new OkObjectResult(response);
        }

        return new OkObjectResult(response);
    }
}
