using System;
using MediatR;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Application.PedidoContext.Commands;

public class CriarPedidoCommand : IRequest<BaseResult>
{
    public Guid IdCliente { get; set; }
    public Guid IdDesconto { get; set; }
    public decimal TaxaEntrega { get; set; }
}

