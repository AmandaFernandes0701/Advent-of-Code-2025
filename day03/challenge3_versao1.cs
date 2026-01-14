long Main(string[] comandos)
{
    long result = 0;
    int quantidadeLinhas = comandos.Length;
    int qntddNumPorLinhas = comandos[0].Length;
    List<long> numeros = new();

    for (int i = 0; i < quantidadeLinhas; i++)
    {
        int left = 0;
        int right = 1;

        string currMaxNumber = $"{comandos[i][left]}{comandos[i][right]}";

        while (left < qntddNumPorLinhas - 1)
        {
            while (right < qntddNumPorLinhas)
            {
                string numeroAtual = $"{comandos[i][left]}{comandos[i][right]}";

                currMaxNumber = Math.Max(
                    long.Parse(currMaxNumber),
                    long.Parse(numeroAtual)
                ).ToString();

                right++;
            }

            left++;
            right = left + 1;
        }

        numeros.Add(long.Parse(currMaxNumber));
    }

    foreach (long numero in numeros)
        result += numero;

    return result;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------
string filePath = "comandos3_versao1.txt";

if (File.Exists(filePath))
{
    string[] comandos = File.ReadAllLines(filePath);
    Console.WriteLine(Main(comandos));
}
else
{
    Console.WriteLine("Arquivo não encontrado.");
}
