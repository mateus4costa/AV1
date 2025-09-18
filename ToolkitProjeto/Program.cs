using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

// Define o namespace para organizar o código.
namespace ProjetoToolkit
{
    /// <summary>
    /// Classe principal que contém o menu e os módulos do toolkit.
    /// </summary>
    public static class Program
    {
        // Define o alfabeto global para o projeto.
        private static readonly HashSet<char> Alfabeto = new HashSet<char> { 'a', 'b' };

        /// <summary>
        /// Ponto de entrada do programa. Exibe o menu principal em um loop.
        /// </summary>
        public static void Main()
        {
            // Define o encoding do console para UTF-8 para exibir acentos corretamente.
            Console.OutputEncoding = Encoding.UTF8;
            bool continuar = true;

            // Loop principal que exibe o menu até o usuário decidir sair.
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("==========     PROJETO TOOLKIT     ==========");
                Console.WriteLine("=============================================");
                Console.WriteLine("Escolha um módulo para executar:");
                Console.WriteLine("1. Verificador de Alfabeto e Cadeia (Σ={a,b})");
                Console.WriteLine("2. Classificador de Problemas (T/I/N)");
                Console.WriteLine("3. Programa de Decisão: 'Termina com b?'");
                Console.WriteLine("4. Avaliador Proposicional Básico");
                Console.WriteLine("5. Reconhecedor de Linguagens (L_par_a e ab*)");
                Console.WriteLine("0. Sair do Programa");
                Console.WriteLine("---------------------------------------------");
                Console.Write("Digite sua opção: ");

                string? entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "1":
                        ModuloVerificadorAlfabeto();
                        break;
                    case "2":
                        ModuloClassificadorTIN();
                        break;
                    case "3":
                        ModuloProgramaDecisao();
                        break;
                    case "4":
                        ModuloAvaliadorProposicional();
                        break;
                    case "5":
                        ModuloReconhecedorLinguagens();
                        break;
                    case "0":
                        continuar = false;
                        Console.WriteLine("\nEncerrando o programa. Até logo!");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }

                // Pausa antes de voltar ao menu principal, exceto ao sair.
                if (continuar)
                {
                    Console.WriteLine("\n---------------------------------------------");
                    Console.Write("Pressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
            }
        }

        #region Módulo 1: Verificador de Alfabeto

        /// <summary>
        /// Módulo para verificar se um símbolo e uma cadeia pertencem ao alfabeto Σ={a,b}.
        /// </summary>
        private static void ModuloVerificadorAlfabeto()
        {
            Console.Clear();
            Console.WriteLine("--- Módulo 1: Verificador de Alfabeto e Cadeia ---");

            // 1. Verificação de Símbolo Individual
            Console.Write("Digite um único símbolo para verificar: ");
            string? entradaSimbolo = Console.ReadLine();

            // Validação da entrada do símbolo
            if (string.IsNullOrEmpty(entradaSimbolo) || entradaSimbolo.Length != 1)
            {
                Console.WriteLine("Entrada inválida. Você deve digitar exatamente um símbolo.");
            }
            else
            {
                char simbolo = entradaSimbolo[0];
                if (Alfabeto.Contains(simbolo))
                {
                    Console.WriteLine($"SAÍDA: O símbolo '{simbolo}' é VÁLIDO (pertence a Σ={{a,b}}).");
                }
                else
                {
                    Console.WriteLine($"SAÍDA: O símbolo '{simbolo}' é INVÁLIDO (não pertence a Σ={{a,b}}).");
                }
            }

            Console.WriteLine("\n" + new string('-', 20) + "\n");

            // 2. Verificação de Cadeia Completa
            Console.Write("Agora, digite uma cadeia para verificar: ");
            string? cadeia = Console.ReadLine();
            
            // A cadeia nula/vazia é considerada válida em Σ*
            if (cadeia == null) cadeia = string.Empty;

            if (CadeiaValida(cadeia))
            {
                Console.WriteLine($"SAÍDA: A cadeia '{cadeia}' é VÁLIDA (pertence a Σ*).");
            }
            else
            {
                Console.WriteLine($"SAÍDA: A cadeia '{cadeia}' é INVÁLIDA (contém símbolos fora de Σ).");
            }
        }

        #endregion

        #region Módulo 2: Classificador T/I/N

        // Classe para representar um problema computacional do JSON.
        public class ProblemaComputacional
        {
            public string Nome { get; set; } = "";
            public string CategoriaCorreta { get; set; } = "";
        }

        /// <summary>
        /// Módulo para classificar problemas como Tratável, Intratável ou Não Computável.
        /// </summary>
        private static void ModuloClassificadorTIN()
        {
            Console.Clear();
            Console.WriteLine("--- Módulo 2: Classificador de Problemas (T/I/N) ---");
            Console.WriteLine("Classifique cada problema como:");
            Console.WriteLine("T - Tratável");
            Console.WriteLine("I - Intratável");
            Console.WriteLine("N - Não Computável\n");

            // JSON embutido diretamente no código.
            string jsonProblemas = @"
            [
              {
                ""Nome"": ""Verificar se uma lista de N números está ordenada"",
                ""CategoriaCorreta"": ""T""
              },
              {
                ""Nome"": ""Encontrar o caminho mais curto em um mapa (Problema do Caixeiro Viajante)"",
                ""CategoriaCorreta"": ""I""
              },
              {
                ""Nome"": ""Determinar se um programa de computador qualquer irá parar (Problema da Parada)"",
                ""CategoriaCorreta"": ""N""
              },
              {
                ""Nome"": ""Multiplicar duas matrizes de tamanho N x N"",
                ""CategoriaCorreta"": ""T""
              }
            ]";

            try
            {
                // Desserializa o JSON para uma lista de objetos.
                List<ProblemaComputacional>? problemas = JsonSerializer.Deserialize<List<ProblemaComputacional>>(jsonProblemas);

                if (problemas == null || problemas.Count == 0)
                {
                    Console.WriteLine("Não foi possível carregar a lista de problemas.");
                    return;
                }

                int acertos = 0;
                int erros = 0;

                // Itera sobre cada problema, pedindo a classificação do usuário.
                foreach (ProblemaComputacional problema in problemas)
                {
                    Console.WriteLine($"Problema: {problema.Nome}");
                    string? respostaUsuario;
                    do
                    {
                        Console.Write("Sua classificação (T/I/N): ");
                        respostaUsuario = Console.ReadLine()?.ToUpper();
                    } while (respostaUsuario != "T" && respostaUsuario != "I" && respostaUsuario != "N");

                    if (respostaUsuario == problema.CategoriaCorreta)
                    {
                        Console.WriteLine("Resposta CORRETA!\n");
                        acertos++;
                    }
                    else
                    {
                        Console.WriteLine($"Resposta INCORRETA. A classificação correta é '{problema.CategoriaCorreta}'.\n");
                        erros++;
                    }
                }
                
                // Exibe o resumo final.
                Console.WriteLine("================ RESUMO FINAL ================");
                Console.WriteLine($"Total de Acertos: {acertos}");
                Console.WriteLine($"Total de Erros: {erros}");
                Console.WriteLine("============================================");

            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro ao processar o JSON interno: {ex.Message}");
            }
        }


        #endregion

        #region Módulo 3: Programa de Decisão

        /// <summary>
        /// Módulo que decide se uma cadeia sobre Σ={a,b} termina com 'b'.
        /// </summary>
        private static void ModuloProgramaDecisao()
        {
            Console.Clear();
            Console.WriteLine("--- Módulo 3: Programa de Decisão: 'Termina com b?' ---");
            Console.Write("Digite uma cadeia sobre o alfabeto Σ={a,b}: ");
            string? cadeia = Console.ReadLine();
            
            // A cadeia nula é tratada como vazia.
            if (cadeia == null) cadeia = string.Empty;

            // Pré-condição: validação da cadeia.
            if (!CadeiaValida(cadeia))
            {
                Console.WriteLine("\nERRO: A cadeia informada contém símbolos que não pertencem a Σ={a,b}.");
                return;
            }

            // Regra de decisão (sempre termina).
            // Trata caso vazio e verifica o último caractere.
            if (!string.IsNullOrEmpty(cadeia) && cadeia.EndsWith('b'))
            {
                Console.WriteLine("\nSAÍDA: SIM");
            }
            else
            {
                Console.WriteLine("\nSAÍDA: NAO");
            }
        }

        #endregion

        #region Módulo 4: Avaliador Proposicional

        /// <summary>
        /// Módulo para avaliar fórmulas proposicionais e gerar tabelas-verdade.
        /// </summary>
        private static void ModuloAvaliadorProposicional()
        {
            Console.Clear();
            Console.WriteLine("--- Módulo 4: Avaliador Proposicional Básico ---");

            // Entrada dos valores de P, Q, R
            bool valorP = LerValorBooleano("Digite o valor para P (true/false): ");
            bool valorQ = LerValorBooleano("Digite o valor para Q (true/false): ");
            bool valorR = LerValorBooleano("Digite o valor para R (true/false): ");

            Console.WriteLine($"\nValores definidos: P={valorP}, Q={valorQ}, R={valorR}\n");
            
            // Menu de fórmulas
            Console.WriteLine("Escolha uma fórmula para avaliar:");
            Console.WriteLine("1. Conjunção e Disjunção: (P ∧ Q) ∨ R");
            Console.WriteLine("2. Implicação e Negação: (P → ¬Q)");
            Console.Write("Opção: ");

            string? escolhaFormula = Console.ReadLine();

            switch (escolhaFormula)
            {
                case "1":
                    AvaliarEGerarTabelaFormula1(valorP, valorQ, valorR);
                    break;
                case "2":
                    AvaliarEGerarTabelaFormula2(valorP, valorQ, valorR);
                    break;
                default:
                    Console.WriteLine("Opção de fórmula inválida.");
                    break;
            }
        }
        
        /// <summary>
        /// Avalia a fórmula (P ∧ Q) ∨ R e pergunta sobre a tabela-verdade.
        /// </summary>
        private static void AvaliarEGerarTabelaFormula1(bool p, bool q, bool r)
        {
            string formula = "(P ∧ Q) ∨ R";
            bool resultado = (p && q) || r;
            Console.WriteLine($"\nResultado de {formula}: {resultado}");
            
            Console.Write("\nDeseja ver a tabela-verdade completa para esta fórmula? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                Console.WriteLine($"\n--- Tabela-Verdade para {formula} ---");
                Console.WriteLine("|  P  |  Q  |  R  | Resultado |");
                Console.WriteLine("|-----|-----|-----|-----------|");
                foreach (bool valP in new[] { true, false })
                {
                    foreach (bool valQ in new[] { true, false })
                    {
                        foreach (bool valR in new[] { true, false })
                        {
                            bool res = (valP && valQ) || valR;
                            Console.WriteLine($"| {valP,-3} | {valQ,-3} | {valR,-3} | {res,-9} |");
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Avalia a fórmula (P → ¬Q) e pergunta sobre a tabela-verdade.
        /// </summary>
        private static void AvaliarEGerarTabelaFormula2(bool p, bool q, bool r)
        {
            string formula = "(P → ¬Q)";
            // Lembre-se que (P → Q) é equivalente a (¬P ∨ Q)
            bool resultado = !p || !q; 
            Console.WriteLine($"\nResultado de {formula}: {resultado}");
            Console.WriteLine("(Nota: O valor de R não afeta o resultado desta fórmula específica)");

            Console.Write("\nDeseja ver a tabela-verdade completa para esta fórmula? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                Console.WriteLine($"\n--- Tabela-Verdade para {formula} ---");
                Console.WriteLine("|  P  |  Q  | Resultado |");
                Console.WriteLine("|-----|-----|-----------|");
                foreach (bool valP in new[] { true, false })
                {
                    foreach (bool valQ in new[] { true, false })
                    {
                        bool res = !valP || !valQ;
                        Console.WriteLine($"| {valP,-3} | {valQ,-3} | {res,-9} |");
                    }
                }
            }
        }

        #endregion

        #region Módulo 5: Reconhecedor de Linguagens

        /// <summary>
        /// Módulo que decide se uma cadeia pertence a L_par_a ou L = ab*.
        /// </summary>
        private static void ModuloReconhecedorLinguagens()
        {
            Console.Clear();
            Console.WriteLine("--- Módulo 5: Reconhecedor de Linguagens (Σ={a,b}) ---");
            Console.WriteLine("Escolha a linguagem para o reconhecimento:");
            Console.WriteLine("1. L_par_a (cadeias com número par de 'a')");
            Console.WriteLine("2. L = { w | w = ab* } (cadeias que começam com 'a' seguido de zero ou mais 'b's)");
            Console.Write("Opção: ");

            string? escolhaLinguagem = Console.ReadLine();
            
            if (escolhaLinguagem != "1" && escolhaLinguagem != "2")
            {
                Console.WriteLine("Opção de linguagem inválida.");
                return;
            }
            
            Console.Write("\nDigite a cadeia a ser reconhecida: ");
            string? cadeia = Console.ReadLine();
            
            // A cadeia nula é tratada como vazia.
            if (cadeia == null) cadeia = string.Empty;
            
            // Validação do alfabeto antes da decisão.
            if (!CadeiaValida(cadeia))
            {
                Console.WriteLine("\nERRO: A cadeia informada não pertence a Σ*.");
                return;
            }

            bool aceita = false;
            if (escolhaLinguagem == "1")
            {
                // Lógica para L_par_a
                int contagemA = 0;
                foreach(char c in cadeia)
                {
                    if (c == 'a')
                    {
                        contagemA++;
                    }
                }
                aceita = (contagemA % 2 == 0);
            }
            else // escolhaLinguagem == "2"
            {
                // Lógica para L = ab*
                if (string.IsNullOrEmpty(cadeia))
                {
                    aceita = false;
                }
                else if (cadeia[0] != 'a')
                {
                    aceita = false;
                }
                else
                {
                    // Começa com 'a', agora verifica se o resto é só 'b'
                    aceita = true; // Assume que aceita e procura por uma falha
                    for (int i = 1; i < cadeia.Length; i++)
                    {
                        if (cadeia[i] != 'b')
                        {
                            aceita = false;
                            break;
                        }
                    }
                }
            }
            
            // Saída final
            if (aceita)
            {
                Console.WriteLine("\nSAÍDA: ACEITA");
            }
            else
            {
                Console.WriteLine("\nSAÍDA: REJEITA");
            }
        }

        #endregion

        #region Funções Auxiliares

        /// <summary>
        /// Verifica se todos os caracteres de uma cadeia pertencem ao alfabeto {a,b}.
        /// </summary>
        /// <param name="cadeia">A cadeia a ser verificada.</param>
        /// <returns>True se a cadeia for válida, False caso contrário.</returns>
        private static bool CadeiaValida(string cadeia)
        {
            // Itera sobre cada caractere da cadeia.
            foreach (char c in cadeia)
            {
                // Se um caractere não estiver no alfabeto, a cadeia é inválida.
                if (!Alfabeto.Contains(c))
                {
                    return false;
                }
            }
            // Se o loop terminar, todos os caracteres são válidos.
            return true;
        }

        /// <summary>
        /// Lê e valida uma entrada booleana do usuário.
        /// </summary>
        /// <param name="mensagem">A mensagem para exibir ao usuário.</param>
        /// <returns>O valor booleano inserido pelo usuário.</returns>
        private static bool LerValorBooleano(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? input = Console.ReadLine()?.ToLower();
                if (input == "true" || input == "t" || input == "1" || input == "v")
                {
                    return true;
                }
                if (input == "false" || input == "f" || input == "0")
                {
                    return false;
                }
                Console.WriteLine("Entrada inválida. Por favor, digite 'true' ou 'false'.");
            }
        }
        
        #endregion
    }
}