using System;
using MediatR;
using ModelandoDominiosRicos.Application.ClienteContext.Commands;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;

namespace ModelandoDominiosRicos.Application.ClienteContext.Command.Handlers;

public class AlterarNomeClienteHandler :
    IRequestHandler<AlterarNomeClienteCommand, BaseResult>
{
    private readonly IClienteRepository _repository;

    public AlterarNomeClienteHandler(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult> Handle(AlterarNomeClienteCommand request, CancellationToken cancellationToken)
    {
        BaseResult result;
        Cliente? cliente = await _repository.ObtemClientePorEmail(request.Email);

        //DescontoFidelidade desconto = (DescontoFidelidade )new Desconto(23, DateTime.Now);
        // downcast

        //Desconto desconto2 = new DescontoFidelidade(23, 2, DateTime.Now);
        //upcast

        if (cliente == null)
        {
            result = new BaseResult()
            {
                HttpCode = 400,
                Message = "Não foi encontrado nenhum cliente cadastrado com o email informado.",
                Sucess = false,
                Data = cliente
            };
            return result;
        }

        try
        {
            Cliente novoCliente = cliente.AlterarNome(request.NovoNome);

            if (!novoCliente.IsValid)
            {
                result = new BaseResult()
                {
                    HttpCode = 422,
                    Message = "O nome informado não é valido para esse Cliente, tente outro.",
                    Sucess = false,
                    Data = novoCliente
                };

                return result;
            }

            await _repository.Update(novoCliente);

            result = new BaseResult()
            {
                HttpCode = 200,
                Message = "Nome do Cliente foi alterado com sucesso.",
                Sucess = true,
                Data = novoCliente
            };
            return result;
        }
        catch (Exception ex)
        {
            result = new BaseResult()
            {
                HttpCode = 500,
                Message = "Não foi possível realizar a operação, servidor fora do ar ou indisponivel, tente novamente mais tarde.",
                Sucess = true,
                Data = ex.Data.Values,
            };
            return result;
        }
    }
}

