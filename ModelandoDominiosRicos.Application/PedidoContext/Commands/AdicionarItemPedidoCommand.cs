using MediatR;
using ModelandoDominiosRicos.CrossCutting.Interfaces;
using ModelandoDominiosRicos.CrossCutting.Results;

namespace ModelandoDominiosRicos.Application.PedidoContext.Commands;

public class AdicionarItemPedidoCommand : IRequest<BaseResult>, ICommand
{
    public Guid IdCliente { get; set; }
    public Guid IdProduto { get; set; }
    public int QuantidadeProduto { get; set; }

    public bool FastValidate()
    {
        throw new NotImplementedException();
    }
}
