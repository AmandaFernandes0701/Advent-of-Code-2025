using System;
using System.Collections.Generic;
using System.Linq;

int Main(string[] linhasArquivo)
{
    // CONVERSÃO: String é imutável em C#, precisamos de char[][] para poder desenhar na matriz
    char[][] matriz = linhasArquivo.Select(l => l.ToCharArray()).ToArray();

    int qntddLinhas = matriz.Length;
    int qntddColunas = matriz[0].Length;

    // Fila guarda {linha, coluna} de onde um raio COMEÇA a descer
    Queue<int[]> queueCoordenadas = new();

    int countSplits = 0;

    // Achar o S na primeira linha (assumindo que S está na linha 0)
    int indiceSColuna = Array.IndexOf(matriz[0], 'S');

    // Começa na linha 1 (logo abaixo do S), na mesma coluna
    queueCoordenadas.Enqueue(new int[] { 1, indiceSColuna });

    while (queueCoordenadas.Count > 0)
    {
        // Pega o próximo raio
        int[] coordenadas = queueCoordenadas.Dequeue();
        int currLinha = coordenadas[0];
        int currColuna = coordenadas[1];

        // Enquanto estiver dentro do mapa
        while (currLinha < qntddLinhas)
        {
            char itemAtual = matriz[currLinha][currColuna];

            // CASO 1: Encontrou um Splitter NOVO
            if (itemAtual == '^')
            {
                countSplits++;

                // TRUQUE: Mudamos o caractere para '&' para marcar que já contamos esse splitter.
                // Isso funciona como o "HashSet" visual.
                matriz[currLinha][currColuna] = '&';

                // Adiciona raio na esquerda (se couber no mapa)
                if (currColuna - 1 >= 0)
                    queueCoordenadas.Enqueue(new int[] { currLinha, currColuna - 1 });

                // Adiciona raio na direita (se couber no mapa)
                if (currColuna + 1 < qntddColunas)
                    queueCoordenadas.Enqueue(new int[] { currLinha, currColuna + 1 });

                // O raio atual morre aqui, paramos o while interno
                break;
            }
            // CASO 2: Encontrou um Splitter JÁ USADO ('&')
            else if (itemAtual == '&')
            {
                // O raio se funde com o anterior e para, não gera novos raios
                break;
            }

            // CASO 3: Espaço vazio ('.') ou rastro de outro raio ('|')
            // O raio continua descendo. Marcamos '|' apenas para visualização (opcional)
            matriz[currLinha][currColuna] = '|';
            currLinha++;
        }
    }

    return countSplits;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------

string filePath = "comandos7_versao1.txt";

if (System.IO.File.Exists(filePath))
{
    string[] comandos = System.IO.File.ReadAllLines(filePath);
    Console.WriteLine(Main(comandos));
}