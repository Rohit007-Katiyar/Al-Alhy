using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.GetAll.DTO;
using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.GetAll.Specification;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.GetAll.Events;

public class GetAllCoachAccountsEventHandler : IRequestHandler<GetAllCoachAccountsEvent,ActionResult>
{
  private readonly IRepository<SocialMediaAccount> _accountRepository;

  public GetAllCoachAccountsEventHandler(IRepository<SocialMediaAccount> accountRepository)
  {
    _accountRepository = accountRepository;
  }
  public async Task<ActionResult> Handle(GetAllCoachAccountsEvent request, CancellationToken cancellationToken)
  {
    var accounts = await _accountRepository.ListAsync(new GetAccountsOfCoach(request.CoachId, request.IsDeleted), cancellationToken);
    if (accounts.Count == 0) return new OkObjectResult(Enumerable.Empty<CoachAccountsDto>());
    return new OkObjectResult(accounts.Select(a => new CoachAccountsDto(a.Id, a.SocialMediaAccount1,a.IsDeleted,(int)a.Type!)));
  }
}
