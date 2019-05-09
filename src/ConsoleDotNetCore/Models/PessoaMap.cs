using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;

namespace ConsoleDotNetCore.Models
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
            Map(x => x.Idade);
        }
    }
}
