using System;
using Xunit;
using AvanadeTheFuture;
using System.ComponentModel;

namespace TestAvanadeTheFuture
{
    public class UniTest1()
    {
        public Calculadora ConstruirClasse()
        {
            string data = "23/05/2024";
            Calculadora calc = new Calculadora("23/05/2024");

            return calc;
        }

        [Theory]
        [InlineData (1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TestSomar1(int val1, int val2, int resultado)
        {
            //Arrenge
            Calculadora calc = ConstruirClasse();

            //Act
            int resultadoCalculadora = calc.somar(val1, val2);

            //Assert
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(4, 5, 20)]
        public void TestMultipicar(int val1, int val2, int resultado)
        {
            //Arrenge
            Calculadora calc = ConstruirClasse();

            //Act
            int resultadoCalculadora = calc.multiplicar(val1, val2);

            //Assert
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(5, 5, 1)]
        public void TestDividir(int val1, int val2, int resultado)
        {
            //Arrenge
            Calculadora calc = ConstruirClasse();

            //Act
            int resultadoCalculadora = calc.dividir(val1, val2);

            //Assert
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Theory]
        [InlineData(6, 2, 4)]
        [InlineData(5, 5, 0)]
        public void TestSubtrair(int val1, int val2, int resultado)
        {
            //Arrenge
            Calculadora calc = ConstruirClasse();

            //Act
            int resultadoCalculadora = calc.subtrair(val1, val2);

            //Assert
            Assert.Equal(resultado, resultadoCalculadora);
        }

        [Fact]
        public void TestarDivisaoPorZero()
        {
            Calculadora calculadora = ConstruirClasse();

            Assert.Throws<DivideByZeroException>(() => calculadora.dividir(3, 0));
        }

        [Fact]
        public void TestarHistorico()
        {
            Calculadora calc = ConstruirClasse();

            calc.somar(1, 2);
            calc.somar(2, 8);
            calc.somar(3, 7);
            calc.somar(4, 1);

            var lista = calc.historico();

            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }   
}