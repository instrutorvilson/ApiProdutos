using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaTestes
{
    public class Account
    {
        public double Balance { get; set; }

        public void store(double v)
        {
            if(v < 0)
            {
                throw new ArgumentException("Não pode existir depósito com valores negativos");
            }
            Balance += v;
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
            }
            else
            {
                throw new ArgumentException(nameof(amount), "Saldo insuficiente!");
            }
        }
    }
}
