// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

Console.Write("Введите количество строк ПЕРВОЙ матрицы: ");
bool isNumberRows1 = int.TryParse(Console.ReadLine(), out int rows1);
Console.Write("Введите количество столбцов ПЕРВОЙ матрицы: ");
bool isNumberColumns1 = int.TryParse(Console.ReadLine(), out int columns1);
Console.WriteLine();
Console.Write("Введите количество строк ВТОРОЙ матрицы: ");
bool isNumberRows2 = int.TryParse(Console.ReadLine(), out int rows2);
Console.Write("Введите количество столбцов ВТОРОЙ матрицы: ");
bool isNumberColumns2 = int.TryParse(Console.ReadLine(), out int columns2);
Console.WriteLine();

if (!isNumberRows1 || !isNumberColumns1 || rows1 < 1 || columns1 < 1 || !isNumberRows2 || !isNumberColumns2 || rows2 < 1 || columns2 < 1)
{
    Console.WriteLine("Данные введены неверно");
    return;
}

if (columns1 != rows2)
{
    Console.WriteLine("Число столбцов первой матрицы НЕ совпадает с числом строк второй матрицы");
    return;
}

int[,] array2D1 = CreateRandomArray(rows1, columns1);
int[,] array2D2 = CreateRandomArray(rows2, columns2);
Print2DArray(array2D1);
Console.WriteLine();
Print2DArray(array2D2);
Console.WriteLine();
Console.WriteLine("Результат: ");
Print2DArray(MultiplyMatrices(row: rows1,
                                column: columns2,
                                generalPart: rows2,
                                matrix1: array2D1,
                                matrix2: array2D2));




int[,] CreateRandomArray(int m, int n)
{
    int[,] array = new int[m, n];

    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(-100, 101);      //случайное целое число от -100 до 100
        }
    }
    return array;
}


void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}     ");
        }
        Console.WriteLine();
    }
}


int[,] MultiplyMatrices(int row, int column, int generalPart, int[,] matrix1, int[,] matrix2)
{
    int[,] array = new int[row, column];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int elem = 0;

            for (int k = 0; k < generalPart; k++)
            {
                elem += matrix1[i, k] * matrix2[k, j];
            }

            array[i, j] = elem;
        }
    }
    return array;
}