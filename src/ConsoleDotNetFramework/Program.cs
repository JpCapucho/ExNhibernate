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
            var session = NHibernateHelper.GetCurrentSession();

            var pessoa1 = new Pessoa("João Paulo");

            session.Save(pessoa1);
        }
    }
}
