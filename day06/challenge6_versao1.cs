// Função principal
double Main(string[] comandos)
{
    // Variáveis para armazenar os dados lidos
    // CORREÇÃO: Precisa ser uma lista de arrays de long para funcionar a lógica [i][j]
    List<long[]> listaNumeros = new();
    List<char> listaOperadores = new();
    double result = 0;

    #region Leitura e Separação dos Dados

    for (int linha = 0; linha < comandos.Length; linha++)
    {
        // CORREÇÃO: "linha" é um int, precisamos acessar o array "comandos[linha]"
        // CORREÇÃO: RemoveEmptyEntries é necessário pq o input tem vários espaços seguidos
        string[] partes = comandos[linha].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // se for linha dos operadores (última linha)
        if (linha == comandos.Length - 1)
        {
            foreach (string parte in partes)
                listaOperadores.Add(char.Parse(parte)); // Adiciona na lista corretamente
        }

        // se for linha com numeros
        else
        {
            // Precisamos criar um array temporário para essa linha
            long[] numerosDessaLinha = new long[partes.Length];
            for (int k = 0; k < partes.Length; k++)
            {
                numerosDessaLinha[k] = long.Parse(partes[k]);
            }
            listaNumeros.Add(numerosDessaLinha);
        }
    }

    #endregion

    // Lê cada uma das colunas por vez e faz calculo pra cada coluna

    // percorre coluna (assumindo que todas linhas tem mesmo tamanho, pegamos o tamanho da primeira)
    for (int j = 0; j < listaNumeros[0].Length; j++)
    {
        // percorre as linhas
        int i = 0;

        // CORREÇÃO: A variável precisa ser declarada fora do IF para ser usada no final do loop
        long currResult = 0;

        // CORREÇÃO: Comparar char com aspas simples ('+')
        if (listaOperadores[j] == '+')
        {
            currResult = 0; // Elemento neutro da soma

            while (i < listaNumeros.Count)
            {
                currResult += listaNumeros[i][j];
                i++;
            }
        }
        else // multiplicação
        {
            // CORREÇÃO: Comparar char com aspas simples ('*')
            if (listaOperadores[j] == '*')
            {
                currResult = 1; // Elemento neutro da multiplicação
                while (i < listaNumeros.Count)
                {
                    currResult *= listaNumeros[i][j];
                    i++;
                }
            }
        }

        result += currResult;
    }

    return result;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------

string filePath = "comandos6_versao1.txt";

string[] comandos = File.ReadAllLines(filePath);
Console.WriteLine(Main(comandos));