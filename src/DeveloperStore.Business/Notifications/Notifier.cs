﻿using DeveloperStore.Business.Interfaces;

namespace DeveloperStore.Business.Notifications;

public class Notifier : INotifier
{
    private readonly List<Notification> _notificacoes;

    public Notifier()
    {
        _notificacoes = [];
    }

    public void Handle(Notification notificacao)
    {
        _notificacoes.Add(notificacao);
    }

    public List<Notification> GetNotifications()
    {
        return _notificacoes;
    }

    public bool HaveNotification()
    {
        return _notificacoes.Count != 0;
    }
}