using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.ResetPassword.Admin.Events;
public class ResetPasswordEventHandler : IRequestHandler<ResetPasswordEvent,ActionResult>
{
  private readonly ResetPasswordEventValidator _validator;
  private readonly UserManager<Entities.User> _userManager;
  private readonly IRepository<Entities.Admin> _adminRepository;
  private readonly string _userId;

  public ResetPasswordEventHandler(IHttpContextAccessor context, ResetPasswordEventValidator validator, UserManager<Entities.User> userManager, IRepository<Entities.Admin> adminRepository)
  {
    _validator = validator;
    _userManager = userManager;
    _adminRepository = adminRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;

  }
  public async Task<ActionResult> Handle(ResetPasswordEvent request, CancellationToken cancellationToken)
  {
    var admin = await _userManager.FindByIdAsync(_userId);
    if (admin is null)
      return new BadRequestObjectResult(new AdminResponse("User Not found", ResponseStatus.Error));

    var adminRepo = await _adminRepository.GetByIdAsync(Guid.Parse(_userId), cancellationToken);
    if (adminRepo!.IsActive)
      return new BadRequestObjectResult(new AdminResponse("Admin Already Activated", ResponseStatus.Error));
    
    var validation = await _validator.ValidateAsync(request, cancellationToken);
    if (!validation.IsValid)
    {
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", validation.Errors.Select(x => x.ErrorMessage)), ResponseStatus.Error));
    }
    var token = await _userManager.GeneratePasswordResetTokenAsync(admin);

    var resetRequest = await _userManager.ResetPasswordAsync(admin, token, request.Password);
    if (!resetRequest.Succeeded)
    {
      var errors = resetRequest.Errors.Select(x => x.Description).Distinct();

      var enumerable = errors.ToList();
      return new BadRequestObjectResult(new AdminResponse(string.Join(",", enumerable), ResponseStatus.Error));
    }
    adminRepo.IsActive = true;
    await _adminRepository.UpdateAsync(adminRepo,cancellationToken);
    await _adminRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Reset password done successfully please login with new credentials", ResponseStatus.Success));
  }
}
