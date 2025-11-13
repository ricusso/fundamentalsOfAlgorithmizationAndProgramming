using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("задание2");
        Console.Write("Введите размер массива: ");
        int x = int.Parse(Console.ReadLine());

        int[] array = new int[x];
        int[] resultArray = new int[x];

        Console.WriteLine($"Введите {x} элементов массива:");
        for (int i = 0; i < x; i++)
        {
            Console.Write($"Элемент [{i}]: ");
            array[i] = int.Parse(Console.ReadLine());
        }

        int left = 0;
        int right = x - 1;
        for (int i = 0; i < x; i++)
        {
            if (i % 2 == 0)
            {
                resultArray[i] = array[right];
                right--;
            }
            else
            {
                resultArray[i] = array[left];
                left++;
            }
        }

        Console.WriteLine("\nМассив в особом порядке:");
        for (int i = 0; i < x; i++)
        {
            Console.Write(resultArray[i] + " ");
        }

        Console.WriteLine("\nМассив в правильном порядке:");
        for (int i = 0; i < x; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
