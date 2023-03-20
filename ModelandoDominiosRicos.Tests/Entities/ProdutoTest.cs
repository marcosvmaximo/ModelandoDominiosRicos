using System;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Tests.Entities;

public class ProdutoTest
{
    [Fact]
    public void DeveCriarProdutoValido()
    {
        var produto = new Produto("Leite", (decimal)10.99, true);
        produto.Validate();
        Assert.True(produto.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarProdutoComPreco0()
    {
        var produto = new Produto("Leite", 0, true);
        produto.Validate();
        Assert.False(produto.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarProdutoSemTitulo()
    {
        var produto = new Produto("", 10, true);
        produto.Validate();
        Assert.False(produto.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarProdutoComValoresNulo()
    {
        var produto = new Produto(null, 0m, false);
        produto.Validate();
        Assert.False(produto.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarProdutoComMaisDeDuasCasasDecimais()
    {
        var produto = new Produto("Produto", 10.1000m, true);
        produto.Validate();
        Assert.False(produto.IsValid);
    }

    [Fact]
    public void DeveDesativarProduto()
    {
        var produto = new Produto("Produto", 10, true);
        produto.Desativar();
        Assert.False(produto.Active);
    }

    [Fact]
    public void DeveAlterarPrecoProduto()
    {
        var produto = new Produto("Produto", 10, false);
        produto.AlterarPreco(25.12m);
        Assert.Equal(25.12m, produto.Preco);
    }
}

