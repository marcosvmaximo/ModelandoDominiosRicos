using System;
using MediatR;
using ModelandoDominiosRicos.Application.ClienteContext.Commands;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;

namespace ModelandoDominiosRicos.Application.ProdutoContext.Queries.Handlers;

public class ObterProdutosHandler : IRequestHandler<ObterProdutoPorIdQuery, BaseResult>,
    IRequestHandler<ObterTodosProdutosQuery, BaseResult>
{
    private readonly IProdutoRepository _repository;

    public ObterProdutosHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult> Handle(ObterProdutoPorIdQuery request, CancellationToken cancellationToken)
    {
        if(request == null || Guid.Empty.Equals(request.Id))
        {
            return new BaseResult()
            {
                HttpCode = 400,
                Message = "Requesição enviada é invalida.",
                Sucess = false,
                Data = request.Id
            };
        }
        
        BaseResult result;
        var cliente = _repository.GetById(request.Id);

        if (cliente.Result is null)
        {
            return new BaseResult()
            {
                HttpCode = 404,
                Message = "Cliente não encontrado",
                Sucess = false,
                Data = request.Id,
            };
        }

        if (cliente.IsCompletedSuccessfully)
        {
            result = new BaseResult().Ok(cliente.Result);
        }
        else
        {
            result = new BaseResult()
            {
                HttpCode = 500,
                Message = "Ocorreu um erro ao enviar a requisição.",
                Sucess = false,
                Data = null
            };
        }

        return result;
    }

    public async Task<BaseResult> Handle(ObterTodosProdutosQuery request, CancellationToken cancellationToken)
    {
        BaseResult result;

        try
        {
            var todosProdutos = await _repository.GetAll();

            if (todosProdutos == null)
                throw new Exception("Ocorreu um erro ao buscar a lista de Produtos");

            if (todosProdutos.Count() <= 0)
            {
                result = new BaseResult()
                {
                    HttpCode = 200,
                    Message = "Requisição enviada com sucesso, porém não existem produtos cadastrados.",
                    Sucess = true,
                    Data = todosProdutos
                };
            }

            result = new BaseResult().Ok(todosProdutos);
        }
        catch(Exception ex)
        {
            result = new BaseResult()
            {
                HttpCode = 500,
                Message = "Ocorreu um erro ao enviar a requisição.",
                Sucess = false,
                Data = null
            };
        }

        return result;
}