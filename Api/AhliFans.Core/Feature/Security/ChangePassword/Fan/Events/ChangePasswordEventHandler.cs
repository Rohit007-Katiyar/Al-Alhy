using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ChangePassword.Fan.Events;
public class ChangePasswordEventHandler : IRequestHandler<ChangePasswordEvent,ActionResult>
{
  private readonly ChangePasswordEventValidation _validator;
  private readonly UserManager<Entities.Fan> _userManager;
  private readonly string _userId;
  public ChangePasswordEventHandler(ChangePasswordEventValidation validator, IHttpContextAccessor context, UserManager<Entities.Fan> userManager)
  {
    _validator = validator;
    _userManager = userManager;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(ChangePasswordEvent request, CancellationToken cancellationToken)
  {
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
      return new BadRequestObjectResult(new FanResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));

    var fan = await _userManager.FindByIdAsync(_userId);
    if (fan is null) return new BadRequestObjectResult(new FanResponse("User Not found", ResponseStatus.Error));

    var resetRequest = await _userManager.ChangePasswordAsync(fan, request.OldPassword, request.NewPassword);
    if (!resetRequest.Succeeded)
    {
      var errors = resetRequest.Errors.Select(x => x.Description).Distinct();

      var enumerable = errors.ToList();
      return new BadRequestObjectResult(new FanResponse(string.Join(",", enumerable), ResponseStatus.Error));
    }

    return new OkObjectResult(new FanResponse("Change password done successfully", ResponseStatus.Success));
  }
}
