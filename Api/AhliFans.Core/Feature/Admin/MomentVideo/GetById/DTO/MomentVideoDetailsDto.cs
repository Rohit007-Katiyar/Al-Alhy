using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Admin.MomentVideo.GetById.DTO;
public record MomentVideoDetailsDto(int MomentVideoId, int SeasonId, string SeasonName, string Month, string VideoURL,
  int MatchId, int LeagueId, string LeagueName, string Description, string DescriptionAr,
  int PlayerId, string PlayerName, string VideoType, int Time, int CategoryId, string CategoryName,
  DateTime CreatedOn, DateTime? ModifiedOn, bool IsDeleted, string? CreatedBy,
  Guid CreatedById, string? ModifiedBy, Guid? ModifiedById);
