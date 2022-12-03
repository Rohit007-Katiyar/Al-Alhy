using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.GetAll.Specification;

public sealed class GetAllHonorsByCoach : Specification<Entities.Honor>
{
  public GetAllHonorsByCoach(int? coachId, int pageIndex, int pageSize,bool isDeleted)
  {
    if (coachId != null && coachId != 0)
    {
      Query
        .Include(x => x.Trophy)
        .Where(x => x.CoachId == coachId && x.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
    }
    else
    {
      Query
        .Include(x => x.Trophy)
        .Where(x => x.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
    }
  }
}
