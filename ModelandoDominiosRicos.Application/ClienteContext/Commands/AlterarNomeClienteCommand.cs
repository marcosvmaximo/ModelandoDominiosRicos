using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.ClienteContext.Commands;

public class AlterarNomeClienteCommand : ICommand, IRequest<BaseResult>
{
    public string NovoNome { get; set; }
    public string Email { get; set; }

    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}

