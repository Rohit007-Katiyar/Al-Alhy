using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Category.Add.Specifications;

public sealed class IsCategoryExist : Specification<Entities.Category>
{
  public IsCategoryExist(int CategoryId,string categoryName, string categoryNameAr)
  {
    if(CategoryId==0)
    {
      Query
      .Where(s => s.Name == categoryName || s.NameAr == categoryNameAr);
    }
    else
    {
      Query
     .Where(s => (s.Name == categoryName || s.NameAr == categoryNameAr) && s.Id!= CategoryId);
    }
   
  }
}
