using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ==========================================
// 1. ÁREA DE EXECUÇÃO
// ==========================================

string filePath = "comandos9_versao2.txt";

if (File.Exists(filePath))
{
    string[] input = File.ReadAllLines(filePath);
    List<long[]> polygonVertices = new();

    for (int i = 0; i < input.Length; i++)
    {
        string[] coordenadas = input[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        polygonVertices.Add(new long[] {
            long.Parse(coordenadas[0]),
            long.Parse(coordenadas[1])
        });
    }

    Console.WriteLine(Resolver(polygonVertices));
}
else
{
    Console.WriteLine("Arquivo não encontrado.");
}

// ==========================================
// 2. LÓGICA DO PROBLEMA
// ==========================================

long Resolver(List<long[]> pontosPoligono)
{
    long maxArea = 0;

    for (int i = 0; i < pontosPoligono.Count; i++)
    {
        for (int j = i + 1; j < pontosPoligono.Count; j++)
        {
            long area = CalculaArea(pontosPoligono[i], pontosPoligono[j]);

            // Definir limites do retângulo para facilitar as verificações
            long xEsquerda = Math.Min(pontosPoligono[i][0], pontosPoligono[j][0]);
            long xDireita = Math.Max(pontosPoligono[i][0], pontosPoligono[j][0]);
            long yBaixo = Math.Min(pontosPoligono[i][1], pontosPoligono[j][1]);
            long yCima = Math.Max(pontosPoligono[i][1], pontosPoligono[j][1]);

            // Otimização: Se a área for menor que o máximo já encontrado, nem perde tempo verificando
            if (area <= maxArea) continue;

            // Verifica se alguma parede do polígono "corta" o retângulo ao meio.
            if (!RetanguloCruzadoPorAresta(xEsquerda, xDireita, yBaixo, yCima, pontosPoligono)) maxArea = area;
        }
    }
    return maxArea;
}

// ==========================================
// 3. FUNÇÕES AUXILIARES
// ==========================================

// Verifica se alguma aresta do polígono atravessa o retângulo
bool RetanguloCruzadoPorAresta(long xEsquerda, long xDireita, long yBaixo, long yCima, List<long[]> pontosPoligono)
{
    for (int i = 0; i < pontosPoligono.Count; i++)
    {
        // Pega aresta atual (ponto A até ponto B)
        long[] a = pontosPoligono[i];

        // Pega o próximo ponto, ou o primeiro se estiver no último
        long[] b = pontosPoligono[(i + 1) % pontosPoligono.Count];

        // Verifica se é uma aresta VERTICAL --> tem x constante
        if (a[0] == b[0])
        {
            long xAresta = a[0];
            long yArestaComeco = Math.Min(a[1], b[1]);
            long yArestaFim = Math.Max(a[1], b[1]);

            // Para cortar o retângulo, a linha vertical precisa estar ESTRITAMENTE entre xEsquerda e xDireita
            // E o intervalo Y da aresta deve sobrepor o intervalo Y do retângulo
            if (xAresta > xEsquerda && xAresta < xDireita)
            {
                // Verifica sobreposição no eixo Y
                if (Math.Max(yBaixo, yArestaComeco) < Math.Min(yCima, yArestaFim))
                {
                    return true; // Cortou!
                }
            }
        }
        // Verifica se é uma aresta HORIZONTAL --> tem y constante
        else if (a[1] == b[1])
        {
            long yAresta = a[1];
            long xArestaComeco = Math.Min(a[0], b[0]);
            long xArestaFim = Math.Max(a[0], b[0]);

            // Para cortar, a linha horizontal precisa estar ESTRITAMENTE entre yBaixo e yCima
            // E o intervalo X da aresta deve sobrepor o intervalo X do retângulo
            if (yAresta > yBaixo && yAresta < yCima)
            {
                // Verifica sobreposição no eixo X
                if (Math.Max(xEsquerda, xArestaComeco) < Math.Min(xDireita, xArestaFim))
                {
                    return true; // Cortou!
                }
            }
        }
    }
    return false; // Nenhuma aresta cortou
}

long CalculaArea(long[] pontoA, long[] pontoB)
{
    long largura = (long)Math.Abs(pontoA[0] - pontoB[0]) + 1;
    long altura = (long)Math.Abs(pontoA[1] - pontoB[1]) + 1;
    return largura * altura;
}
