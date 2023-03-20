using System;
using FluentValidation.Results;
using Flunt.Notifications;
using ModelandoDominiosRicos.Domain.Entities.Common;
using ModelandoDominiosRicos.Domain.Validations;

namespace ModelandoDominiosRicos.Domain.Entities;
public class Desconto : Entity
{
    private decimal _valor { get; set; }

    public Desconto(decimal valor, DateTime dataExpiracao)
    {
        _valor = valor;
        DataExpiracao = dataExpiracao;
    }

    public decimal ValorDesconto => ObterValorDeconto();
    public DateTime DataExpiracao { get; private set; }

    // Definimos o comportamento direto na entidade, já que é uma regra exclusivamente dela.
    public bool DescontoValido()
    {
        // Se Data atual estiver abaixo da Data de expiracao do cupom, ainda é um desconto valido.
        return DateTime.Compare(DateTime.Now, DataExpiracao) < 0;
    }

    protected virtual decimal ObterValorDeconto()
    {
        if (DescontoValido())
        {
            return _valor;
        }
        else
        {
            AddNotification(new Notification(this.ToString(), "Desconto inválido, expirado."));
            return 0;
        }
    }
    public override bool Validate()
    {
        ValidationResult valid = new DescontoValidation().Validate(this);

        foreach (var error in valid.Errors)
        {
            AddNotification(new Notification(error.PropertyName, error.ErrorMessage));
        }

        return valid.IsValid;
    }
}

