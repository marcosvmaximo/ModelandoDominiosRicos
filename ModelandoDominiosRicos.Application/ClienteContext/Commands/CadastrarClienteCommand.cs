using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.ClienteContext.Commands;

public class CadastrarClienteCommand : ICommand, IRequest<BaseResult>
{
    public string Nome { get; set; }
    public string Email { get; set; }

    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}

