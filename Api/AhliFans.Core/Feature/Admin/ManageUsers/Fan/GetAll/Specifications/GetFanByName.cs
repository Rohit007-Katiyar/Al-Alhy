using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetAll.Specifications;
public sealed class GetFanByName : Specification<Security.Entities.Fan>
{
  public GetFanByName(int pageIndex,int pageSize, string searchWord, bool isBlocked)
  {
    if (true)
    {
      Query
        .Where(f=>f.IsBlocked == isBlocked)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(f=>f.RegistrationDate);
    }

    if (!string.IsNullOrEmpty(searchWord))
    {
      Query
        .Where(f => f.FullName.Contains(searchWord) || 
                    f.Email.Contains(searchWord) ||
                    f.PhoneNumber.Contains(searchWord));

    }
   
  }
}
