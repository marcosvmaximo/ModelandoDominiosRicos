using System;
using FluentValidation;
using ModelandoDominiosRicos.Domain.Entities;
using ModelandoDominiosRicos.Domain.Enums;

namespace ModelandoDominiosRicos.Domain.Validations;

public sealed class PedidoValidation : AbstractValidator<Pedido>
{
    public PedidoValidation()
    {
        RuleFor(x => x.Total)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .PrecisionScale(6, 2, false)
            .WithMessage("Campo Total deve ser preenchido corretamente");

        RuleFor(x => x.TaxaEntrega)
            .NotNull()
            .GreaterThan(0)
            .PrecisionScale(6, 2, false)
            .WithMessage("Campo Taxa de Entrega deve ser preenchido corretamente");

        RuleFor(x => x.StatusPedido)
            .NotNull()
            .IsInEnum()
            .WithMessage("Campo Status Pedido deve ser preenchido corretamente");

        RuleForEach(x => x.Items)
            .NotNull()
            .SetValidator(new ItemPedidoValidation())
            .WithMessage("Campo Items do Pedido deve ser preenchido corretamente");

        RuleFor(x => x.Desconto)
            .NotNull()
            .NotEmpty()
            .SetValidator(new DescontoValidation())
            .WithMessage("Campo Desconto deve ser preenchido corretamente");

        RuleFor(x => x.Cliente)
            .NotNull()
            .SetValidator(new ClienteValidation())
            .WithMessage("Campo Cliente deve ser preenchido corretamente");
    }
}

