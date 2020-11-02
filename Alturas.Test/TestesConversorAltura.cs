using System;
using Xunit;
using FluentAssertions;

namespace Alturas.Test
{
    public class TestesConversorAltura
    {
        [Theory]
        [InlineData(1, 0.3048)]
        [InlineData(10, 3.048)]
        [InlineData(55.5555, 16.9333)]
        [InlineData(100, 30.48)]
        public void TesteConversorAltura(double pes, double metros)
        {
            var resultado = ConversorAltura.PesParaMetros(pes);
            resultado.Should().Be(metros);
        }

    }
}
