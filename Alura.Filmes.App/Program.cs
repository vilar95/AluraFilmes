﻿using Alura.Filmes.App.Dados;
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
                Console.WriteLine("Clientes: ");
                foreach (var cliente in contexto.Clientes)
                {
                    Console.WriteLine(cliente);
                }
                Console.WriteLine("\nFunvionários: ");
                foreach (var func in contexto.Funcionarios)
                {
                    Console.WriteLine(func);
                }

                Console.WriteLine("Prescione qualquer tecla para continuar. . .");
                Console.ReadLine();
            }
        }
    }
}