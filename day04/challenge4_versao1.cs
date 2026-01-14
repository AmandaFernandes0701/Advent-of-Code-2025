long Main(string[] matriz)
{
    long count = 0;

    int linhas = matriz.Length;
    int colunas = matriz[0].Length;

    for (int i = 0; i < linhas; i++)
    {
        for (int j = 0; j < colunas; j++)
        {
            char currChar = matriz[i][j];

            if (currChar == '@')
            {
                int currCount = 0;

                // inspeciona TODOS o 8 quadrados adjacentes

                // MESMA LINHA

                // linha = i coluna = j - 1
                if ((j - 1) >= 0 && matriz[i][j - 1] == '@')
                    currCount++;

                // linha = i coluna = j + 1
                if ((j + 1) < colunas && matriz[i][j + 1] == '@')
                    currCount++;



                // LINHA DE BAIXO

                // linha = i + 1 coluna = j - 1
                if ((j - 1) >= 0 && (i + 1) < linhas && matriz[i + 1][j - 1] == '@')
                    currCount++;

                // linha = i + 1 coluna = j
                if ((i + 1) < linhas && matriz[i + 1][j] == '@')
                    currCount++;

                // linha = i + 1 coluna = j + 1
                if ((j + 1) < colunas && (i + 1) < linhas && matriz[i + 1][j + 1] == '@')
                    currCount++;



                // LINHA DE CIMA  

                // linha = i - 1 coluna = j - 1
                if ((j - 1) >= 0 && (i - 1) >= 0 && matriz[i - 1][j - 1] == '@')
                    currCount++;

                // linha = i - 1 coluna = j
                if ((i - 1) >= 0 && matriz[i - 1][j] == '@')
                    currCount++;

                // linha = i - 1 coluna = j + 1
                if ((j + 1) < colunas && (i - 1) >= 0 && matriz[i - 1][j + 1] == '@')
                    currCount++;

                if (currCount < 4)
                    count++;
            }
        }
    }

    return count;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------
string filePath = "comandos4_versao1.txt";

if (File.Exists(filePath))
{
    string[] comandos = File.ReadAllLines(filePath);
    Console.WriteLine(Main(comandos));
}
else
{
    Console.WriteLine("Arquivo não encontrado.");
}
