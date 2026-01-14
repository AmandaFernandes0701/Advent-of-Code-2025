// Função principal
double Main(string[] matriz)
{
    double result = 0;
    List<long> allNumbers = new();
    List<long> tempNumbers = new();

    // CORREÇÃO 1: O operador precisa ser salvo fora do loop para ser lembrado
    // quando chegarmos na coluna de espaços.
    char currentOperator = ' ';

    // coluna (começa do ultimo index): direita --> esquerda
    for (int coluna = matriz[0].Length - 1; coluna >= 0; coluna--)
    {
        string currNumberColuna = "";
        bool colunaTemNumeros = false;

        // linha
        for (int linha = 0; linha < matriz.Length; linha++)
        {
            char currChar = matriz[linha][coluna];

            // Se for a última linha, verificamos se tem operador ou se é hora de calcular
            if (linha == matriz.Length - 1)
            {
                // Se achou operador, guarda ele para usar depois
                if (currChar == '+') currentOperator = '+';
                else if (currChar == '*') currentOperator = '*';

                // SE É UMA COLUNA SEPARADORA (não pegamos nenhum numero nela)
                // OU se chegamos no fim da matriz (coluna 0) e temos numeros acumulados
                if (!colunaTemNumeros && tempNumbers.Count > 0)
                {
                    long finalNumberColuna = 0;

                    // Ajuste o valor inicial dependendo da conta
                    if (currentOperator == '+') finalNumberColuna = 0;
                    else finalNumberColuna = 1;

                    if (currentOperator == '+')
                    {
                        foreach (long num in tempNumbers)
                            finalNumberColuna += num;
                    }
                    else if (currentOperator == '*')
                    {
                        foreach (long num in tempNumbers)
                            finalNumberColuna *= num;
                    }

                    allNumbers.Add(finalNumberColuna);
                    tempNumbers.Clear(); // CORREÇÃO 2: Sintaxe correta é Clear()
                }
            }
            else
            {
                // Se não é espaço, monta o número
                if (currChar != ' ')
                {
                    currNumberColuna += currChar; // CORREÇÃO 3: Concatenação simples
                    colunaTemNumeros = true;
                }
            }
        }

        // Se formou um número nesta coluna, adiciona na lista temporária
        if (colunaTemNumeros && currNumberColuna != "")
        {
            long currNumber = long.Parse(currNumberColuna);
            tempNumbers.Add(currNumber);
        }
    }

    // CORREÇÃO 4: O último bloco (o mais a esquerda) não tem coluna de espaço depois dele.
    // Precisamos calcular o que sobrou no tempNumbers ao sair do loop.
    if (tempNumbers.Count > 0)
    {
        long finalNumberColuna = (currentOperator == '+') ? 0 : 1;
        foreach (long num in tempNumbers)
        {
            if (currentOperator == '+') finalNumberColuna += num;
            else finalNumberColuna *= num;
        }
        allNumbers.Add(finalNumberColuna);
    }

    foreach (long num in allNumbers)
        result += num;

    return result;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------

string filePath = "comandos6_versao2.txt";

if (File.Exists(filePath))
{
    string[] comandos = File.ReadAllLines(filePath);
    Console.WriteLine(Main(comandos));
}