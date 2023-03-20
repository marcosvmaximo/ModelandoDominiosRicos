using System;
using FluentValidation;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Domain.Validations;

public sealed class ProdutoValidation : AbstractValidator<Produto>
{
    public ProdutoValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Campo ID não deve ser nulo.");

        RuleFor(x => x.Active)
            .NotNull()
            .WithMessage("Campo Active não deve ser nulo.");

        RuleFor(x => x.Titulo)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .WithMessage("Campo Titulo deve ser preenchido corretamente.");

        RuleFor(x => x.Preco)
            .NotNull()
            .PrecisionScale(6, 2, false)
            .GreaterThan(0)
            .WithMessage("Campo Preco deve ser preenchido.");
    }
}

