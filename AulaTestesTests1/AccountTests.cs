using Microsoft.VisualStudio.TestTools.UnitTesting;
using AulaTestes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AulaTestes.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod]
        public void WithdrawTest()
        {
            Account account = new Account();
            account.Balance = 10.0;
            account.Withdraw(9.0);
            double valor_esperado = 1.0;

            Assert.AreEqual(valor_esperado, account.Balance);
        }

        [TestMethod()]
        public void WithdrawTestThrowException()
        {
            Account account = new Account();
           
            Assert.ThrowsException<ArgumentException>(() => account.Withdraw(20));
        }
    }
}