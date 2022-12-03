using AhliFans.DTO;
using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Admin.DynamicModules.GetAllLegend.Specifications;

public sealed class GetAllLegendData : Specification<Entities.DynamicModules>, ISingleResultSpecification
{
    public GetAllLegendData(GetDataByModuleType model)
    {
        Query
          .Where(x => x.ModuleType == model.ModuleType)
          .Where(x => x.SectionType == model.SectionType);
    }
}
