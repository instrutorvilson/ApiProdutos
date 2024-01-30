using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaTestes
{
    public class Dao
    {
        public List<Pessoa> Pessoas { get; } 

        public Dao() { 
            Pessoas = new List<Pessoa>();
        }

        public void addPessoa(Pessoa pessoa)
        {
            Pessoas.Add(pessoa);
        }

        public Pessoa consultarPorId(int v)
        {
            return Pessoas.FirstOrDefault(p => p.Id == v);
        }
    }
}
