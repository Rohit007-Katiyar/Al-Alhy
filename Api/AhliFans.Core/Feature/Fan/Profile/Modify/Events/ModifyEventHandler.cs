using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Fan.Profile.Modify.Events;
public class ModifyEventHandler : IRequestHandler<ModifyEvent,ActionResult>
{
  readonly ILogger<ModifyEventHandler> _logger;
  private readonly UserManager<Security.Entities.Fan> _userManager;
  private readonly string _userId;
  private readonly IRepository<Security.Entities.Fan> _fanRepository;

  public ModifyEventHandler(ILogger<ModifyEventHandler> logger, UserManager<Security.Entities.Fan> userManager, IHttpContextAccessor context,IRepository<Security.Entities.Fan> fanRepository)
  {
    _logger = logger;
    _userManager = userManager;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
    _fanRepository = fanRepository;
  }
  public async Task<ActionResult> Handle(ModifyEvent request, CancellationToken cancellationToken)
  {
    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan == null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    
    if (!string.IsNullOrEmpty(request.Email) && _userManager.FindByEmailAsync(request.Email).Result?.Id != null && _userManager.FindByEmailAsync(request.Email).Result?.Id != Guid.Parse(_userId))
    {
      _logger.LogError(request.ToString());
      return new BadRequestObjectResult(new FanResponse("The email is already taken", ResponseStatus.Error));
    }

    if (!string.IsNullOrEmpty(request.PhoneNumber) &&  _fanRepository.GetBySpecAsync(new GetByPhoneNumberWithOtp<Security.Entities.Fan>(request.PhoneNumber),cancellationToken).Result?.Id != null && _fanRepository.GetBySpecAsync(new GetByPhoneNumberWithOtp<Security.Entities.Fan>(request.PhoneNumber), cancellationToken).Result?.Id != Guid.Parse(_userId))
    {
      _logger.LogError(request.ToString());
      return new BadRequestObjectResult(new FanResponse("The Phone Number is already taken", ResponseStatus.Error));
    }
    fan.FullName = request.FullName ?? fan.FullName;
    fan.Gender = request.Gender ?? fan.Gender;
    fan.Email = request.Email ?? fan.Email;
    fan.UserName = request.Email ?? fan.UserName;
    fan.PhoneNumber = request.PhoneNumber ?? fan.PhoneNumber;
    fan.BirthDate = request.DateOfBirth ?? fan.BirthDate;
    fan.CityId = request.CityId ?? fan.CityId;
    await _userManager.UpdateAsync(fan);

    return new OkObjectResult(new FanResponse("Operation done successfully.", ResponseStatus.Success));
  }
}
