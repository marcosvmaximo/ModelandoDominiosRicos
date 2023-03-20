using System;
using MediatR;

namespace ModelandoDominiosRicos.Application.Events;

public class EnviarEmailEvent : INotification
{
    public string Email { get; set; }
}

