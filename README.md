# Projeto Toolkit em C#

Este é um aplicativo de console desenvolvido em C# (.NET 9) como um toolkit de ferramentas para a disciplina de **COMPUTAÇÃO CIENTÍFICA**. O projeto consolida cinco módulos distintos, cada um abordando um conceito específico de teoria da computação e lógica, acessíveis através de um menu interativo.

## 📋 Módulos Incluídos

O toolkit oferece as seguintes funcionalidades:

### Item 1 — Verificador de Alfabeto e Cadeia em Σ={a,b}

*   **Objetivo:** Checar se um símbolo individual e uma cadeia completa pertencem ao alfabeto `Σ={a,b}`.
*   **Funcionalidade:**
    *   Solicita um símbolo e verifica se ele é 'a' ou 'b'.
    *   Solicita uma cadeia e valida se todos os seus caracteres pertencem a `Σ*` (contêm apenas símbolos do alfabeto).
    *   Exibe mensagens claras de válido/inválido.

### Item 2 — Classificador T/I/N por JSON

*   **Objetivo:** Ler itens de problemas embutidos em JSON e classificá-los como Tratável (T), Intratável (I) ou Não Computável (N).
*   **Funcionalidade:**
    *   Carrega uma lista predefinida de problemas computacionais e suas classificações corretas a partir de uma string JSON embutida.
    *   Desafia o usuário a classificar cada problema como **T**ratável, **I**ntratável ou **N**ão Computável.
    *   Registra acertos e erros e exibe um resumo de desempenho ao final.

### Item 3 — Programa de Decisão: “termina com ‘b’?”

*   **Objetivo:** Decidir se uma cadeia sobre `Σ={a,b}` termina com o símbolo 'b' e sempre terminar a execução.
*   **Funcionalidade:**
    *   Recebe uma cadeia sobre `Σ={a,b}`.
    *   Decide, de forma garantida e finita, se ela termina ou não com o caractere 'b'.
    *   Trata o caso de cadeia vazia e retorna "SIM" ou "NAO".

### Item 4 — Avaliador Proposicional Básico

*   **Objetivo:** Avaliar fórmulas proposicionais predeterminadas sobre as variáveis P, Q, R e, opcionalmente, gerar uma tabela-verdade.
*   **Funcionalidade:**
    *   Permite que o usuário defina valores lógicos (Verdadeiro/Falso) para as proposições P, Q e R.
    *   Avalia fórmulas lógicas predefinidas com base nos valores inseridos.
    *   Oferece a opção de gerar e exibir a tabela-verdade completa para a fórmula escolhida.

### Item 5 — Reconhecedor Σ={a,b}: L_par_a e ab*

*   **Objetivo:** Decidir o pertencimento de uma cadeia a duas linguagens formais simples.
*   **Funcionalidade:**
    *   Reconhece se uma dada cadeia pertence a duas linguagens formais distintas:
        *   `L_par_a`: Linguagem das cadeias com um número par de 'a's.
        *   `L = { w | w = ab* }`: Linguagem das cadeias que iniciam com um 'a' seguido por zero ou mais 'b's.
    *   Retorna "ACEITA" ou "REJEITA" para a linguagem selecionada.

## ⚙️ Execução do Projeto

## Tecnologias Utilizadas

-   **Linguagem**: C#
-   **Plataforma**: .NET 9
-   **Bibliotecas**: Apenas bibliotecas padrão do .NET (`System.Text.Json`). Nenhuma dependência externa.

---

## Pré-requisitos

Para compilar e executar este projeto, você precisará ter o **SDK do .NET 9** (ou superior) instalado em sua máquina.

-   [Download do .NET](https://dotnet.microsoft.com/download)

## Como Executar

1.  **Clone ou baixe o projeto**
    Se estiver usando Git, clone o repositório:
    ```sh
    git clone https://github.com/mateus4costa/AV1.git
    ```
    Caso contrário, apenas baixe e descompacte os arquivos em uma pasta de sua preferência.

2.  **Navegue até a pasta do projeto**
    Abra um terminal (PowerShell, CMD, ou Terminal) e navegue para o diretório que contém o arquivo `.csproj` do projeto.
    ```sh
    cd /caminho/para/o/projeto/ProjetoToolkit
    ```

3.  **Execute o programa**
    Utilize o comando `dotnet run`. O .NET irá compilar e executar o aplicativo automaticamente.
    ```sh
    dotnet run
    ```

4.  **Interação**
    Após a execução, o menu principal será exibido no terminal. Digite o número do módulo desejado e pressione Enter para utilizá-lo.

---

## 👨‍🎓 Alunos

Este projeto foi desenvolvido por:

| Nome Completo        | Matrícula          |
| -------------------- | ------------------ |
| *Bernardo da Silva Araújo de Oliveira* | *06004026* |
| *Emanuel Cunha da Costa* | *06003365* |
| *Eduardo Cabral* | *06002546* |
| *Pedro Pereira Dias* | *06003504* |
| *Mateus Sampaio* | *06003438* |
=======
