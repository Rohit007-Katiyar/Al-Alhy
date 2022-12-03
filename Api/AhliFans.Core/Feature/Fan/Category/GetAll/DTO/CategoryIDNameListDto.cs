using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.DTO;
public record CategoryIDNameListDto(int CategoryId, string CategoryName, IEnumerable<DataDto> data);

