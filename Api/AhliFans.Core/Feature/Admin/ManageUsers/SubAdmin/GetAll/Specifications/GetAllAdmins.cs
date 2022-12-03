using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetAll.Specifications;
public sealed class GetAllAdmins : Specification<Security.Entities.Admin>
{
  public GetAllAdmins(int pageIndex, int pageSize, bool isBlocked, string name, string email, string phoneNumber)
  {
    if (true)
    {
      Query
        .Include(x=>x.UserCreate)
        .Include(x=>x.UserModify)
        .Where(a=>a.IsBlocked == isBlocked && !a.IsSuperAdmin)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
    }
    if (!string.IsNullOrEmpty(email))
    {
      Query
        .Where(a => a.Email.Contains(email));
    }
    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(a => a.FullName.Contains(name));
    }
    if (!string.IsNullOrEmpty(phoneNumber))
    {
      Query
        .Where(a => a.PhoneNumber.Contains(phoneNumber));
    }
   
  }
}
