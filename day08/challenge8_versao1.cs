using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ==========================================
// 1. ÁREA DE EXECUÇÃO (Vem no topo!)
// ==========================================

string filePath = "comandos8_versao1.txt";

if (File.Exists(filePath))
{
    string[] input = File.ReadAllLines(filePath);
    List<long[]> pontos = new();

    for (int i = 0; i < input.Length; i++)
    {
        string[] coordenadas = input[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        pontos.Add(new long[] {
            long.Parse(coordenadas[0]),
            long.Parse(coordenadas[1]),
            long.Parse(coordenadas[2])
        });
    }

    // Chama a função RESOLVER (mudei o nome de Main para evitar confusão)
    Console.WriteLine(Resolver(pontos));
}
else
{
    Console.WriteLine("Arquivo não encontrado.");
}


// ==========================================
// 2. ÁREA DE DEFINIÇÕES (Vem no final!)
// ==========================================

// Renomeei de 'Main' para 'Resolver' para o C# não confundir com o ponto de entrada do script
long Resolver(List<long[]> pontos)
{
    long result = 0;
    List<Conexao> conexoes = new();

    // 1. Calcula todas as conexoes
    for (int i = 0; i < pontos.Count; i++)
    {
        for (int j = i + 1; j < pontos.Count; j++)
        {
            double dist = EuclideanDistance(pontos[i], pontos[j]);
            conexoes.Add(new Conexao(i, j, dist));
        }
    }

    // 2. Ordena
    conexoes.Sort((a, b) => a.Distancia.CompareTo(b.Distancia));

    // 3. Union-Find Lógica
    List<List<int>> grupos = new();
    int limite = Math.Min(1000, conexoes.Count);

    for (int i = 0; i < limite; i++)
    {
        int idA = conexoes[i].IdPontoA;
        int idB = conexoes[i].IdPontoB;

        int indexGrupoA = grupos.FindIndex(g => g.Contains(idA));
        int indexGrupoB = grupos.FindIndex(g => g.Contains(idB));

        bool aExiste = indexGrupoA != -1;
        bool bExiste = indexGrupoB != -1;

        if (!aExiste && !bExiste)
            grupos.Add(new List<int> { idA, idB });

        else if (aExiste && !bExiste)
            grupos[indexGrupoA].Add(idB);

        else if (!aExiste && bExiste)
            grupos[indexGrupoB].Add(idA);

        else if (aExiste && bExiste && indexGrupoA != indexGrupoB)
        {
            grupos[indexGrupoA].AddRange(grupos[indexGrupoB]);
            grupos.RemoveAt(indexGrupoB);
        }
    }

    // 4. Cálculo Final
    List<long> tamanhos = grupos.Select(g => (long)g.Count).ToList();
    tamanhos.Sort((a, b) => b.CompareTo(a)); // Do maior pro menor

    if (tamanhos.Count >= 3)
        result = tamanhos[0] * tamanhos[1] * tamanhos[2];
    else if (tamanhos.Count > 0)
    {
        result = 1;
        foreach (var t in tamanhos) result *= t;
    }

    return result;
}

double EuclideanDistance(long[] pontoA, long[] pontoB)
{
    return Math.Sqrt(
        Math.Pow(pontoA[0] - pontoB[0], 2) +
        Math.Pow(pontoA[1] - pontoB[1], 2) +
        Math.Pow(pontoA[2] - pontoB[2], 2)
    );
}

public class Conexao
{
    public int IdPontoA;
    public int IdPontoB;
    public double Distancia;

    public Conexao(int idPontoA, int idPontoB, double distancia)
    {
        this.IdPontoA = idPontoA;
        this.IdPontoB = idPontoB;
        this.Distancia = distancia;
    }
}