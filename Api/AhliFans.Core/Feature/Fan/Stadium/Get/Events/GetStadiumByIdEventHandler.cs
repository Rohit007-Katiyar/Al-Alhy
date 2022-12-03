using AhliFans.Core.Feature.Fan.Stadium.Get.Dto;
using AhliFans.Core.Feature.Fan.Stadium.Get.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Stadium.Get.Events;

public class GetStadiumByIdEventHandler : IRequestHandler<GetStadiumByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Stadium> _repository;

  public GetStadiumByIdEventHandler(IRepository<Entities.Stadium> repository)
  {
    _repository = repository;
  }

  public async Task<ActionResult> Handle(GetStadiumByIdEvent request, CancellationToken cancellationToken)
  {
    var stadium = await _repository.GetBySpecAsync(new GetStadiumByIdSpec(request.StadiumId), cancellationToken);
    if (stadium == null)
    {
      return new NotFoundResult();
    }

    var locationSplit = stadium.Location?.Split(',') ?? new string[] { string.Empty, string.Empty };
    var latitude = locationSplit[0];
    var longitude = locationSplit[1];
    var isArabic = request.Language == Languages.Ar;

    var dto = new StadiumDto
    {
      Id = stadium.Id,
      Latitude = latitude,
      Longitude = longitude,
      Name = isArabic ? stadium.NameAr : stadium.Name,
      RegionId = stadium.Region?.Id ?? 0,
      RegionName = isArabic ? stadium.Region?.NameAr ?? string.Empty : stadium.Region?.Name ?? string.Empty
    };

    return new OkObjectResult(dto);
  }
}
