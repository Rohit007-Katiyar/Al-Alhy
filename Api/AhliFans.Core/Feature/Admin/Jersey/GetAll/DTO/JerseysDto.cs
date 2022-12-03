using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Admin.Jersey.GetAll.DTO;
public record JerseysDto(int Id, bool IsHome, DateTime CreatedOn,
  DateTime? ModifiedOn, bool IsEnabled, string CreatedBy,
  Guid CreatedById, string ModifiedBy, Guid? ModifiedById, string ImagePath);
