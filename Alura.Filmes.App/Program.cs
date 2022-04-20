using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";
                var registros = contexto.Database.ExecuteSqlCommand(sql);
                Console.WriteLine($"O total de registros afetados é {registros}.");

                var deleteSql = "DELETE FROM  language WHERE name LIKE 'Teste%'";
                registros = contexto.Database.ExecuteSqlCommand(deleteSql);
                Console.WriteLine($"O total de registros afetados é {registros}.");

                //var sql = @"select a.* from actor a
                //        inner join top5_most_starred_actors 
                //        filmes on filmes.actor_id = a.actor_id";

                //var atoresMaisAtuantes = contexto.Atores
                //    .FromSql(sql)
                //    .Include(a => a.Filmografia);

                //foreach (var ator in atoresMaisAtuantes)
                //{
                //    Console.WriteLine($"O Ator {ator.PrimeiroNome} {ator.UltimoNome} atuou em {ator.Filmografia.Count} filmes.");
                //}

                //Console.WriteLine("Clientes: ");
                //foreach (var cliente in contexto.Clientes)
                //{
                //    Console.WriteLine(cliente);
                //}
                //Console.WriteLine("\nFunvionários: ");
                //foreach (var func in contexto.Funcionarios)
                //{
                //    Console.WriteLine(func);
                //}

                Console.WriteLine("Prescione qualquer tecla para continuar. . .");
                Console.ReadLine();
            }
            
        }
        static void StoredProcedure(DbContext contexto)
        {
             var categ = "Action";
             var paramCateg = new SqlParameter("category_name", categ);
             var paramTotal = new SqlParameter
             {
                 ParameterName = "@total_actors",
                 Size = 4,
                 Direction = System.Data.ParameterDirection.Output
             };

             contexto.Database
                 .ExecuteSqlCommand(
                 "total_actors_from_given_category @category_name, @total_actors OUT",
                 paramCateg,
                 paramTotal);

             Console.WriteLine($"O total de atores na categoria {categ} é de {paramTotal.Value}.");
        }
    }
}