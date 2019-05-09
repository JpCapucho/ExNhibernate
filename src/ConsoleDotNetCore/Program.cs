using ConsoleDotNetCore.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleDotNetCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sessionFactory = Fluently
                .Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(@"Data Source=|DataDirectory|ConsoleDotNetCore.db;Version=3"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(config =>
                {
                        var schemaExport = new SchemaExport(config); //  NHibernate.Tool.hbm2ddl
                        schemaExport.Execute(true, true, false);
                })
                .BuildSessionFactory();

            var session = sessionFactory.OpenSession();

            Console.Write("Digite o nome da pessoa = ");
            var name = Console.ReadLine();

            Console.Write("Digite a idade da pessoa = ");
            var idade = Convert.ToInt32( Console.ReadLine() );

            var pessoa = new Pessoa { Nome = name, Idade = idade };
            await session.SaveOrUpdateAsync(pessoa);
            await session.FlushAsync();

            var pessoas = session.Query<Pessoa>()
                .Where(p => p.Idade > 18)
                .ToList();

            Console.WriteLine($"Pessoas com idade acima de 18 anos: ");
            pessoas.ForEach(x => Console.WriteLine($"{x.Nome} -> {x.Idade}"));

            Console.WriteLine($"Aperte qualquer tecla para continuar. ");
            Console.Read();

            session.Close();
        }
    }
}
