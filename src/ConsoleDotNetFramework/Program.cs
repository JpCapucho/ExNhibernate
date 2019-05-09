using ConsoleDotNetFramework.Model;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //cria uma session
            var session = NHibernateHelper.GetCurrentSession();

            //cria um objeto (classe mapeada)
            var pessoa1 = new Pessoa("João Paulo");

            //salvando obj
            session.Save(pessoa1);
        }
    }
}
