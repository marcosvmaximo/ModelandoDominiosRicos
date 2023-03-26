using MediatR;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Application.DescontoContext.Queries.Handlers;

public class ObterDescontoValidosHandler : IRequestHandler<ObterDescontoValidosCommand, BaseResult>
{
    private readonly IDescontoRepository _repository;

    public ObterDescontoValidosHandler(IDescontoRepository repository)
    {
        _repository = repository;
    }
    public async Task<BaseResult> Handle(ObterDescontoValidosCommand request, CancellationToken cancellationToken)
    {
        BaseResult result;
        if (request is null || request?.DataAtual is null)
        {
            result = new BaseResult()
            {
                HttpCode = 408,
                Message = "Requisição enviada não pode ser nula",
                Sucess = true,
                Data = null
            };
        }

        try
        {
            var descontos = await _repository.GetDescontosDataValida();

            result = new BaseResult().Ok(descontos);
        }
        catch(Exception ex)
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
