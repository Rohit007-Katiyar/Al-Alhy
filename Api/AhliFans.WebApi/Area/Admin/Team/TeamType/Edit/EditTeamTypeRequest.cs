﻿using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Team.TeamType;

public record EditTeamTypeRequest(int TeamTypeId, string? Name, string? NameAr)
{
  public const string Route = $"{nameof(Areas.Admin)}/Team/Type";
}
