using System;
using System.Collections.Generic;
using System.Linq;

long Main(string[] matriz)
{
    int linhas = matriz.Length;
    int colunas = matriz[0].Length;

    // MUITO IMPORTANTE: Use long, int vai estourar!
    long[,] valores = new long[linhas, colunas];

    // Percorre de baixo para cima (Bottom-Up)
    for (int linha = linhas - 1; linha >= 0; linha--)
    {
        for (int coluna = 0; coluna < colunas; coluna++) // Ordem das colunas não importa aqui
        {
            // Só calculamos valores para os Splitters
            if (matriz[linha][coluna] == '^')
            {
                long caminhosDireita = 1; // Default: se cair no abismo, conta 1
                long caminhosEsquerda = 1; // Default: se cair no abismo, conta 1

                // -- Lógica para a DIREITA (coluna + 1) --
                // Olha para baixo procurando o próximo obstáculo
                for (int i = linha + 1; i < linhas; i++)
                {
                    // Se o raio sair pela lateral direita, ele cai no abismo -> conta 1 (mantém default)
                    if (coluna + 1 >= colunas) break;

                    // Se achou um splitter já calculado lá embaixo, pega o valor dele
                    if (matriz[i][coluna + 1] == '^')
                    {
                        caminhosDireita = valores[i, coluna + 1];
                        break;
                    }
                    // Se fosse parede ou bloqueio, seria 0, mas nesse desafio raio atravessa tudo exceto ^
                }

                // -- Lógica para a ESQUERDA (coluna - 1) --
                for (int i = linha + 1; i < linhas; i++)
                {
                    if (coluna - 1 < 0) break;

                    if (matriz[i][coluna - 1] == '^')
                    {
                        caminhosEsquerda = valores[i, coluna - 1];
                        break;
                    }
                }

                // Soma os caminhos
                valores[linha, coluna] = caminhosDireita + caminhosEsquerda;
            }
        }
    }

    // --- CÁLCULO DA RESPOSTA FINAL (Conectar o S) ---

    int sColuna = matriz[0].IndexOf('S'); // Acha onde está o S
    long totalTimelines = 1; // Se não tiver nenhum splitter embaixo do S, a resposta é 1

    // Desce a partir do S para ver no que ele bate
    for (int i = 1; i < linhas; i++)
    {
        if (matriz[i][sColuna] == '^')
        {
            // O S alimenta este splitter, então a resposta é o valor dele
            totalTimelines = valores[i, sColuna];
            break;
        }
    }

    return totalTimelines;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------
string filePath = "comandos7_versao2.txt";
if (System.IO.File.Exists(filePath))
{
    string[] comandos = System.IO.File.ReadAllLines(filePath);
    Console.WriteLine(Main(comandos));
}