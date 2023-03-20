using System;
using MediatR;
using ModelandoDominiosRicos.Application.Commands;
using ModelandoDominiosRicos.Application.Events;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;

namespace ModelandoDominiosRicos.Application.Command.Handlers;

public class CadastrarClienteHandler : IRequestHandler<CadastrarClienteCommand, BaseResult>
{
    private readonly IClienteRepository _repository;
    private readonly IMediator _mediator;

    public CadastrarClienteHandler(IClienteRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<BaseResult> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
    {
        BaseResult result;

        var existeClienteEmail = _repository.ObtemClientePorEmail(request.Email).Result;

        if (existeClienteEmail != null)
        {
            result = new BaseResult()
            {
                HttpCode = 409,
                Message = "Já existe um usuário com o email informado.",
                Sucess = true,
                Data = null
            };
            return result;
        }
        var cliente = new Cliente(request.Nome, request.Email);
        cliente.Validate();

        if (!cliente.IsValid)
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
            await _repository.Add(cliente);
            await _mediator.Publish(new EnviarEmailEvent() { Email = cliente.Email });

            result = new BaseResult().Ok(cliente);
            return result;
        }
        catch (Exception ex)
        {
            return new BaseResult()
            {
                HttpCode = 500,
                Message = "Falha ao inserir cliente no servidor, tente novamente mais tarde.",
                Sucess = false,
                Data = ex.Data.Values
            };
        }
    }
}

