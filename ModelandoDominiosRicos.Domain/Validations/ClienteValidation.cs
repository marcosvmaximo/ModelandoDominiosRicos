using System;
using FluentValidation;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Domain.Validations;

public sealed class ClienteValidation : AbstractValidator<Cliente>
{
    public ClienteValidation()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("Campo obrigatório");

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100)
            .WithMessage("Campo Email deve ser preenchido corretamente");

        RuleFor(x => x.Nome)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100)
            .WithMessage("Campo Nome deve ser preenchido corretamente");
    }
}

