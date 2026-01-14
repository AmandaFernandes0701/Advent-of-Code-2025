using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// ==========================================
// 1. ÁREA DE EXECUÇÃO
// ==========================================

string filePath = "comandos11_versao2.txt";

if (File.Exists(filePath))
{
    string[] input = File.ReadAllLines(filePath);

    // 1.1 Leitura e Montagem do Grafo
    Dictionary<string, List<string>> grafo = new();

    foreach (string linha in input)
    {
        string[] partes = linha.Split(':');
        string origem = partes[0].Trim();

        // Separa vizinhos e remove espaços vazios
        string[] destinos = partes[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> listaLimpa = new();
        foreach (var d in destinos) listaLimpa.Add(d.Trim());

        grafo[origem] = listaLimpa;
    }

    // Preparação para os cálculos
    Dictionary<string, long> cache = new();

    // ---------------------------------------------------------
    // CENÁRIO 1: svr -> dac -> fft -> out
    // ---------------------------------------------------------

    // Passo A: svr até dac
    cache.Clear(); // Limpa a memória pois o destino mudou!
    long svrParaDac = ContarCaminhos("svr", grafo, cache, "dac");

    // Passo B: dac até fft
    cache.Clear();
    long dacParaFft = ContarCaminhos("dac", grafo, cache, "fft");

    // Passo C: fft até out
    cache.Clear();
    long fftParaOut = ContarCaminhos("fft", grafo, cache, "out");

    long totalCenario1 = svrParaDac * dacParaFft * fftParaOut;

    // ---------------------------------------------------------
    // CENÁRIO 2: svr -> fft -> dac -> out
    // ---------------------------------------------------------

    // Passo D: svr até fft
    cache.Clear();
    long svrParaFft = ContarCaminhos("svr", grafo, cache, "fft");

    // Passo E: fft até dac
    cache.Clear();
    long fftParaDac = ContarCaminhos("fft", grafo, cache, "dac");

    // Passo F: dac até out
    cache.Clear();
    long dacParaOut = ContarCaminhos("dac", grafo, cache, "out");

    long totalCenario2 = svrParaFft * fftParaDac * dacParaOut;

    // ---------------------------------------------------------
    // RESULTADO FINAL
    // ---------------------------------------------------------
    long respostaFinal = totalCenario1 + totalCenario2;

    Console.WriteLine($"Caminhos (Dac -> Fft): {totalCenario1}");
    Console.WriteLine($"Caminhos (Fft -> Dac): {totalCenario2}");
    Console.WriteLine($"TOTAL DE CAMINHOS VÁLIDOS: {respostaFinal}");
}
else
{
    Console.WriteLine("Arquivo não encontrado.");
}


// ==========================================
// FUNÇÃO DFS COM MEMOIZATION
// ==========================================

long ContarCaminhos(string atual, Dictionary<string, List<string>> grafo, Dictionary<string, long> cache, string alvo)
{
    // 1. Caso Base: Cheguei no destino específico deste trecho?
    if (atual == alvo) return 1;

    // 2. Verifica o Cache
    if (cache.ContainsKey(atual)) return cache[atual];

    // 3. Caso Base: Beco sem saída (nó não existe ou não tem saídas)
    if (!grafo.ContainsKey(atual)) return 0;

    // 4. Recursão
    long total = 0;
    foreach (string vizinho in grafo[atual])
    {
        // IMPORTANTE: Tem que repassar o 'alvo' para a próxima chamada!
        total += ContarCaminhos(vizinho, grafo, cache, alvo);
    }

    // 5. Salva no Cache e Retorna
    cache[atual] = total;
    return total;
}