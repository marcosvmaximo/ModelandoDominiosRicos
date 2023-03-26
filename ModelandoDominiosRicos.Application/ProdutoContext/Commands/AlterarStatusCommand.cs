using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.ProdutoContext.Commands;

public class AlterarStatusCommand : IRequest<BaseResult>, ICommand
{
    public Guid Id { get; set; }
    public bool NovoStatus { get; set; }

    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}

