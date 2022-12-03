using AhliFans.Core.Feature.Admin.Notification.Manual.Send.Specification;
using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.Notification.Model;
using AhliFans.SharedKernel.APIServices.Notification.Repo;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Notification.Manual.Send.Events;

public class SendNotificationEventHandler : IRequestHandler<SendNotificationEvent,ActionResult>
{
  private readonly IRepository<NotificationSetting> _notificationSettingRepository;
  private readonly IRepository<Entities.Notification> _notificationRepository;
  private readonly IMapper _mapper;
  private readonly IFileManager _fileManager;
  private readonly string _userId;
  private readonly INotificationService _notificationService;
  public SendNotificationEventHandler(IHttpContextAccessor context,IRepository<NotificationSetting> notificationSettingRepository, IRepository<Entities.Notification> notificationRepository,IMapper mapper, IFileManager fileManager, INotificationService notificationService)
  {
    _notificationSettingRepository = notificationSettingRepository;
    _notificationRepository = notificationRepository;
    _mapper = mapper;
    _fileManager = fileManager;
    _notificationService = notificationService;
    _userId = context.HttpContext.User.Claims.First(i => i.Type == "User Id").Value;
  }
  public async Task<ActionResult> Handle(SendNotificationEvent request, CancellationToken cancellationToken)
  {
    var notification = _mapper.Map<Entities.Notification>(request);
    notification.AdminId = Guid.Parse(_userId);
    var fans = await _notificationSettingRepository.ListAsync(new FilterUserNotificationSetting(), cancellationToken);
    var fanNotifications = fans.Select(fan => new FanNotification() {Data = DateTime.Now, Notification = notification, Read = false, Fan = fan.Fan}).ToList();
    
    notification.FanNotifications = fanNotifications;
    await _notificationRepository.AddAsync(notification, cancellationToken);
    await _notificationRepository.SaveChangesAsync(cancellationToken);

    bool saveIcon = await SaveIcon(request.Icon, notification.Id);
    if (!saveIcon) return new OkObjectResult(new AdminResponse("New notification has been send successfully,but saving icon failure .", ResponseStatus.Warning));
    
    //Fire notification
    await _notificationService.SendNotification(new NotificationModel() {NotificationId = notification.Id,Body = request.Body, Title = request.Header,Tokens = fanNotifications.Select(x=>x.Fan.FireBaseToken).Where(x=>!string.IsNullOrEmpty(x)).ToList()});
    return new OkObjectResult(new AdminResponse("operation done successfully", ResponseStatus.Success));
  }
  private async Task<bool> SaveIcon(IFormFile? request, int notificationId)
  {
    if (request is null)
    {
      return true;
    }
    bool saveProfile = await _fileManager.SaveFileAsync<Entities.Notification>(request,
      request.FileName, notificationId.ToString());
    return saveProfile;
  }
}
