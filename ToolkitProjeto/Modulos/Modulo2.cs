using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ToolkitProjeto.Modulos
{
    public class Problema
    {
        public string Nome { get; set; }
        public string ClassificacaoCorreta { get; set; }
    }

    public static class Modulo2
    {
        private static readonly string jsonProblemas = @"[
            {
                ""Nome"": ""Problema do Caixeiro Viajante (TSP)"",
                ""ClassificacaoCorreta"": ""I""
            },
            {
                ""Nome"": ""Ordenação de uma lista (ex: Merge Sort)"",
                ""ClassificacaoCorreta"": ""T""
            },
            {
                ""Nome"": ""Problema da Parada (Halting Problem)"",
                ""ClassificacaoCorreta"": ""N""
            },
            {
                ""Nome"": ""Busca em lista não ordenada"",
                ""ClassificacaoCorreta"": ""T""
            },
            {
                ""Nome"": ""Problema da Mochila (Knapsack Problem)"",
                ""ClassificacaoCorreta"": ""I""
            }
        ]";

        public static void Executar()
        {
            Console.WriteLine("\n--- Módulo 2: Classificador T/I/N por JSON ---");
            List<Problema>? problemas = JsonSerializer.Deserialize<List<Problema>>(jsonProblemas);

            if (problemas == null || problemas.Count == 0)
            {
                Console.WriteLine("Não foi possível carregar os problemas do JSON.");
                return;
            }

            int acertos = 0;
            int erros = 0;

            Console.WriteLine("Classifique cada problema como (T)ratável, (I)ntratável ou (N)ão Computável.");

            foreach (var problema in problemas)
            {
                string? entradaUsuario;
                bool entradaValida = false;
                do
                {
                    Console.Write($"\nProblema: {problema.Nome} [T/I/N]: ");
                    entradaUsuario = Console.ReadLine()?.ToUpper();

                    if (entradaUsuario == "T" || entradaUsuario == "I" || entradaUsuario == "N")
                    {
                        entradaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite T, I ou N.");
                    }
                } while (!entradaValida);

                if (entradaUsuario == problema.ClassificacaoCorreta)
                {
                    Console.WriteLine("Correto!");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"Errado. A classificação correta é: {problema.ClassificacaoCorreta}");
                    erros++;
                }
            }

            Console.WriteLine("\n--- Resumo Final ---");
            Console.WriteLine($"Acertos: {acertos}");
            Console.WriteLine($"Erros: {erros}");
            Console.WriteLine("--- Fim do Módulo 2 ---\n");
        }
    }
}
