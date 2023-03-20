using System;
using FluentValidation.Results;
using Flunt.Notifications;
using ModelandoDominiosRicos.Domain.Entities.Common;
using ModelandoDominiosRicos.Domain.Enums;
using ModelandoDominiosRicos.Domain.Validations;

namespace ModelandoDominiosRicos.Domain.Entities;

public class Pedido : Entity
{
    // Alguns itens pode ser requeridos para operações internas, mas isso cria uma dependencia ruim no nosso código, então extanilzamos, deixamos a responsabilidade de nos dar esses itens externos para fora da entidade, assim evitando a dependencia.
    private List<ItemPedido> _items;

    public Pedido(Cliente cliente, decimal taxaEntrega, Desconto desconto)
    {
        Cliente = cliente;
        DataCriacaoPedido = DateTime.Now;
        TaxaEntrega = taxaEntrega;
        Desconto = desconto;
        StatusPedido = EStatusPedido.AguardandoPagamento;
        _items = new List<ItemPedido>();
    }

    public Cliente Cliente { get; private set; }
    public DateTime DataCriacaoPedido { get; private set; }
    public decimal TaxaEntrega { get; private set; }
    public Desconto Desconto { get; private set; }
    public EStatusPedido StatusPedido { get; private set; }
    public IReadOnlyCollection<ItemPedido> Items => _items;
    public decimal Total => ObterTotal();

    public void AdicionarItem(Produto produto, int quantidade)
    {
        if (produto != null && produto.Active)
        {
            var itemPedido = new ItemPedido(produto, quantidade);
            _items.Add(itemPedido);
        }
        else
        {
            AddNotification(new Notification("Adicionar Item", "Produto inserido inválido."));
        }
    }

    private decimal ObterTotal()
    {
        decimal valorPedido = 0;

        if (Items.Count > 0)
        {
            foreach (var item in Items)
            {
                valorPedido += item.ObterTotal();
            }

            valorPedido -= Desconto.ValorDesconto;
            valorPedido += TaxaEntrega;
        }

        return valorPedido;
    }

    public void Pagar(decimal pagamento)
    {
        if(pagamento == Total)
        {
            StatusPedido = EStatusPedido.AguardandoEntrega;
        }
    }

    public bool Cancelar()
    {
        if(StatusPedido == EStatusPedido.AguardandoEntrega)
            return false;
      
        StatusPedido = EStatusPedido.Cancelado;
        return true;
    }

    public override bool Validate()
    {
        ValidationResult valid = new PedidoValidation().Validate(this);

        foreach (var error in valid.Errors)
        {
            AddNotification(new Notification(error.PropertyName, error.ErrorMessage));
        }

        return valid.IsValid;
    }
}

