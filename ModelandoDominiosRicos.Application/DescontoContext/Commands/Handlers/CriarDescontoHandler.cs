using MediatR;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Application.DescontoContext.Commands.Handlers
{
    public class CriarDescontoHandler : IRequestHandler<CriarDescontoCommand, BaseResult>
    {
        private readonly IDescontoRepository _respository;

        public CriarDescontoHandler(IDescontoRepository repository) 
        {
            _respository = repository;
        }
        public async Task<BaseResult> Handle(CriarDescontoCommand request, CancellationToken cancellationToken)
        {
            BaseResult result;

            if (!request.FastValidate())
            {
                result = new BaseResult()
                {
                    HttpCode = 408,
                    Message = "Informações para criar desconto inválidas",
                    Sucess = true,
                    Data = request
                };
            }

            //if (!(request.ValidadeDesconto > DateTime.Now))
            //{
            //    result = new BaseResult()
            //    {
            //        HttpCode = 408,
            //        Message = "Não é possível criar um desconto com a validade menor que a data atual.",
            //        Sucess = true,
            //        Data = request
            //    };
            //}
            Desconto desconto = new Desconto(request.ValorDesconto, request.ValidadeDesconto);
            desconto.Validate();
            if (!(desconto.IsValid && desconto.ObterValorDeconto() > 0))
            {
                result = new BaseResult()
                {
                    HttpCode = 408,
                    Message = "Não é possível criar um desconto com a validade menor que a data atual.",
                    Sucess = true,
                    Data = request
                };
            }

            try
            {
                _respository.Add(desconto);
                result = new BaseResult().Ok(desconto);
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
}
