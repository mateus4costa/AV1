using System;
using System.Linq;

namespace ToolkitProjeto.Modulos
{
    public static class Modulo5
    {
        private static readonly char[] Alfabeto = { 'a', 'b' };

        public static void Executar()
        {
            Console.WriteLine("\n--- Módulo 5: Reconhecedor de Linguagens ---");

            string? cadeia;
            bool continuarModulo = true;

            while (continuarModulo)
            {
                Console.Write("Digite uma cadeia sobre \u03A3={a,b} (ou '0' para voltar): ");
                cadeia = Console.ReadLine();

                if (cadeia == "0")
                {
                    continuarModulo = false;
                    continue;
                }

                if (string.IsNullOrEmpty(cadeia))
                {
                    Console.WriteLine("Cadeia vazia. Por favor, digite uma cadeia não vazia ou '0' para voltar.");
                    continue;
                }

                // Validação do alfabeto
                if (!cadeia.All(c => Alfabeto.Contains(c)))
                {
                    Console.WriteLine("Cadeia INVÁLIDA: contém símbolos fora do alfabeto \u03A3={a,b}.");
                    continue;
                }

                Console.WriteLine("\nSelecione a linguagem para verificar:");
                Console.WriteLine("1. L_par_a (cadeias com número par de 'a's)");
                Console.WriteLine("2. L = { w | w = a b* } (cadeias que começam com 'a' seguido de zero ou mais 'b's)");
                Console.Write("Opção: ");

                string? opcaoLinguagem = Console.ReadLine();

                switch (opcaoLinguagem)
                {
                    case "1":
                        if (ReconhecerLParA(cadeia))
                        {
                            Console.WriteLine($"Cadeia \'{cadeia}\' ACEITA em L_par_a.");
                        }
                        else
                        {
                            Console.WriteLine($"Cadeia \'{cadeia}\' REJEITA em L_par_a.");
                        }
                        break;
                    case "2":
                        if (ReconhecerLAbEstrela(cadeia))
                        {
                            Console.WriteLine($"Cadeia \'{cadeia}\' ACEITA em L = {{ w | w = a b* }}.");
                        }
                        else
                        {
                            Console.WriteLine($"Cadeia \'{cadeia}\' REJEITA em L = {{ w | w = a b* }}.");
                        }
                        break;
                    default:
                        Console.WriteLine("Opção de linguagem inválida. Tente novamente.");
                        break;
                }
            }

            Console.WriteLine("--- Fim do Módulo 5 ---\n");
        }

        private static bool ReconhecerLParA(string cadeia)
        {
            int countA = 0;
            foreach (char c in cadeia)
            {
                if (c == 'a')
                {
                    countA++;
                }
            }
            return countA % 2 == 0;
        }

        private static bool ReconhecerLAbEstrela(string cadeia)
        {
            if (string.IsNullOrEmpty(cadeia))
            {
                return false; // Cadeia vazia não começa com 'a'
            }

            if (cadeia[0] != 'a')
            {
                return false; // Não começa com 'a'
            }

            for (int i = 1; i < cadeia.Length; i++)
            {
                if (cadeia[i] != 'b')
                {
                    return false; // Contém algo diferente de 'b' após o primeiro 'a'
                }
            }
            return true;
        }
    }
}
