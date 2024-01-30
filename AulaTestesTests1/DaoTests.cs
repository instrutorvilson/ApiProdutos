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
    public class DaoTests
    {
        private Pessoa pessoa;

        [TestInitialize]
        public void setup()
        {
            pessoa = new Pessoa() { Id = 1, Nome = "maria" };
        }

        [TestMethod()]
        public void addPessoaTest()
        {
            //Pessoa pessoa = new Pessoa() { Id=1, Nome="maria"};
           // pessoa = new Pessoa() { Id = 1, Nome = "maria" };
            Dao dao = new Dao();
            dao.addPessoa(pessoa);

            Assert.AreEqual(1, dao.Pessoas.Count());
        }

        [TestMethod()]
        public void ConsultaPessoaPorIdTest()
        {
            //Pessoa pessoa = new Pessoa() { Id = 1, Nome = "maria" };
           // pessoa = new Pessoa() { Id = 1, Nome = "maria" };
            Dao dao = new Dao();
            dao.addPessoa(pessoa);

            Pessoa p = dao.consultarPorId(1);

            Assert.AreNotEqual(p, null);
        }
    }
}