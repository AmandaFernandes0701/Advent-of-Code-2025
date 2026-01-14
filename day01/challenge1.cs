// Função principal
int Main(string[] comandos)
{
    int count = 0;
    int currentNumber = 50;

    foreach (string comando in comandos)
    {
        int steps = int.Parse(comando.Substring(1));
        char direction = comando[0];

        if (direction == 'L')
            currentNumber = MoveLeft(currentNumber, steps, ref count);
        else
            currentNumber = MoveRight(currentNumber, steps, ref count);
    }

    return count;
}

int MoveLeft(int number, int steps, ref int count)
{
    while (steps > 0)
    {
        number--;
        steps--;

        // Primeiro faz o wrap (se foi pra -1, vira 99)
        if (number < 0)
            number = 99;

        // Depois checa se caiu no zero
        if (number == 0)
            count++;
    }
    return number;
}

int MoveRight(int number, int steps, ref int count)
{
    while (steps > 0)
    {
        number++;
        steps--;

        // Primeiro faz o wrap (se foi pra 100, vira 0)
        if (number > 99)
            number = 0;

        // Depois checa se caiu no zero
        if (number == 0)
            count++;
    }
    return number;
}


// ------------------------------
// EXECUÇÃO — Lê o arquivo txt
// ------------------------------

string filePath = "comandos1.txt";

string[] comandos = File.ReadAllLines(filePath);

Console.WriteLine(Main(comandos));
