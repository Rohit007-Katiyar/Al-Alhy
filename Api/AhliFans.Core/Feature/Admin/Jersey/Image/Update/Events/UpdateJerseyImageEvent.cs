using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.Image.Update.Events;
public record UpdateJerseyImageEvent(int JerseyId, IFormFile JeseyImage, string AdminId) : IRequest<ActionResult>;
