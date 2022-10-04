// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

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
Console.WriteLine();
Print2DArray(Sort2DArray(array2D));




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


int[] SortArray(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] < array[j])
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
    return array;
}


int[,] Sort2DArray(int[,] array)
{
    int[] arrayString = new int[array.GetLength(1)];
    int[,] sortedArray = new int[array.GetLength(0), array.GetLength(1)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)           //получение строки массива
        {
            arrayString[j] = array[i, j];
        }

        int[] sortedArrayString = SortArray(arrayString);      //сортировка строки массива

        for (int k = 0; k < array.GetLength(1); k++)           //замена несортированной строки на нужную
        {
            array[i, k] = sortedArrayString[k];
        }
    }
    return array;
}