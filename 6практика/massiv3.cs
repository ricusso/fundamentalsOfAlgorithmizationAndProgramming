using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("задание3");

        int[,] matrix = new int[10, 10];
        Random random = new Random();

        Console.WriteLine("Массив 10x10:");
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                matrix[i, j] = random.Next(1, 10);
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int[] rowSums = new int[10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                rowSums[i] += matrix[i, j];
            }
        }

        long[] columnProducts = new long[10];
        for (int j = 0; j < 10; j++)
        {
            columnProducts[j] = 1;
            for (int i = 0; i < 10; i++)
            {
                columnProducts[j] *= matrix[i, j];
            }
        }

        Console.WriteLine("\nСуммы строк:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Строка {i}: {rowSums[i]}");
        }

        Console.WriteLine("\nПроизведения столбцов:");
        for (int j = 0; j < 10; j++)
        {
            Console.WriteLine($"Столбец {j}: {columnProducts[j]}");
        }

        int maxRowSum = rowSums[0];
        int maxRowIndex = 0;
        for (int i = 1; i < 10; i++)
        {
            if (rowSums[i] > maxRowSum)
            {
                maxRowSum = rowSums[i];
                maxRowIndex = i;
            }
        }

        long maxColumnProduct = columnProducts[0];
        int maxColumnIndex = 0;
        for (int j = 1; j < 10; j++)
        {
            if (columnProducts[j] > maxColumnProduct)
            {
                maxColumnProduct = columnProducts[j];
                maxColumnIndex = j;
            }
        }

        Console.WriteLine($"\nМаксимальная сумма строки: {maxRowSum} (строка {maxRowIndex})");
        Console.WriteLine($"Максимальное произведение столбца: {maxColumnProduct} (столбец {maxColumnIndex})");
    }
}
