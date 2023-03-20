using FluentValidation.Results;
using Flunt.Notifications;
using Flunt.Validations;
using ModelandoDominiosRicos.Domain.Entities.Common;
using ModelandoDominiosRicos.Domain.Validations;

namespace ModelandoDominiosRicos.Domain.Entities;
public class Cliente : Entity
{
    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;

        //AddNotifications(new Contract<Cliente>()
        //    .Requires()
        //    .IsNotNull(nome, "Nome", "Campo nome não deve ser nulo")
        //    .IsNotNull(email, "Email", "Campo email não deve ser nulo")
        //    .IsEmail(email, "Email", "Campo deve ser um email")
        //    );
    }

    /*
    Aplicaremos o principio de aberto e fechado, definindo que nossos dados internos, estão fechados
    para mudanças, porém aberto para atualizações..

    Aplicamos isso na prática proibido as propriedades de nossa classe de serem alteradas, usando
    também um principio base da OOP de encapsulamento, pois estamos protegendo os dados do nosso modelo,
    assim o encapsulando evitando que algo externo o corrompa.
    */

    public string Nome { get; private set; }
    public string Email { get; private set; }

    public Cliente AlterarNome(string nome)
    {
        if (!string.IsNullOrWhiteSpace(nome))
            Nome = nome;

        Validate();
        return this;
        //se nao..
        //AddNotifications(new Contract<Cliente>()
        //    .IsNotNullOrWhiteSpace(nome, "Nome", "Campo nome deve conter um nome valido"));
    }

    public void AlterarEmail(string email)
    {
        if (!string.IsNullOrWhiteSpace(email))
            Email = email;
        // é melhor deixar alterar e adicionar uma notificação que esta incorreto?
        // ou nem permitir trocar pq ta incorreto?

        Validate();

        //AddNotifications(new Contract<Cliente>()
        //    .IsEmail(email, "Email", "Campo email deve ser um email valido"));
    }

    public override bool Validate()
    {
        ValidationResult valid = new ClienteValidation().Validate(this);

        foreach (var error in valid.Errors)
        {
            AddNotification(new Notification(error.PropertyName, error.ErrorMessage));
        }

        return valid.IsValid;
    }
}

