// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

Console.Write("Введите количество строк: ");
bool isNumberRows = int.TryParse(Console.ReadLine(), out int rows);
Console.Write("Введите количество столбцов: ");
bool isNumberColumns = int.TryParse(Console.ReadLine(), out int columns);
Console.Write("Введите количество слоёв (глубину): ");
bool isNumberLayers = int.TryParse(Console.ReadLine(), out int layers);
Console.WriteLine();

if (!isNumberRows || !isNumberColumns || !isNumberLayers || rows < 1 || columns < 1 || layers < 1)
{
    Console.WriteLine("Данные введены неверно");
    return;
}
if (rows * columns * layers > 90)
{
    Console.WriteLine("Создать необходимый массив невозможно");
    return;
}

Console.WriteLine("Результат: ");
Print3DArray(CreateRandomArray(rows, columns, layers));




bool CheckUniqueness(int number, int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] == number)
        {
            return true;
        }
    }
    return false;
}


int[,,] CreateRandomArray(int m, int n, int l)
{
    int[,,] array = new int[m, n, l];
    int[] arrayOfUsedNumbers = new int[(m * n * l)];
    int count = 0;

    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                int num = random.Next(10, 100);                    //случайное целое число от 10 до 99
                while (CheckUniqueness(num, arrayOfUsedNumbers))
                {
                    num = random.Next(10, 100);
                }
                array[i, j, k] = num;
                arrayOfUsedNumbers[count] = num;
                count++;
            }
        }
    }
    return array;
}


void Print3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]} ({i}, {j}, {k})    ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
