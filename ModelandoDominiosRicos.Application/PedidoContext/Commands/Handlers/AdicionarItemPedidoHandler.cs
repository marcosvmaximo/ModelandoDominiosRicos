using MediatR;
using ModelandoDominiosRicos.CrossCutting.Results;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelandoDominiosRicos.Application.PedidoContext.Commands.Handlers;

public class AdicionarItemPedidoHandler : IRequestHandler<AdicionarItemPedidoCommand, BaseResult>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IItemPedidoRepository _itemPedidoRepository;

    public AdicionarItemPedidoHandler(
        IClienteRepository clienteRepository,
        IProdutoRepository produtoRepository,
        IItemPedidoRepository itemPedidoRepository)
    {
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
        _itemPedidoRepository = itemPedidoRepository;
    }

    public async Task<BaseResult> Handle(AdicionarItemPedidoCommand request, CancellationToken cancellationToken)
    {
        BaseResult result;

        if(request is null || !request.FastValidate())
        {
            result = new BaseResult()
            {
                HttpCode = 400,
                Sucess = false,
                Message = "Requisição enviada é inválida.",
                Data = null
            };
            return result;
        }


        // busco cliente por id
        // busco produto por id
        // crio item pedido
        // item pedido vai ter id de ambos, como ele vai se referenciar?

        // busca a entidade no qual os Ids se referem
        Produto produto = await _produtoRepository.GetById(request.IdProduto);
        Cliente cliente = await _clienteRepository.GetById(request.IdCliente);

        if(produto is null || cliente is null)
        {
            result = new BaseResult()
            {
                HttpCode = 404,
                Sucess = false,
                Message = "Produto ou Cliente inserido não foi encontrado",
                Data = null
            };
            return result;
        }

        // criar o item pedido com as entidades buscadas
        ItemPedido itemPedido = new ItemPedido(produto, request.QuantidadeProduto, cliente);

        if (!itemPedido.Validate())
        {
            result = new BaseResult()
            {
                HttpCode = 400,
                Sucess = false,
                Message = "ItemPedido não atende os padrões de validação",
                Data = itemPedido
            };
            return result;
        }

        try
        {
            await _itemPedidoRepository.Add(itemPedido);
            result = new BaseResult().Ok(itemPedido);
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
