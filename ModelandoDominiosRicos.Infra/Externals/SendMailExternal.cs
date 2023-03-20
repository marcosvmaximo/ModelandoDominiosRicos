using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;

namespace ModelandoDominiosRicos.Infra.Externals;

public class SendMailExternal : ISendMailExternal
{
    public SendMailExternal()
    {
    }

    public Task SendMail<TMessage>(TMessage message) where TMessage : INotification
    {
        throw new NotImplementedException();
    }
}

