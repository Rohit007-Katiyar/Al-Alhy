using AhliFans.Core.Feature.Fan.Coach.Honor.Specification;
using AhliFans.Core.Feature.Fan.Coach.Honor.GetAll.DTO;
using AhliFans.Core.Feature.Fan.Coach.Honor.GetAll.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.Honor.GetAll.Events;

public class GetAllCoachHonorsEventHandler : IRequestHandler<GetAllCoachHonorsEvent,ActionResult>
{
  private readonly IRepository<Entities.Honor> _honorRepository;

  public GetAllCoachHonorsEventHandler(IRepository<Entities.Honor> honorRepository)
  {
    _honorRepository = honorRepository;
  }
  public async Task<ActionResult> Handle(GetAllCoachHonorsEvent request, CancellationToken cancellationToken)
  {
    var honors = await _honorRepository.ListAsync(new GetAllHonorsByCoach(request.CoachId,request.TrophyTypeId, request.PageIndex,
      request.PageSize, request.IsDeleted),cancellationToken);
    if (honors.Count == 0) return new OkObjectResult(Enumerable.Empty<CoachHonorsDto>());

    return new OkObjectResult(honors.Select(h => new CoachHonorsDto(h.Id, h.TrophyId,
      request.Lang == Languages.En ? h.Trophy.Name: h.Trophy.NameAr, _honorRepository.CountAsync(new GetHonorsCount(h.TrophyId),cancellationToken).Result)));
  }
}
