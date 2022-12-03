using AhliFans.Core.Feature.Fan.Location.Cities.DTO;
using AhliFans.Core.Feature.Fan.Location.Cities.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Location.Cities.Events;

public class GetAllEventHandler : IRequestHandler<GetAllCitiesEvent,ActionResult>
{
  private readonly IRepository<City> _cityRepository;

  public GetAllEventHandler(IRepository<City> cityRepository)
  {
    _cityRepository = cityRepository;
  }
  public async Task<ActionResult> Handle(GetAllCitiesEvent request, CancellationToken cancellationToken)
  {
    var cities = await _cityRepository.ListAsync(new GetAllCities(request.CountryId, request.Name),cancellationToken);
    if (cities.Count == 0) return new OkObjectResult(Enumerable.Empty<CitiesDto>());

    var dto = cities.Select(c => new CitiesDto(c.Id, request.Lang == Languages.En ? c.Name : c.NameAr));
    return new OkObjectResult(dto);
  }
}
