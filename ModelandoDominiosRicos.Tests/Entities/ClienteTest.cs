using System;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Tests.Entities;

public class ClienteTest
{
    [Fact]
    public void Deve_criar_cliente_valido()
    {
        // red, green, refactory
        var cliente = new Cliente("Nome", "nome@mail.com");
        cliente.Validate();
        Assert.True(cliente.IsValid);
    }

    [Fact]
    public void Deve_falhar_ao_criar_cliente_vazio()
    {
        // red, green, refactory
        var cliente = new Cliente("", "");
        cliente.Validate();
        Assert.False(cliente.IsValid);
    }

    [Fact]
    public void Deve_falhar_ao_criar_cliente_nulo()
    {
        // red, green, refactory
        var cliente = new Cliente(null, null);
        cliente.Validate();
        Assert.False(cliente.IsValid);
    }

    [Fact]
    public void Deve_falhar_ao_criar_cliente_email_invalido()
    {
        // red, green, refactory
        var cliente = new Cliente("Nome", "nome");
        cliente.Validate();
        Assert.False(cliente.IsValid);
    }

    [Fact]
    public void Deve_alterar_email()
    {
        // red, green, refactory
        var cliente = new Cliente("Nome", "nome@mail.com");
        cliente.AlterarEmail("marcos@mail.com");
        Assert.True(cliente.IsValid);
    }

    [Fact]
    public void Deve_falhar_ao_alterar_email_para_email_invalido()
    {
        // red, green, refactory
        var cliente = new Cliente("Nome", "nome@mail.com");
        cliente.AlterarEmail("marcos@");
        Assert.False(cliente.IsValid);
    }

    [Fact]
    public void Deve_falhar_ao_alterar_nome_para_nome_invalido()
    {
        // red, green, refactory
        var cliente = new Cliente("Nome", "nome@mail.com");
        cliente.AlterarNome("ma");
        Assert.False(cliente.IsValid);
    }


    [Fact]
    public void Deve_falhar_ao_alterar_nome_para_nome_maior_que_100_caracteres()
    {
        // red, green, refactory
        var cliente = new Cliente("Nome", "nome@mail.com");
        cliente.AlterarNome("pneumoultramicroscopicossilicovulcano" +
            "conióticopneumoultramicroscopicossilicovulcanoconiótico" +
            "pneuoultramicroscopicossilicovulcanoconiótico");
        Assert.False(cliente.IsValid);
    }
}

