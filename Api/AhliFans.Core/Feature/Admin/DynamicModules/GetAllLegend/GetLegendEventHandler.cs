using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using AhliFans.Core.Feature.Admin.DynamicModules.GetAllLegend.Specifications;

namespace AhliFans.Core.Feature.Admin.DynamicModules.GetAllLegend;

public class GetLegendEventHandler : IRequestHandler<DTO.GetDataByModuleType, ActionResult>
{
    private readonly IRepository<Entities.DynamicModules> _DynamicModulesRepo;

    public GetLegendEventHandler(IRepository<Entities.DynamicModules> DynamicModulesRepo)
    {
        _DynamicModulesRepo = DynamicModulesRepo;
    }
    public async Task<ActionResult> Handle(DTO.GetDataByModuleType request, CancellationToken cancellationToken)
    {
        var dynamicModules = await _DynamicModulesRepo.ListAsync(new GetAllLegendData(request));
        if (dynamicModules is null)
        {
            return new BadRequestObjectResult(new AdminResponse("Request has been not valid.", ResponseStatus.Error));
        }
        int? applicationType = request.Type;

        DTO.LegendsBirthdaysDto DataMisalignedException = new DTO.LegendsBirthdaysDto();
        foreach (var item in dynamicModules)
        {
            var response = ValidateRequest.ValidateOnThisDay(new DTO.DynamicModules
            {
                Id = item.Id,
                IsDelete = item.IsDeleted,
                ModuleType = item.ModuleType,
                Section = item.Section,
                SectionType = item.SectionType,
            }, applicationType);
            DataMisalignedException.data.Add(response);
        }
        DataMisalignedException.title = "Legends Birthdays";
        DataMisalignedException.type = "birthday";
        if (request.Type == (int)Areas.Client)
        {
            return new OkObjectResult(DataMisalignedException);
            //return new OkObjectResult(new
            //{
            //    Message = "",
            //    StatusCode = 200,
            //    Data = DataMisalignedException
            //});
        }

        return new OkObjectResult(dynamicModules);
    }
}

