using System;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Tests.Entities;

public class PedidoTest
{
    private Desconto _descontoValido = new Desconto(10, new DateTime(2025, 10, 10));

    private Desconto _descontoInvalido = new Desconto(10, new DateTime(2020, 1, 1));

    private Cliente _clienteValido = new Cliente("Nome Inteiro", "email@mail.com");

    private Cliente _clienteInvalido = new Cliente("", "mail");

    [Fact]
    public void DeveCriarUmPedidoValido()
    {
        var pedido = new Pedido(_clienteValido, 10.30m, _descontoValido);

        pedido.Validate();
        Assert.True(pedido.IsValid);
    }

    [Fact]
    public void DadoUmClienteInvalido_NaoDeveCriarUmPedido()
    {
        var pedido = new Pedido(_clienteInvalido, 10, _descontoInvalido);
        pedido.Validate();
        Assert.False(pedido.IsValid);
    }

    [Fact]
    public void DadoUmClienteNulo_NaoDeveCriarUmPedido()
    {
        var pedido = new Pedido(null, 10, _descontoInvalido);
        pedido.Validate();
        Assert.False(pedido.IsValid);
    }

    [Fact]
    public void DadoUmDescontoNulo_NaoDeveCriarUmPedido()
    {
        var pedido = new Pedido(_clienteValido, 10, null);
        Assert.False(pedido.Validate());
    }

    [Fact]
    public void DadoUmDescontoExpirado_PedidoDeveCustar50()
    {
        var descontoExpirado = new Desconto(10, new DateTime(2020, 1, 1));
        var pedido = new Pedido(_clienteValido, 10, descontoExpirado);
        pedido.AdicionarItem(new Produto("Produto", 40, true), 1);
        Assert.Equal(50, pedido.Total);
    }

    [Fact]
    public void DadoUmDescontoDeValor50_PedidoDeveCustar50()
    {
        var desconto = new Desconto(50, new DateTime(2024, 1, 1));
        var pedido = new Pedido(_clienteValido, 50, desconto);
        pedido.AdicionarItem(new Produto("Produto", 50, true), 1);
        Assert.Equal(50, pedido.Total);
    }

    [Fact]
    public void DadoUmPedidoCancelado_DeveRetornarStatusCancelado()
    {
        var pedido = new Pedido(_clienteValido, 10, _descontoValido);
        pedido.Cancelar();

        Assert.Equal(Domain.Enums.EStatusPedido.Cancelado, pedido.StatusPedido);
    }

    [Fact]
    public void DadoDesconto10ETaxaEntregue10_PedidoDeveContinuar50()
    {
        var desconto = new Desconto(10, new DateTime(2024, 1, 1));
        var pedido = new Pedido(_clienteValido, 10, desconto);
        pedido.AdicionarItem(new Produto("produto", 50, true), 1);

        Assert.Equal(50, pedido.Total);
    }

    [Fact]
    public void DadoTaxaDeEntrega10_DeveAcrescentar10AoPedidoDe50()
    {
        var descontoSemValor = new Desconto(0, DateTime.Now.AddDays(10));
        var pedido = new Pedido(_clienteValido, 10, descontoSemValor);
        pedido.AdicionarItem(new Produto("Produto", 50, true), 1);

        Assert.Equal(60, pedido.Total);
    }

    [Fact]
    public void DadoTaxaDeEntregaMenos1_NaoDeveCriarPedido()
    {
        var pedido = new Pedido(_clienteValido, -1, _descontoValido);
        pedido.Validate();

        Assert.False(pedido.IsValid);
    }

    [Fact]
    public void DadoUmProdutoNulo_NaoDeveAdicionarAListaItem()
    {
        var pedido = new Pedido(_clienteValido, 0, _descontoValido);
        pedido.AdicionarItem(null, 1);
        Assert.True(pedido.Items.Count == 0);
    }

    [Fact]
    public void DadoUmProdutoInvalido_NaoDeveAdicionarAListaItem()
    {
        var pedido = new Pedido(_clienteValido, 0, _descontoValido);
        pedido.AdicionarItem(new Produto("Produto", 50, false), 1);
        Assert.False(pedido.Items.Count > 0);
    }

    [Fact]
    public void Dado3ItensPedidos_PedidoDeveConter3Itens()
    {
        var pedido = new Pedido(_clienteValido, 0, _descontoValido);
        pedido.AdicionarItem(new Produto("Produto", 50, true), 1);
        pedido.AdicionarItem(new Produto("Produto1", 50, true), 1);
        pedido.AdicionarItem(new Produto("Produto2", 50, true), 1);
        Assert.True(pedido.Items.Count == 3);
    }

    [Fact]
    public void Dado3ItensPedidos_TotalPedidoDeveSer150()
    {
        var descontoSemValor = new Desconto(0, DateTime.Now.AddDays(10));
        var pedido = new Pedido(_clienteValido, 0, descontoSemValor);
        pedido.AdicionarItem(new Produto("Produto", 50, true), 1);
        pedido.AdicionarItem(new Produto("Produto1", 50, true), 1);
        pedido.AdicionarItem(new Produto("Produto2", 50, true), 1);
        Assert.Equal(150, pedido.Total);
    }

    [Fact]
    public void Dado10ProdutoDeValor50_DeveCriarUmPedidoDe500()
    {
        var descontoSemValor = new Desconto(0, DateTime.Now.AddDays(10));
        var pedido = new Pedido(_clienteValido, 0, descontoSemValor);
        pedido.AdicionarItem(new Produto("Produto", 50, true), 10);
        Assert.Equal(500, pedido.Total);
    }

    [Fact]
    public void AdicionadoUmItemALista_ListaNaoDeveConter0Item()
    {
        var pedido = new Pedido(_clienteValido, 0, _descontoValido);
        pedido.AdicionarItem(new Produto("Produto", 10, true), 1);
        Assert.True(pedido.Items.Count > 0);
    }
}

