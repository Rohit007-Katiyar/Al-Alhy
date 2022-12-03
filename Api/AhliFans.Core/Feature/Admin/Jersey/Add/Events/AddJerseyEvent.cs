using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.Add.Events;
public record AddJerseyEvent(IFormFile Picture, bool IsHome, string AdminId) : MediatR.IRequest<ActionResult>;
