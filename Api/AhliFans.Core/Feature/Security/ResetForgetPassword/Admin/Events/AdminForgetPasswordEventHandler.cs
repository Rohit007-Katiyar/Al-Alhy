using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResetForgetPassword.Admin.Events;
public class AdminForgetPasswordEventHandler : IRequestHandler<AdminForgetPasswordEvent,ActionResult>
{
  private readonly UserManager<Entities.User> _userManager;
  private readonly AdminForgetPasswordValidator _validator;
  private readonly string _userId;

  public AdminForgetPasswordEventHandler(IHttpContextAccessor context, UserManager<Entities.User> userManager, AdminForgetPasswordValidator validator)
  {
    _userManager = userManager;
    _validator = validator;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(AdminForgetPasswordEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
    {
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }

    var admin = await _userManager.FindByIdAsync(_userId);
    if (admin is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    var token = await _userManager.GeneratePasswordResetTokenAsync(admin);
    var result = await _userManager.ResetPasswordAsync(admin,token, request.NewPassword);
    if (!result.Succeeded)
    {
      var errors = result.Errors.Select(x => x.Description).Distinct();

      var enumerable = errors.ToList();
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", enumerable), ResponseStatus.Error));
    }

    return new OkObjectResult(new AdminResponse("Reset password done successfully please login with new credentials", ResponseStatus.Success));
  }
}
