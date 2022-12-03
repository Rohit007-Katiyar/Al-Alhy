using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.ChangeStatus.Events;
public record ChangePhotoStatusEvent(int photoId, string AdminId) : IRequest<ActionResult>;
