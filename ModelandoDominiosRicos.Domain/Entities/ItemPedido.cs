using System;
using FluentValidation.Results;
using Flunt.Notifications;
using Flunt.Validations;
using ModelandoDominiosRicos.Domain.Entities.Common;
using ModelandoDominiosRicos.Domain.Validations;

namespace ModelandoDominiosRicos.Domain.Entities;

public class ItemPedido : Entity
{
    public ItemPedido(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }

    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }

    // Criamos esses métodos que geram valores para encapsular a logica que gera esses valores em um unico método assim facilitando os testes de unidades.

    // Nesse exemplo se quisermos testar se o calculo do pedido está correto baseado na quantidade pego e do preço do produto, não vamos precisar fazer essa operação e validação sempre, podemos testar diretamente esse metodo que esta encapsulado
 
    public decimal ObterTotal()
    {
        if (!Produto.Validate())
            AddNotification(new Notification(this.ToString(), "Não é possível obter total de um Produto inválido"));

        return Produto.Preco * Quantidade;
    }

    public override bool Validate()
    {
        ValidationResult valid = new ItemPedidoValidation().Validate(this);

        foreach (var error in valid.Errors)
        {
            AddNotification(new Notification(error.PropertyName, error.ErrorMessage));
        }

        return valid.IsValid;
    }
}

