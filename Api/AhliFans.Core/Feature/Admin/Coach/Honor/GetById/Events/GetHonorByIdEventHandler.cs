using AhliFans.Core.Feature.Admin.Coach.Honor.GetById.DTO;
using AhliFans.Core.Feature.Admin.Coach.Honor.GetById.Specification;
using AhliFans.Core.Feature.Admin.Coach.Honor.Specification;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.GetById.Events;

public class GetHonorByIdEventHandler : IRequestHandler<GetHonorByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Honor> _honorRepository;

  public GetHonorByIdEventHandler(IRepository<Entities.Honor> honorRepository)
  {
    _honorRepository = honorRepository;
  }
  public async Task<ActionResult> Handle(GetHonorByIdEvent request, CancellationToken cancellationToken)
  {
    var honor = await _honorRepository.GetBySpecAsync(new GetHonorById(request.HonorId),cancellationToken);
    if (honor == null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new CoachHonorDto(honor.Id,honor.Trophy.TrophyTypeId,honor.TrophyId, 
      request.Lang == Languages.En ? honor.Trophy.Name : honor.Trophy.NameAr,honor.IsPersonal, 
      _honorRepository.CountAsync(new GetHonorsCount(honor.TrophyId), cancellationToken).Result));
  }
}
