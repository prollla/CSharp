int N = 8; // размер матрицы
int[,] matrix = new int[N, N]; // создание матрицы

// заполнение матрицы в шахматном порядке
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        if ((i + j) % 2 == 0)
        {
            matrix[i, j] = 1;
        }
        else
        {
            matrix[i, j] = 0;
        }
    }
}

// вывод матрицы на консоль
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}