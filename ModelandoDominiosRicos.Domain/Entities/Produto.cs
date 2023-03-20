using System;
using FluentValidation.Results;
using Flunt.Notifications;
using ModelandoDominiosRicos.Domain.Entities.Common;
using ModelandoDominiosRicos.Domain.Validations;

namespace ModelandoDominiosRicos.Domain.Entities;
public class Produto : Entity
{
    /* 
    De novo encapsulamos os dados do nosso modelo, fechando-o para mudanças e de fatores externos, ou seja,
    deixamos seus comportamentos e caracteristicas, unidas dentro desse modelo, que juntos foram esse objeto,
    porém o usuário de fora não conhece esses detalhes, sendo assim detalhes encapsulados.
    */
    public Produto(string titulo, decimal preco, bool active)
    {
        Titulo = titulo;
        Preco = preco;
        Active = active;
    }

    public string Titulo { get; private set; }
    public decimal Preco { get; private set; }
    public bool Active { get; private set; }

    public void Desativar() => Active = false;

    public void AlterarPreco(decimal preco) => Preco = preco;

    public override bool Validate()
    {
        ValidationResult valid = new ProdutoValidation().Validate(this);

        foreach (var error in valid.Errors)
        {
            AddNotification(new Notification(error.PropertyName, error.ErrorMessage));
        }

        return valid.IsValid;
    }
}

