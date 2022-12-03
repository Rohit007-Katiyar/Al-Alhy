using AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Edit.Specification;
using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Edit.Events;

public class EditCoachAccountEventHandler : IRequestHandler<EditCoachAccountEvent,ActionResult>
{
  private readonly IRepository<SocialMediaAccount> _accountRepository;

  public EditCoachAccountEventHandler(IRepository<SocialMediaAccount> accountRepository)
  {
    _accountRepository = accountRepository;
  }
  public async Task<ActionResult> Handle(EditCoachAccountEvent request, CancellationToken cancellationToken)
  {
    var accounts = await _accountRepository.ListAsync(new GetCoachAccounts(request.CoachId),cancellationToken);
    if (accounts.Count == 0) return new OkObjectResult(Enumerable.Empty<string>());

    foreach (var account in accounts)
    {
      if (account.Type == SocialMediaTypes.FaceBook)
      {
        account.SocialMediaAccount1 = request.FaceBookAccount;

        await _accountRepository.UpdateAsync(account, cancellationToken);
        await _accountRepository.SaveChangesAsync(cancellationToken);
      }
      if (account.Type == SocialMediaTypes.Instagram)
      {
        account.SocialMediaAccount1 = request.InstaAccount;

        await _accountRepository.UpdateAsync(account, cancellationToken);
        await _accountRepository.SaveChangesAsync(cancellationToken);
      }
      if (account.Type == SocialMediaTypes.Twitter)
      {
        account.SocialMediaAccount1 = request.TwitterAccount;

        await _accountRepository.UpdateAsync(account, cancellationToken);
        await _accountRepository.SaveChangesAsync(cancellationToken);
      }
    }
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
