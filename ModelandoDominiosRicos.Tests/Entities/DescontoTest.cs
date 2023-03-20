using System;
using ModelandoDominiosRicos.Domain.Entities;

namespace ModelandoDominiosRicos.Tests.Entities;

public class DescontoTest
{
    private readonly DateTime _dataValido = new DateTime(2024, 1, 1);
    private readonly DateTime _dataInvalido = new DateTime(2019, 1, 1);

    [Fact]
    public void DeveCriarDescontoValido()
    {
        var desconto = new Desconto(10m, _dataValido);
        desconto.Validate();
        Assert.True(desconto.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarDescontoComDataInferiorA2020()
    {
        var desconto = new Desconto(10m, _dataInvalido);
        desconto.Validate();
        Assert.False(desconto.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarDescontoComValorMenorOuIgual0()
    {
        var desconto = new Desconto(0m, _dataValido);
        desconto.Validate();
        Assert.False(desconto.IsValid);
    }

    [Fact]
    public void DeveFalharAoCriarDescontoComValorComMaisDeDuasCasasDecimais()
    {
        var desconto = new Desconto(10.032302m, _dataValido);
        desconto.Validate();
        Assert.False(desconto.IsValid);
    }

    [Fact]
    public void DeveObterDescontoValidoCasoDataSejaNoFuturo()
    {
        var desconto = new Desconto(10.20m, new DateTime(2024, 1, 1));
        Assert.True(desconto.DescontoValido());
    }
    [Fact]
    public void DeveObterDescontoInvalidoCasoDataSejaNoPassado()
    {
        var desconto = new Desconto(10.20m, new DateTime(2021, 1, 1));
        Assert.False(desconto.DescontoValido());
    }

    [Fact]
    public void DeveFalharAoObterValorDoDescontoExpirado()
    {
        var desconto = new Desconto(10.20m, new DateTime(2021, 1, 1));

        Assert.NotEqual(10.20m, desconto.ValorDesconto);
    }

    [Fact]
    public void DeveObterValorDoDescontoQueNaoEstejaExpirado()
    {
        var desconto = new Desconto(10.20m, new DateTime(2024, 1, 1));
        
        Assert.Equal(10.20m, desconto.ValorDesconto);
    }

    [Fact]
    public void DadoUmDescontoCom4CasasDecimais_DeveRetonarSucesso()
    {
        var desconto = new Desconto(1050.00m, new DateTime(2024, 1, 1));

        Assert.Equal(1050.00m, desconto.ValorDesconto);
    }
}

