using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Match.Media.Images.GetAll.Specifications;

public sealed class GetMediaByMatch : Specification<MatchMedia>
{
  public GetMediaByMatch(int matchId)
  {
    Query
      .Where(x => x.MatchId == matchId && x.MediaType == MediaType.Photo);
  }
}
