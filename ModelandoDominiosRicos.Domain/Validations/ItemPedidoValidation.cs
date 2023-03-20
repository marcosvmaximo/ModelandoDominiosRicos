using System;
using FluentValidation;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Domain.Validations;

public sealed class ItemPedidoValidation : AbstractValidator<ItemPedido>
{
    public ItemPedidoValidation()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Campo obrigatório");

        RuleFor(x => x.Produto)
            .NotNull()
            .SetValidator(new ProdutoValidation())
            .WithMessage("Campo Produto deve ser preenchido corretamente.");

        RuleFor(x => x.Quantidade)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Campo Quantidade deve ser preenchido corretamente.");
    }
}

