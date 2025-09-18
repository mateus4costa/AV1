using System;
using System.Collections.Generic;

namespace ToolkitProjeto.Modulos
{
    public static class Modulo4
    {
        public static void Executar()
        {
            Console.WriteLine("\n--- Módulo 4: Avaliador Proposicional Básico ---");

            bool p, q, r;

            // Obter valores de P, Q, R
            p = ObterValorBooleano("P");
            q = ObterValorBooleano("Q");
            r = ObterValorBooleano("R");

            bool continuarModulo = true;
            while (continuarModulo)
            {
                Console.WriteLine("\nSelecione uma fórmula para avaliar:");
                Console.WriteLine("1. P E Q");
                Console.WriteLine("2. P IMPLICA (Q OU R)");
                Console.WriteLine("0. Voltar ao menu principal");
                Console.Write("Opção: ");

                string? opcaoFormula = Console.ReadLine();

                switch (opcaoFormula)
                {
                    case "1":
                        AvaliarFormula1(p, q);
                        GerarTabelaVerdade("P E Q", (valP, valQ, valR) => valP && valQ, 2);
                        break;
                    case "2":
                        AvaliarFormula2(p, q, r);
                        GerarTabelaVerdade("P IMPLICA (Q OU R)", (valP, valQ, valR) => !valP || (valQ || valR), 3);
                        break;
                    case "0":
                        continuarModulo = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }

            Console.WriteLine("--- Fim do Módulo 4 ---\n");
        }

        private static bool ObterValorBooleano(string variavel)
        {
            string? entrada;
            bool valor;
            while (true)
            {
                Console.Write($"Digite o valor para {variavel} (V para Verdadeiro, F para Falso): ");
                entrada = Console.ReadLine()?.ToUpper();
                if (entrada == "V")
                {
                    valor = true;
                    break;
                }
                else if (entrada == "F")
                {
                    valor = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite V ou F.");
                }
            }
            return valor;
        }

        private static void AvaliarFormula1(bool p, bool q)
        {
            bool resultado = p && q;
            Console.WriteLine($"\nResultado da fórmula 'P E Q' com P={p}, Q={q}: {resultado}");
        }

        private static void AvaliarFormula2(bool p, bool q, bool r)
        {
            bool resultado = !p || (q || r);
            Console.WriteLine($"\nResultado da fórmula 'P IMPLICA (Q OU R)' com P={p}, Q={q}, R={r}: {resultado}");
        }

        private static void GerarTabelaVerdade(string nomeFormula, Func<bool, bool, bool, bool> funcaoAvaliacao, int numVariaveis)
        {
            Console.Write("Deseja imprimir a tabela-verdade completa para esta fórmula? (S/N): ");
            string? opcaoTabela = Console.ReadLine()?.ToUpper();

            if (opcaoTabela == "S")
            {
                Console.WriteLine($"\n--- Tabela-Verdade para {nomeFormula} ---");
                if (numVariaveis == 2)
                {
                    Console.WriteLine("P\tQ\tResultado");
                    Console.WriteLine("------------------------");
                    for (int i = 0; i < 4; i++)
                    {
                        bool valP = (i & 2) != 0;
                        bool valQ = (i & 1) != 0;
                        bool resultado = funcaoAvaliacao(valP, valQ, false); // R não é usado para 2 variáveis
                        Console.WriteLine($"{valP}\t{valQ}\t{resultado}");
                    }
                }
                else if (numVariaveis == 3)
                {
                    Console.WriteLine("P\tQ\tR\tResultado");
                    Console.WriteLine("--------------------------------");
                    for (int i = 0; i < 8; i++)
                    {
                        bool valP = (i & 4) != 0;
                        bool valQ = (i & 2) != 0;
                        bool valR = (i & 1) != 0;
                        bool resultado = funcaoAvaliacao(valP, valQ, valR);
                        Console.WriteLine($"{valP}\t{valQ}\t{valR}\t{resultado}");
                    }
                }
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
