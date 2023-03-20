using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.Commands;

public class ObterTodosClientesQuery : IRequest<BaseResult>, ICommand
{
    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}

