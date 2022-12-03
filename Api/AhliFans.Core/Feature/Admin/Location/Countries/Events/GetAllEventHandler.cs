using AhliFans.Core.Feature.Admin.Location.Countries.DTO;
using AhliFans.Core.Feature.Admin.Location.Countries.Specifications;
using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Location.Countries.Events;

public class GetAllEventHandler: IRequestHandler<GetAllCountriesEvent, ActionResult>
{
  private readonly IRepository<Country> _countryRepository;
  public GetAllEventHandler(IRepository<Country> countryRepository)
  {
    _countryRepository = countryRepository;
  }
  public async Task<ActionResult> Handle(GetAllCountriesEvent request, CancellationToken cancellationToken)
  {
    var countries = await _countryRepository.ListAsync(new GetCountries(request.Name), cancellationToken);
    if (countries.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    var dto = countries.Select(c => new CountriesDto(c.Id, request.Lang == Languages.En ? c.Name : c.NameAr));
    return new OkObjectResult(dto);
  }
}
