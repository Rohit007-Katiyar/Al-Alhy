using AhliFans.Core.Feature.Admin.Trophy.Edit.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.Edit.Events;

public class EditEventHandler : IRequestHandler<EditTrophyEvent,ActionResult>
{
  private readonly IRepository<Entities.Trophy> _trophyRepository;
  private readonly IRepository<TrophyHistory> _trophyHistoryRepository;
  private readonly string _userId;
  public EditEventHandler(IHttpContextAccessor context,IRepository<Entities.Trophy> trophyRepository,IRepository<TrophyHistory> trophyHistoryRepository)
  {
    _trophyRepository = trophyRepository;
    _trophyHistoryRepository = trophyHistoryRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(EditTrophyEvent request, CancellationToken cancellationToken)
  {
    var trophy = await _trophyRepository.GetByIdAsync(request.TrophyId,cancellationToken);
    if (trophy == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    if (request.HistoryYears?.Count != 0 && IsDuplicateYear(request.HistoryYears)) return new BadRequestObjectResult(new AdminResponse("You enter the same year more than one time", ResponseStatus.Error));
    
    trophy.TrophyTypeId = request.TrophyTypeId;
    trophy.Name = request.Name ?? trophy.Name;
    trophy.NameAr = request.NameAr ?? trophy.NameAr;
    trophy.ModifiedOn = DateTime.Now;
    trophy.ModifiedBy = Guid.Parse(_userId);

    await _trophyRepository.UpdateAsync(trophy,cancellationToken);
    await _trophyRepository.SaveChangesAsync(cancellationToken);

    if (request.HistoryYears?.Count != 0)
    {
      await DeleteTrophyHistory(trophy.Id);
      await SaveTrophyHistory(trophy.Id,request.HistoryYears);
    }
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
  private async Task SaveTrophyHistory(int trophyId, List<int>? years)
  {
    if (years is not null)
    {
      foreach (var year in years)
      {
        await _trophyHistoryRepository.AddAsync(new TrophyHistory() { Date = DateTime.Now, TrophyId = trophyId, Year = year });
        await _trophyHistoryRepository.SaveChangesAsync();
      }
    }
  }
  private async Task DeleteTrophyHistory(int trophyId)
  {
    var trophyDatesList =
      await _trophyHistoryRepository.ListAsync(new GetAllTrophyYearsByTrophy(trophyId));

    await _trophyHistoryRepository.DeleteRangeAsync(trophyDatesList);
    await _trophyHistoryRepository.SaveChangesAsync();
  }
  private static bool IsDuplicateYear(List<int>? years)
  {
    if (years is null) return false;
   
    HashSet<int> set = new();
    foreach (var year in years)
    {
      if (set.Contains(year))
      {
        return true;
      }

      set.Add(year);
    }
    return false;
  }

}
