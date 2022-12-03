using AhliFans.Core.Feature.Fan.Profile.GetById.DTO;
using AhliFans.Core.Feature.Fan.Profile.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Fan.Profile.GetById.Events;
public class GetByIdEventHandler : IRequestHandler<GetByIdEvent,ActionResult>
{
  private readonly ILogger<GetByIdEventHandler> _logger;
  private readonly string _userId;
  private readonly IRepository<Security.Entities.Fan> _userManager;
  public GetByIdEventHandler(ILogger<GetByIdEventHandler> logger, IHttpContextAccessor context, IRepository<Security.Entities.Fan> userManager)
  {
    _logger = logger;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
    _userManager = userManager;
  }
  public async Task<ActionResult> Handle(GetByIdEvent request, CancellationToken cancellationToken)
  {
    var fan = await _userManager.GetBySpecAsync(new GetFanById(Guid.Parse(_userId)),cancellationToken);
    if (fan == null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    _logger.LogInformation($"User{fan.Id} get his profile information");
    return new OkObjectResult(new FanInfoDto(fan.FullName, fan.Email == fan.PhoneNumber+RootAdmin.TempEmail?"":fan.Email, fan.PhoneNumber,
      fan.Gender?.ToString()!, fan.BirthDate.ToString(),request.Lang == Languages.En ? new CityObj(fan.City?.Id ?? 0, fan.City?.Name!) : new CityObj(fan.City?.Id ?? 0, fan.City?.NameAr!),
      request.Lang == Languages.En ? new CountryObj(fan.City?.CountryId ?? 0, fan.City?.Country?.Name!) : new CountryObj(fan.City?.CountryId ?? 0, fan.City?.Country?.NameAr!),fan.LinkedWith));
  }
}
