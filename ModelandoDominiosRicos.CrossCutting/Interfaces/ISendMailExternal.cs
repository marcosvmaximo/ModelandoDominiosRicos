using System;
using MediatR;

namespace ModelandoDominiosRicos.CrossCutting.Interfaces;

public interface ISendMailExternal
{
    public Task SendMail<TMessage>(TMessage message) where TMessage : INotification;
}

