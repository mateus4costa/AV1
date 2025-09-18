using System;
using System.Linq;

namespace ToolkitProjeto.Modulos
{
    public static class Modulo3
    {
        private static readonly char[] Alfabeto = { 'a', 'b' };

        public static void Executar()
        {
            Console.WriteLine("\n--- Módulo 3: Programa de Decisão: \"termina com 'b'?\" ---");

            Console.Write("Digite uma cadeia sobre \u03A3={a,b} para verificar: ");
            string? cadeia = Console.ReadLine();

            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("A cadeia vazia não termina com 'b'. SAIDA: NAO");
                Console.WriteLine("--- Fim do Módulo 3 ---\n");
                return;
            }

            // Validação do alfabeto
            if (!cadeia.All(c => Alfabeto.Contains(c)))
            {
                Console.WriteLine("Cadeia inválida: contém símbolos fora do alfabeto \u03A3={a,b}. SAIDA: NAO");
                Console.WriteLine("--- Fim do Módulo 3 ---\n");
                return;
            }

            if (cadeia.EndsWith('b'))
            {
                Console.WriteLine("SAIDA: SIM");
            }
            else
            {
                Console.WriteLine("SAIDA: NAO");
            }

            Console.WriteLine("--- Fim do Módulo 3 ---\n");
        }
    }
}
