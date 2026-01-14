using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ==========================================
// 1. ÁREA DE EXECUÇÃO (Vem no topo!)
// ==========================================

string filePath = "comandos9_versao1.txt";

if (File.Exists(filePath))
{
    string[] input = File.ReadAllLines(filePath);
    List<long[]> pontos = new();

    for (int i = 0; i < input.Length; i++)
    {
        string[] coordenadas = input[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        pontos.Add(new long[] {
            long.Parse(coordenadas[0]),
            long.Parse(coordenadas[1])
        });
    }

    // Chama a função RESOLVER
    Console.WriteLine(Resolver(pontos));
}
else
{
    Console.WriteLine("Arquivo não encontrado.");
}


// ==========================================
// 2. ÁREA DE DEFINIÇÕES
// ==========================================

long Resolver(List<long[]> pontos)
{
    long maxArea = 0;

    for (int i = 0; i < pontos.Count; i++)
    {
        for (int j = i + 1; j < pontos.Count; j++)
        {
            maxArea = Math.Max(maxArea, CalculaArea(pontos[i], pontos[j]));
        }
    }
    return maxArea;
}

long CalculaArea(long[] pontoA, long[] pontoB)
{
    long largura = (long)Math.Abs(pontoA[0] - pontoB[0]) + 1;
    long altura = (long)Math.Abs(pontoA[1] - pontoB[1]) + 1;
    return largura * altura;
}