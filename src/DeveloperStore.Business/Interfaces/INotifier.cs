using DeveloperStore.Business.Notifications;

namespace DeveloperStore.Business.Interfaces;

public interface INotifier
{
    bool HaveNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notificacao);
}