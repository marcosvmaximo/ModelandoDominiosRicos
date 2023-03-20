using System;
using MediatR;
using ModelandoDominiosRicos.Application.Commands;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;

namespace ModelandoDominiosRicos.Application.Queries.Handlers;

public class ObterClientesQueryHandler : IRequestHandler<ObterClientePorEmailQuery, BaseResult>, IRequestHandler<ObterTodosClientesQuery, BaseResult>
{
    private readonly IClienteRepository _repository;

    public ObterClientesQueryHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult> Handle(ObterClientePorEmailQuery request, CancellationToken cancellationToken)
    {
        if(request == null || string.IsNullOrWhiteSpace(request.Email))
        {
            return new BaseResult()
            {
                HttpCode = 400,
                Message = "Requesição enviada é invalida.",
                Sucess = false,
                Data = request.Email
            };
        }
        
        BaseResult result;
        var cliente = _repository.ObtemClientePorEmail(request.Email);

        if (cliente.Result is null)
        {
            return new BaseResult()
            {
                HttpCode = 404,
                Message = "Cliente não encontrado",
                Sucess = false,
                Data = request.Email,
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

    public async Task<BaseResult> Handle(ObterTodosClientesQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return new BaseResult()
            {
                HttpCode = 400,
                Message = "Requesição enviada é invalida.",
                Sucess = false,
                Data = null
            };
        }

        BaseResult result;
        var clientes = _repository.GetAll();

        if (clientes is null)
        {
            result = new BaseResult()
            {
                HttpCode = 500,
                Message = "Ocorreu um erro ao enviar a requisição.",
                Sucess = false,
                Data = null
            };
        }
        else
        {
            result = new BaseResult().Ok(clientes.Result);
        }

        return result;
    }
}