using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework.Model
{
    public class Pessoa
    {
        public virtual long  Id { get; set; }

        public virtual string Nome { get; set; }

        public Pessoa() { }

        public Pessoa(string _nome)
        {
            if(String.IsNullOrEmpty(_nome))
            {
                //not-null
                throw new NullReferenceException("O campo  nao pode estar vazio ou não preenchido!");
            }

            this.Nome = _nome;
        }
    }
}
