// Use long para garantir que números grandes caibam
long Main(string[] comandos)
{
    List<long[]> ranges = new();
    long countTotal = 0;

    // Leitura
    foreach (string parte in partes)
    {
        var intervalo = parte.Split('-');
        long start = long.Parse(intervalo[0]);
        long end = long.Parse(intervalo[1]);

        ranges.Add(new long[] { start, end });
    }

    // Faz a ordenacao --> num incicial ordem crescente
    ranges.Sort((a, b) => a[0].CompareTo(b[0]));

    // faz logica de MERGE INTERVALS
    List<long[]> intervalos = new();

    long lastStart = ranges[0][0];
    long lastEnd = ranges[0][1];

    for (int i = 1; i < ranges.Count; i++)
    {
        long currentStart = ranges[i][0];
        long currentEnd = ranges[i][1];

        // Se lastEnd for maior ou igual que currentStart --> junta os intervalos
        if (lastEnd >= currentStart)
            lastEnd = Math.Max(lastEnd, currentEnd);

        // caso contrario, adiciona ultimo intervalo e atualiza valores do ultimo intervalo logo em seguida
        else
        {
            intervalos.Add(new long[] { lastStart, lastEnd });
            lastStart = currentStart;
            lastEnd = currentEnd;
        }
    }

    // adiciona ultimo intervalo
    intervalos.Add(new long[] { lastStart, lastEnd });

    // conta quantidade de valores nos intervalos
    foreach (var intervalo in intervalos)
        countTotal += (intervalo[1] - intervalo[0]) + 1;

    return countTotal;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------
string filePath = "comandos5_versao2.txt";
if (File.Exists(filePath))
{
    string[] comandos = File.ReadAllLines(filePath);
    Console.WriteLine(Main(comandos));
}