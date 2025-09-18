using System;

namespace ToolkitProjeto.Modulos
{
    public static class Modulo1
    {
        private static readonly char[] Alfabeto = { 'a', 'b' };

        public static void Executar()
        {
            Console.WriteLine("\n--- Módulo 1: Verificador de Alfabeto e Cadeia ---");

            // Verificação de símbolo
            Console.Write("Digite um símbolo para verificar (a ou b): ");
            string? entradaSimbolo = Console.ReadLine();
            if (!string.IsNullOrEmpty(entradaSimbolo) && entradaSimbolo.Length == 1)
            {
                char simbolo = entradaSimbolo[0];
                if (VerificarSimbolo(simbolo))
                {
                    Console.WriteLine($"O símbolo '{simbolo}' é VÁLIDO no alfabeto {{a,b}}.");
                }
                else
                {
                    Console.WriteLine($"O símbolo '{simbolo}' é INVÁLIDO no alfabeto {{a,b}}.");
                }
            }
            else
            {
                Console.WriteLine("Entrada de símbolo inválida. Por favor, digite apenas um caractere.");
            }

            Console.WriteLine();

            // Verificação de cadeia
            Console.Write("Digite uma cadeia para verificar (composta por 'a' e 'b'): ");
            string? entradaCadeia = Console.ReadLine();
            if (entradaCadeia == null)
            {
                entradaCadeia = string.Empty;
            }

            if (VerificarCadeia(entradaCadeia))
            {
                Console.WriteLine($"A cadeia '{entradaCadeia}' é VÁLIDA no alfabeto {{a,b}}*.");
            }
            else
            {
                Console.WriteLine($"A cadeia '{entradaCadeia}' é INVÁLIDA no alfabeto {{a,b}}*.");
            }

            Console.WriteLine("--- Fim do Módulo 1 ---\n");
        }

        private static bool VerificarSimbolo(char simbolo)
        {
            foreach (char s in Alfabeto)
            {
                if (s == simbolo)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool VerificarCadeia(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                return true; // Cadeia vazia é válida em Σ*
            }

            foreach (char c in cadeia)
            {
                if (!VerificarSimbolo(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
