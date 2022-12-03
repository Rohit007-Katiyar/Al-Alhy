using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.DTO;
public record CategoryFanDto(int Status, string Message, IEnumerable<CategoryIDNameListDto> res);
