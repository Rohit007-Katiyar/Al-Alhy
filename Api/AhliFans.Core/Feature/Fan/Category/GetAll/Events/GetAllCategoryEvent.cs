using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Category.GetAll.Events;
public record GetAllCategoryEvent(int PageIndex, int PageSize, bool IsDeleted, string Lang) : IRequest<ActionResult>;
