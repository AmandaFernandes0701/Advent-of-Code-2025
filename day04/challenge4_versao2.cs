// Renomeei para Solucao para não conflitar com o Main interno do C#
long Solucao(string[] matriz)
{
    long count = 0;

    int linhas = matriz.Length;
    int colunas = matriz[0].Length;

    // Converte para matriz de char para poder editar
    char[][] grid = new char[linhas][];
    for (int i = 0; i < linhas; i++) grid[i] = matriz[i].ToCharArray();

    bool houveMudanca = true;

    while (houveMudanca)
    {
        // Lista nasce limpa a cada volta do loop
        List<(int, int)> candidatosParaRemover = new();

        // 1. ANÁLISE: Percorre a matriz para achar quem sai
        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                if (grid[i][j] == '@')
                {
                    int currCount = 0;

                    // --- INICIO DA VERIFICAÇÃO DE VIZINHOS ---

                    // MESMA LINHA
                    if ((j - 1) >= 0 && grid[i][j - 1] == '@') currCount++;
                    if ((j + 1) < colunas && grid[i][j + 1] == '@') currCount++;

                    // LINHA DE BAIXO
                    if ((j - 1) >= 0 && (i + 1) < linhas && grid[i + 1][j - 1] == '@') currCount++;
                    if ((i + 1) < linhas && grid[i + 1][j] == '@') currCount++;
                    if ((j + 1) < colunas && (i + 1) < linhas && grid[i + 1][j + 1] == '@') currCount++;

                    // LINHA DE CIMA  
                    if ((j - 1) >= 0 && (i - 1) >= 0 && grid[i - 1][j - 1] == '@') currCount++;
                    if ((i - 1) >= 0 && grid[i - 1][j] == '@') currCount++;
                    if ((j + 1) < colunas && (i - 1) >= 0 && grid[i - 1][j + 1] == '@') currCount++;
                    // --- FIM DA VERIFICAÇÃO ---

                    if (currCount < 4)
                    {
                        count++;
                        candidatosParaRemover.Add((i, j));
                    }
                }
            }
        }

        // 2. CRITÉRIO DE PARADA
        if (candidatosParaRemover.Count == 0)
        {
            houveMudanca = false; // ou break
        }
        else
        {
            // 3. ATUALIZAÇÃO (OTIMIZADA)
            // Em vez de varrer a matriz procurando quem está na lista,
            // vamos direto nas coordenadas salvas! É O(N) em vez de O(N*M).
            foreach (var (linha, coluna) in candidatosParaRemover)
            {
                grid[linha][coluna] = 'X';
            }
        }
    }

    return count;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------
string filePath = "comandos4_versao2.txt";

if (File.Exists(filePath))
{
    string[] comandos = File.ReadAllLines(filePath);
    Console.WriteLine(Solucao(comandos));
}
else
{
    Console.WriteLine("Arquivo não encontrado.");
}