using System;
using Flunt.Notifications;

namespace ModelandoDominiosRicos.Domain.Entities;

public sealed class DescontoFidelidade : Desconto
{
    public decimal QuantidadePedidos { get; private set; }

    public DescontoFidelidade(decimal valor, int quantidadePedidos, DateTime dataExpiracao) : base(valor, dataExpiracao)
    {
        QuantidadePedidos = quantidadePedidos;
    }

    protected override decimal ObterValorDeconto()
    {
        if (DescontoValido())
        {
            return (QuantidadePedidos / 100) * ValorDesconto;
        }
        else
        {
            AddNotification(new Notification(this.ToString(), "Desconto inválido, expirado."));
            return 0;
        }
    }
}

