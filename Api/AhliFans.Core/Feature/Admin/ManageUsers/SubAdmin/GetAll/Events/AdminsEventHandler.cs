using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetAll.Dto;
using AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetAll.Specifications;
using AhliFans.Core.Feature.Security.Token.JWTHelpers;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.GetAll.Events;
public class AdminsEventHandler : IRequestHandler<AdminsEvent,ActionResult>
{
  private readonly ILogger<AdminsEventHandler> _logger;
  private readonly IReadRepository<Security.Entities.Admin> _adminRepository;
  public AdminsEventHandler(ILogger<AdminsEventHandler> logger, IReadRepository<Security.Entities.Admin> adminRepository)
  {
    _logger = logger;
    _adminRepository = adminRepository;
  }
  public async Task<ActionResult> Handle(AdminsEvent request, CancellationToken cancellationToken)
  {
    var admins = await _adminRepository.ListAsync(new GetAllAdmins(request.PageIndex, request.PageSize, request.IsBlocked, request.Name, request.Email, request.PhoneNumber), cancellationToken);
    var adminsDto = admins.Select(s => new AdminsDto(s.Id, s.Email == s.PhoneNumber+RootAdmin.TempEmail ? null : s.Email, s.FullName, s.PhoneNumber,s.IsBlocked, s.IsActive,s.UserCreate?.FullName!,s.UserModify?.FullName!));
   
    _logger.LogInformation("Admin get all admins");
    return new OkObjectResult(adminsDto.Any()? adminsDto:new AdminResponse("Not Found",ResponseStatus.Error));
  }
}
