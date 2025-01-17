﻿namespace BlackBoot.Api.Controllers;

public class NotificationController : BaseController
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
        => _notificationService = notificationService;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(Guid userId, CancellationToken cancellationToken)
        => Ok(await _notificationService.GetAllAsync(userId, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> AddAsync(Notification notification, CancellationToken cancellationToken)
        => Ok(await _notificationService.AddAsync(notification, cancellationToken));

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid userId, int id, CancellationToken cancellationToken)
        => Ok(await _notificationService.DeleteAsync(userId, id, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> CountAsync(Guid userId, CancellationToken cancellationToken)
    => Ok(await _notificationService.CountAsync(userId, cancellationToken));
}