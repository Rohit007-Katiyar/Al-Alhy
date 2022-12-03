using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.EditById.Events;
public class EditByIdEventHandler : IRequestHandler<EditByIdEvent,ActionResult>
{
  private readonly ILogger<EditByIdEventHandler> _logger;
  private readonly IRepository<Security.Entities.Admin> _adminRepository;
  private readonly string _userId;
  public EditByIdEventHandler(ILogger<EditByIdEventHandler> logger, IRepository<Security.Entities.Admin> adminRepository, IHttpContextAccessor context)
  {
    _logger = logger;
    _adminRepository = adminRepository;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(EditByIdEvent request, CancellationToken cancellationToken)
  {
    var admin = await _adminRepository.GetByIdAsync(request.AdminId,cancellationToken);
    if (admin == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    admin.Email = string.IsNullOrEmpty(request.Email) ? admin.Email : request.Email;
    admin.PhoneNumber = string.IsNullOrEmpty(request.PhoneNumber) ? admin.PhoneNumber : request.PhoneNumber;
    admin.FullName = string.IsNullOrEmpty(request.Name) ? admin.FullName : request.Name;
    admin.ModifiedBy = Guid.Parse(_userId);
    admin.ModifiedOn = DateTime.Now;

    await _adminRepository.UpdateAsync(admin,cancellationToken);
    await _adminRepository.SaveChangesAsync(cancellationToken);
    _logger.LogInformation($"Admin[{_userId}] update user[{request.AdminId}] data");
    return new OkObjectResult(new AdminResponse("Operation done successfully.", ResponseStatus.Error));
  }
}
