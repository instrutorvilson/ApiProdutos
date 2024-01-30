using Microsoft.VisualStudio.TestTools.UnitTesting;
using AulaTestes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaTestes.Tests
{
    [TestClass()]
    public class CalculadoraTests
    {
        [TestMethod()]
        public void dividirQuandoDivisorDiferenteDeZeroTest()
        {
            Calculadora calculadora = new Calculadora();
            double retorno = calculadora.dividir(100.0, 2.0);
            Assert.AreEqual(retorno, 50.0);
        }

        [TestMethod()]
        public void dividirQuandoDivisorIgualZeroLancaExcecaoTest()
        {
            Calculadora calculadora = new Calculadora();
            Action action = () => calculadora.dividir(100.0, 0.0);

            Assert.ThrowsException<ArgumentException>(action);
        }
    }
}