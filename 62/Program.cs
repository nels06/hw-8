// Напишите программу, которая заполнит спирально массив 4 на 4.

// Программа, заполняющая спирально массив n на n.

Console.Write("Введите количество строк и столбцов: ");
bool isNumberN = int.TryParse(Console.ReadLine(), out int n);
Console.WriteLine();

if (!isNumberN || n < 1)
{
    Console.WriteLine("Данные введены неверно");
    return;
}

Print2DArray(CreateArray(n));



int[,] CreateArray(int n)
{
    int[,] array = new int[n, n];
    int x = 1;
    int count = 0;

    while (x<= n*n)
    {
        for (int i = count; i < n-count; i++)         //i = 1, i < 4
        {
            array[count, i] = x;
            x++;
        }

        for (int i = count + 1; i < n-count; i++)       //i = 1, i < 4
        {
            array[i, n - count - 1] = x;        //3
            x++;
        }
        
        for (int i = n-2-count; i >= count; i--)       //i = 2, i >= 1
        {
            array[n - count - 1, i] = x;
            x++;
        }

        for (int i = n-2-count; i >= count+1; i--)               //i = 2, i < 4
        {
            array[i, count] = x;
            x++;
        }

        count++;
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
