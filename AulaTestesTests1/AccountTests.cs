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
            double saldo = 1.0;

            Assert.AreEqual(saldo, account.Balance);
        }

        [TestMethod()]
        public void WithdrawTestThrowException()
        {
            Account account = new Account();           
            Assert.ThrowsException<ArgumentException>(() => account.Withdraw(20));
        }

        [TestMethod()]
        public void storeAccountValoresPositivosTest()
        {
            Account account = new Account();
            account.Balance = 10.0;
            account.store(10.0);
            Assert.AreEqual(20.0, account.Balance);
        }

        [TestMethod()]
        public void storeAccountValoresNegativoThrowExceptionTest()
        {
            Account account = new Account();
            Assert.ThrowsException<ArgumentException>(() => account.store(-10));
        }
    }
}