using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.Events.Handlers;

public class EnviarEmailEventHandler : INotificationHandler<EnviarEmailEvent>
{
    private readonly ISendMailExternal _external;

    public EnviarEmailEventHandler(ISendMailExternal external)
    {
        _external = external;
    }

    public async Task Handle(EnviarEmailEvent notification, CancellationToken cancellationToken)
    {
        
    }
}

