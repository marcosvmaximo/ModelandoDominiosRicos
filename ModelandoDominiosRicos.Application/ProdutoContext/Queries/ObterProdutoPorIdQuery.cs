using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.ProdutoContext.Queries;

public class ObterProdutoPorIdQuery : IRequest<BaseResult>, ICommand
{
    public Guid Id { get; set; }

    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}

