using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.ProdutoContext.Commands;

public class InserirProdutoCommand : IRequest<BaseResult>, ICommand
{
    public string NomeProduto { get; set; }
    public decimal Preco { get; set; }

    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}

