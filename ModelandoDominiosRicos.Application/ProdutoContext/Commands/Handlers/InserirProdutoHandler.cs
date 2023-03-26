using System;
using MediatR;
using ModelandoDominiosRicos.Application.ClienteContext.Events;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;

namespace ModelandoDominiosRicos.Application.ProdutoContext.Commands.Handlers;

public class InserirProdutoHandler : IRequestHandler<InserirProdutoCommand, BaseResult>
{
    private readonly IProdutoRepository _repository;

    public InserirProdutoHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult> Handle(InserirProdutoCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return new BaseResult()
            {
                HttpCode = 400,
                Message = "Comando inserido invalido",
                Sucess = false,
                Data = null
            };
        }

        BaseResult result;

        // procurar produtos ativos que possuem o mesmo nome / codigo de barro
        // se sim apagar e sobrescrever
        Produto novoProduto = new Produto(request.NomeProduto, request.Preco);
        novoProduto.Validate();

        if (!novoProduto.IsValid)
        {
            result = new BaseResult()
            {
                HttpCode = 400,
                Message = "Dados informados inválidos.",
                Sucess = false,
                Data = null
            };
            return result;
        }

        try
        {
            await _repository.Add(novoProduto);

            result = new BaseResult().Ok(novoProduto);
        }
        catch (Exception ex)
        {
            result = new BaseResult()
            {
                HttpCode = 500,
                Message = "Falha ao inserir cliente no servidor, tente novamente mais tarde.",
                Sucess = false,
                Data = ex.Data.Values
            };
        }
        return result;
    }
}

