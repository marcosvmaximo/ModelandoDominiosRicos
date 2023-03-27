using System;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Tests.Entities;

public class ItemPedidoTest
{
    private readonly Produto _validProduto = new Produto("Produto", 10.10m);
    private readonly Cliente _validCliente = new Cliente("Marcos", "marcos@mail.com");

    [Fact]
    public void DeveCriarItemPedidoValido()
    {
        var item = new ItemPedido(_validProduto, 2, _validCliente);
        item.Validate();
        Assert.True(item.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarItemPedidoComQuantidadeInvalida()
    {
        var item = new ItemPedido(_validProduto, -12, _validCliente);
        item.Validate();
        Assert.False(item.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarItemPedidoComProdutoNull()
    {
        var item = new ItemPedido(null, 12, null);
        item.Validate();
        Assert.False(item.IsValid);
    }

    [Fact]
    public void DeveFalharAoObterTotalComProdutoInvalido()
    {
        var produto = new Produto("Produto Invalido", 10.10m);
        produto.Desativar();
        var item = new ItemPedido(produto, 12, _validCliente);
        produto.Validate();
        item.ObterTotal();

        Assert.False(item.IsValid);
    }

    [Fact]
    public void DeveObterTotalCorreto()
    {
        var produto = new Produto("Produto", 10m);
        var item = new ItemPedido(produto, 10, _validCliente);
        var total = item.ObterTotal();

        Assert.Equal(100m, total);
    }

    //[Fact]
    //public void DeveFalharAoAdicionarProdutoInativo()
    //{
    //    var produto = new Produto("Produto", 10m, false);
     
    //    var item = new ItemPedido(_validProduto, 10);
    //    item.AddProduto(produto);

    //    Assert.False(item.IsValid);
    //}

    //[Fact]
    //public void DeveFalharAoAdicionarProdutoComNotificacoes()
    //{
    //    _invalidProduto.Validate();
    //    var item = new ItemPedido(_validProduto, 10);
    //    item.AddProduto(_invalidProduto);

    //    Assert.False(item.IsValid);
    //}
}

