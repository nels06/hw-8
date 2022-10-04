// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Console.Write("Введите количество строк: ");
bool isNumberRows = int.TryParse(Console.ReadLine(), out int rows);
Console.Write("Введите количество столбцов: ");
bool isNumberColumns = int.TryParse(Console.ReadLine(), out int columns);

if (!isNumberRows || !isNumberColumns || rows < 1 || columns < 1)
{
    Console.WriteLine("Данные введены неверно");
    return;
}

int[,] array2D = CreateRandomArray(rows, columns);
Print2DArray(array2D);
Console.WriteLine($"Номер строки с наименьшей суммой элементов: {FindRowNumber(array2D)}");



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


int FindRowNumber(int[,] array)
{
    int minSum = 0;

    for (int k = 0; k < array.GetLength(1); k++)
    {
        minSum += array[0, k];
    }

    int rowNumber = 1;


    for (int i = 1; i < array.GetLength(0); i++)
    {
        int sum = 0;

        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }

        if (sum < minSum)
        {
            minSum = sum;
            rowNumber = i + 1;
        }
    }

    return rowNumber;
}