using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleDotNetCore.Models
{
    public class Pessoa
    {
        public virtual long Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual int Idade { get; set; }

    }
}
