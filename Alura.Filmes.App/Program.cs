using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
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

                
                var filme = new Filme();
                filme.Titulo = "Senhor dos Aneis";
                filme.Duracao = 120;
                filme.AnoLancamento = "2000";
                filme.Classificacao = "Qualquer";
                filme.IdiomaFalado = contexto.Idiomas.First();
                contexto.Entry(filme).Property("last_update").CurrentValue = DateTime.Now;
                contexto.Filmes.Add(filme);
                contexto.SaveChanges();

                Console.WriteLine("Prescione qualquer tecla para continuar. . .");
                Console.ReadLine();
            }
        }
    }
}