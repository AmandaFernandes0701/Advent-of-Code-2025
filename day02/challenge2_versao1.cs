// Função principal
double Main(string[] comandos)
{
    // Variáveis para armazenar os dados lidos
    List<string> listaRanges = new List<string>();
    List<double> listaIds = new List<double>();
    double count = 0;

    #region Leitura e Separação dos Dados
    bool passouPeloEspacoVazio = false;

    foreach (string linha in comandos)
    {
        if (string.IsNullOrWhiteSpace(linha))
        {
            passouPeloEspacoVazio = true;
            continue;
        }

        if (!passouPeloEspacoVazio)
            listaRanges.Add(linha);
        else
            listaIds.Add(double.Parse(linha));
    }
    #endregion

    // Lê cada um dos IDs e verifica se estão dentro de algum range
    foreach (double id in listaIds)
    {
        foreach (string intervalo in listaRanges)
        {
            // "3-5" vira um array ["3", "5"]
            string[] partes = intervalo.Split('-');

            double lowerBound = double.Parse(partes[0]);
            double upperBound = double.Parse(partes[1]);

            // Verifica se está dentro do intervalo
            if (id >= lowerBound && id <= upperBound)
            {
                count++;
                // não precisa verificar os demais intervalos
                // pois só precisa atender pelo menos 1
                break;
            }
        }
    }

    return count;
}

// ------------------------------
// EXECUÇÃO
// ------------------------------

string filePath = "comandos2_versao1.txt";

string[] comandos = File.ReadAllLines(filePath);
Console.WriteLine(Main(comandos));