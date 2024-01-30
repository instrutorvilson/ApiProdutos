using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaTestes
{
    public class Calculadora
    {
        public double dividir(double v1, double v2)
        {
            if(v2 == 0) {
                throw new ArgumentException("Não é possivel dividir por zero");
            }
            return v1 / v2;
        }

        public double somar(double x, double y)
        {
            return x + y;
        }
    }
}
