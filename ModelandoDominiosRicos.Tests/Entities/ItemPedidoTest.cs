using System;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Tests.Entities;

public class ItemPedidoTest
{
    private readonly Produto _validProduto = new Produto("Produto", 10.10m, true);

    private readonly Produto _invalidProduto = new Produto("", 1.121m, false);

    [Fact]
    public void DeveCriarItemPedidoValido()
    {
        var item = new ItemPedido(_validProduto, 2);
        item.Validate();
        Assert.True(item.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarItemPedidoComQuantidadeInvalida()
    {
        var item = new ItemPedido(_validProduto, -12);
        item.Validate();
        Assert.False(item.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarItemPedidoComProdutoNull()
    {
        var item = new ItemPedido(null, 12);
        item.Validate();
        Assert.False(item.IsValid);
    }

    [Fact]
    public void DeveFalharAoObterTotalComProdutoInvalido()
    {
        var item = new ItemPedido(_invalidProduto, 12);
        _invalidProduto.Validate();
        item.ObterTotal();

        Assert.False(item.IsValid);
    }

    [Fact]
    public void DeveObterTotalCorreto()
    {
        var produto = new Produto("Produto", 10m, true);
        var item = new ItemPedido(produto, 10);
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

