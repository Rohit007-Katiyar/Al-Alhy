using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.Image.Get.Events;
public record GetJerseyImageEvent(int JerseyId) : IRequest<ActionResult>;
