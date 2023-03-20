using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.Commands;

public class ObterClientePorEmailQuery : IRequest<BaseResult>, ICommand
{
    public string Email { get; set; }

    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}

