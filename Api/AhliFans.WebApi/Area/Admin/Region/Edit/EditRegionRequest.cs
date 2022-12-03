﻿using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Region;

public record EditRegionRequest(int Id,string? Name, string? NameAr)
{
  public const string Route = $"{nameof(Areas.Admin)}/Region";
}

