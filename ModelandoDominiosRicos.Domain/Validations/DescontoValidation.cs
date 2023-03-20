using System;
using FluentValidation;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Domain.Validations;

public class DescontoValidation : AbstractValidator<Desconto>
{
    public DescontoValidation()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Campo obrigatório");

        RuleFor(x => x.DataExpiracao)
            .NotNull()
            .GreaterThanOrEqualTo(new DateTime(2020, 1, 1))
            .WithMessage("Campo Data deve ser preenchido.");

        RuleFor(x => x.ValorDesconto)
            .NotNull()
            .PrecisionScale(6, 2, false)
            .GreaterThan(0)
            .WithMessage("Campo Preco deve ser preenchido.");
    }
}

