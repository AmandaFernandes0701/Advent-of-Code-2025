using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ==========================================
// 1. ÁREA DE EXECUÇÃO (Vem no topo!)
// ==========================================

string filePath = "comandos11_versao1.txt";
Dictionary<string, List<string>> grafo = new();

if (File.Exists(filePath))
{
    string[] input = File.ReadAllLines(filePath);

    // Dicionário para o Cache (Memoization)
    Dictionary<string, long> cache = new();

    // Grafo
    Dictionary<string, List<string>> grafo = new();

    for (int i = 0; i < input.Length; i++)
    {
        string[] inputAtual = input[i].Split(':');

        string chave = inputAtual[0].Trim();

        // RemoveEmptyEntries joga fora o espaço em branco que fica depois do ':'
        string[] valores = inputAtual[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> temp = new();
        foreach (var val in valores)
            temp.Add(val.Trim());

        // Dica: Use colchetes para garantir que se a chave repetir (erro no input), ele atualiza
        grafo[chave] = temp;
    }

    // Chama a função principal
    Console.WriteLine($"Caminhos totais: {ContarCaminhos("you", grafo, cache)}");
}

else
{
    Console.WriteLine("Arquivo não encontrado.");
}


// ==========================================
// FUNÇÃO DFS COM MEMOIZATION (CACHE)
// ==========================================

long ContarCaminhos(string atual, Dictionary<string, List<string>> grafo, Dictionary<string, long> cache)
{
    // 1. Caso Base: Sucesso
    if (atual == "out") return 1;

    // 2. Verifica o Caderno (Cache)
    if (cache.ContainsKey(atual)) return cache[atual];

    // 3. Caso Base: Beco sem saída (não tem no grafo)
    if (!grafo.ContainsKey(atual)) return 0;

    // 4. Recursão (Soma os caminhos dos filhos)
    long total = 0;
    foreach (string vizinho in grafo[atual])
        total += ContarCaminhos(vizinho, grafo, cache);

    // 5. Anota no Caderno antes de retornar
    cache[atual] = total;

    return total;
}
