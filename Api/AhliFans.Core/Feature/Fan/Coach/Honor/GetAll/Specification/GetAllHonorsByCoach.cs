using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Coach.Honor.GetAll.Specification;

public sealed class GetAllHonorsByCoach : Specification<Entities.Honor>
{
  public GetAllHonorsByCoach(int coachId,int trophyTypeId, int pageIndex, int pageSize,bool isDeleted)
  {
    Query
      .Include(x=>x.Trophy)
      .Where(x => x.CoachId == coachId && x.IsDeleted == isDeleted && x.Trophy.TrophyTypeId == trophyTypeId)
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);

  }
}
