// Use long para garantir que números grandes caibam
long Main(string[] comandos)
{
    List<long[]> ranges = new();
    long countTotal = 0;

    // Leitura
    var intervalos = comandos[0].Split(',');

    foreach (string intervalo in intervalos)
    {
        if (string.IsNullOrWhiteSpace(intervalo)) continue;

        var num = intervalo.Split('-');
        long start = long.Parse(num[0]);
        long end = long.Parse(num[1]);

        ranges.Add(new long[] { start, end });
    }

    // Percorre todos os valores do intervalo
    // i = intervalo atual
    for (int i = 0; i < ranges.Count; i++)
    {
        long currentStart = ranges[i][0];
        long currentEnd = ranges[i][1];

        for (long num = currentStart; num <= currentEnd; num++)
        {
            string currentNumString = num.ToString();
            int len = currentNumString.Length;
            int meio = len / 2;

            for (int tamanhoSubString = 1; tamanhoSubString <= meio; tamanhoSubString++)
            {
                // Se o tamanho total não divide pelo tamanho da parte, nem tenta
                if (len % tamanhoSubString != 0) continue;

                string currSequence = currentNumString.Substring(0, tamanhoSubString);

                // Reseta a string de teste a cada novo tamanho tentado
                string testSubstring = "";

                // Quantas vezes o padrão cabe no número total?
                int repeticoes = len / tamanhoSubString;

                for (int k = 0; k < repeticoes; k++)
                    testSubstring += currSequence;

                if (testSubstring == currentNumString)
                {
                    countTotal += num;
                    break;
                }
            }
        }
    }

    return countTotal;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------
string filePath = "comandos2_versao2.txt";
if (File.Exists(filePath))
{
    string[] comandos = File.ReadAllLines(filePath);
    Console.WriteLine(Main(comandos));
}