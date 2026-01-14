long Main(string[] comandos)
{
    long result = 0;
    int quantidadeLinhas = comandos.Length;
    int qntddNumPorLinhas = comandos[0].Length;

    // percorre cada linha
    for (int i = 0; i < quantidadeLinhas; i++)
    {
        int indexUltimoNumEsquerda = 0;
        long numeroFinal = 0;

        // exatamente 12 dígitos
        for (int num = 0; num < 12; num++)
        {
            int limiteEsquerda = indexUltimoNumEsquerda;
            int limiteDireita = qntddNumPorLinhas - (12 - num);

            // procura maior número entre os índices (transformando char em int)
            int currMaxNum = comandos[i][limiteEsquerda] - '0';
            int indiceEscolhido = limiteEsquerda;

            // percorre os índices possíveis
            for (int j = limiteEsquerda; j <= limiteDireita; j++)
            {
                int currNum = comandos[i][j] - '0';

                if (currNum > currMaxNum)
                {
                    currMaxNum = currNum;
                    indiceEscolhido = j;
                }
            }

            numeroFinal = numeroFinal * 10 + currMaxNum;
            indexUltimoNumEsquerda = indiceEscolhido + 1;
        }

        result += numeroFinal;
    }

    return result;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------
string filePath = "comandos3_versao2.txt";

if (File.Exists(filePath))
{
    string[] comandos = File.ReadAllLines(filePath);
    Console.WriteLine(Main(comandos));
}
else
{
    Console.WriteLine("Arquivo não encontrado.");
}
