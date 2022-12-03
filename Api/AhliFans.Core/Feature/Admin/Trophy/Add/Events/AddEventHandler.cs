using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.Add.Events;

public class AddEventHandler:IRequestHandler<AddTrophyEvent,ActionResult>
{
  private readonly IRepository<Entities.Trophy> _trophyRepository;
  private readonly IRepository<TrophyHistory> _trophyHistoryRepository;
  private readonly IMapper _mapper;
  private readonly string _userId;
  private readonly IFileManager _fileManager;
  public AddEventHandler(IHttpContextAccessor context, IRepository<Entities.Trophy> trophyRepository, IMapper mapper, IFileManager fileManager, IRepository<TrophyHistory> trophyHistoryRepository)
  {
    _trophyRepository = trophyRepository;
    _mapper = mapper;
    _fileManager = fileManager;
    _trophyHistoryRepository = trophyHistoryRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(AddTrophyEvent request, CancellationToken cancellationToken)
  {
    var trophy = _mapper.Map<Entities.Trophy>(request);
    trophy.CreatedBy = Guid.Parse(_userId);

    await _trophyRepository.AddAsync(trophy,cancellationToken);
    await _trophyRepository.SaveChangesAsync(cancellationToken);
    await SaveTrophyHistory(trophy.Id,request.HistoryYears);

    bool saveProfile = await SavePic(request.Picture, trophy.Id);
    if (!saveProfile) return new OkObjectResult(new AdminResponse("New Trophy has been added successfully,but saving Pic failure .", ResponseStatus.Warning));

    return new OkObjectResult(new AdminResponse("New Trophy has been added successfully", ResponseStatus.Success));
  }

  private async Task SaveTrophyHistory(int trophyId,List<int> years)
  {
    foreach (var year in years)
    {
      await _trophyHistoryRepository.AddAsync(new TrophyHistory(){Date = DateTime.Now,TrophyId = trophyId,Year = year});
      await _trophyHistoryRepository.SaveChangesAsync();
    }
  }
  private async Task<bool> SavePic(IFormFile? request, int trophyId)
  {
    if (request is null)
    {
      return true;
    }
    bool saveProfile = await _fileManager.SaveFileAsync<Entities.Trophy>(request,
      request.FileName, trophyId.ToString());
    return saveProfile;
  }
}
