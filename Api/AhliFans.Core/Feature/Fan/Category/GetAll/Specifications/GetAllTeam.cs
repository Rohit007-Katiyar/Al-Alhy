using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.Specifications;
public class GetAllTeam : Specification<Entities.Team>
{
  public GetAllTeam()
  {
    if (true)
    {
      Query
       .OrderByDescending(x => x.Id);
    }
  }
}
