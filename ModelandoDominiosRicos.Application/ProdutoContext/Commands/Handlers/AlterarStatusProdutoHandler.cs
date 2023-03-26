using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;

namespace ModelandoDominiosRicos.Application.ProdutoContext.Commands.Handlers;

public class AlterarStatusProdutoHandler : IRequestHandler<AlterarStatusCommand, BaseResult>
{
    private readonly IProdutoRepository _repository;

    public AlterarStatusProdutoHandler(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult> Handle(AlterarStatusCommand request, CancellationToken cancellationToken)
    {
        BaseResult result;

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

        try
        {
            if (!request.FastValidate())
            {
                result = new BaseResult()
                {
                    HttpCode = 400,
                    Message = "Dados informados inválidos.",
                    Sucess = false,
                    Data = null
                };
            }

            var produto = await _repository.GetById(request.Id);

            if (request.NovoStatus is true)
            {
                // Deve Ativar
                produto.Ativar();

                await _repository.Update(produto);
            }
            else
            {
                // Deve Desativar
                produto.Desativar();

                await _repository.Update(produto);
            }

            result = new BaseResult().Ok(produto);
        }
        catch (Exception ex)
        {
            result = new BaseResult()
            {
                HttpCode = 500,
                Message = "Falha ao inserir cliente no servidor, tente novamente mais tarde.",
                Sucess = false,
                Data = ex.Message
            };
        }

        return result;
    }
}

