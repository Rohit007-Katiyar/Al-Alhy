using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Profile.Modify.Events;
public class ModifyEventHandler : IRequestHandler<ModifyEvent,ActionResult>
{
  private readonly string _userId;
  private readonly IRepository<Security.Entities.Admin> _adminRepository;

  public ModifyEventHandler(IHttpContextAccessor context,IRepository<Security.Entities.Admin> adminRepositoryRepository)
  {
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
    _adminRepository = adminRepositoryRepository;
  }
  public async Task<ActionResult> Handle(ModifyEvent request, CancellationToken cancellationToken)
  {
    var admin = await _adminRepository.GetByIdAsync(Guid.Parse(_userId),cancellationToken);
    if (admin == null) return new BadRequestObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    
    if (await IsEmailExist(request.Email!, cancellationToken))
    {
      return new BadRequestObjectResult(new AdminResponse("The Email is already taken", ResponseStatus.Error));
    }

    if (await IsPhoneNumberExist(request.PhoneNumber!,cancellationToken))
    {
      return new BadRequestObjectResult(new AdminResponse("The Phone Number is already taken", ResponseStatus.Error));
    }

    admin.FullName = request.FullName ?? admin.FullName;
    admin.Email = request.Email ?? admin.Email;
    admin.UserName = request.Email ?? admin.Email;
    admin.PhoneNumber = request.PhoneNumber ?? admin.PhoneNumber;
    
    await _adminRepository.UpdateAsync(admin,cancellationToken);
    await _adminRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully.", ResponseStatus.Error));
  }

  private async Task<bool> IsEmailExist(string email, CancellationToken cancellationToken)
  {
    if (string.IsNullOrEmpty(email))
    {
      return false;
    }
    var admin = await _adminRepository.GetBySpecAsync(new GetByEmail<Security.Entities.Admin>(email),
      cancellationToken);
    return admin is not null && admin.Id != Guid.Parse(_userId);
  }
  private async Task<bool> IsPhoneNumberExist(string phone, CancellationToken cancellationToken)
  {
    if (string.IsNullOrEmpty(phone))
    {
      return false;
    }
    var admin = await _adminRepository.GetBySpecAsync(new GetByPhoneNumberWithOtp<Security.Entities.Admin>(phone),
      cancellationToken);
    return admin is not null && admin.Id != Guid.Parse(_userId);
  }
}
