using AhliFans.Core.Feature.Security.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResetForgetPassword.Fan.Events;

public class FanResetPasswordEventHandler : IRequestHandler<FanResetPasswordEvent,ActionResult>
{
  private readonly UserManager<User> _userManager;
  private readonly FanResetPasswordValidator _validator;
  private readonly string _userId;
  public FanResetPasswordEventHandler(IHttpContextAccessor context,UserManager<User> userManager, FanResetPasswordValidator validator)
  {
    _userManager = userManager;
    _validator = validator;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(FanResetPasswordEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
    {
      return new BadRequestObjectResult(new FanResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan is null) return new BadRequestObjectResult(new FanResponse("User not found", ResponseStatus.Error));
    
    var token = await _userManager.GeneratePasswordResetTokenAsync(fan);
    var result = await _userManager.ResetPasswordAsync(fan, token, request.NewPassword);
    if (!result.Succeeded)
    {
      var errors = result.Errors.Select(x => x.Description).Distinct();

      var enumerable = errors.ToList();
      return new BadRequestObjectResult(new FanResponse(string.Join(",", enumerable), ResponseStatus.Error));
    }

    return new OkObjectResult(new FanResponse("Reset password done successfully please login with new credentials", ResponseStatus.Success));
  }
}
