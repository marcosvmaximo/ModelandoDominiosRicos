using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.DescontoContext.Commands;

public class CriarDescontoCommand : IRequest<BaseResult>, ICommand
{
    public decimal ValorDesconto { get; set; }
    public DateTime ValidadeDesconto { get; set; }

    public bool FastValidate()
    {
        return true;
    }
}

