using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("задание 1");
        Console.Write("Введите размер массива: ");
        int size = int.Parse(Console.ReadLine());

        int[] array = new int[size];

        Console.WriteLine($"Введите {size} элементов массива:");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Элемент [{i}]: ");
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\nСозданный массив:");
        for (int i = 0; i < size; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
