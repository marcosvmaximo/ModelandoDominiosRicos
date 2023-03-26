using System;
using MediatR;

namespace ModelandoDominiosRicos.Application.ClienteContext.Events;

public class EnviarEmailEvent : INotification
{
    public string Email { get; set; }
}

