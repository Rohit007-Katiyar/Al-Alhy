using AhliFans.Core.Feature.Enums;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetAll.DTO;

public record AdminPlayerAccountsDto(int AccountId,string Account,bool IsDeleted, int AccountType);
