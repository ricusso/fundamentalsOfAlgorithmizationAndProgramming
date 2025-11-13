using System;

class Program
{
    static long Factorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * Factorial(n - 1);
    }

    static int Fibonacci(int n)
    {
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static int FindMax(int[] array, int index = 0)
    {
        if (index == array.Length - 1)
            return array[index];

        int current = array[index];
        int maxOfRest = FindMax(array, index + 1);

        return current > maxOfRest ? current : maxOfRest;
    }

    static void Main()
    {
        Console.WriteLine("=== РЕКУРСИВНЫЕ АЛГОРИТМЫ ===\n");

        Console.WriteLine("ВЫЧИСЛЕНИЕ ФАКТОРИАЛА:");
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine($"{i}! = {Factorial(i)}");
        }

        Console.WriteLine("\nРЯД ФИБОНАЧЧИ:");
        for (int i = 0; i <= 8; i++)
        {
            Console.WriteLine($"F({i}) = {Fibonacci(i)}");
        }

        Console.WriteLine("\nПОИСК МАКСИМАЛЬНОГО ЗНАЧЕНИЯ:");
        int[] testArray1 = { 3, 7, 2, 9, 1, 8, 5 };
        Console.Write($"Массив 1: [{string.Join(", ", testArray1)}]");
        Console.WriteLine($" -> Максимум: {FindMax(testArray1)}");

        int[] testArray2 = { -5, -2, -8, -1, -3 };
        Console.Write($"Массив 2: [{string.Join(", ", testArray2)}]");
        Console.WriteLine($" -> Максимум: {FindMax(testArray2)}");

        int[] testArray3 = { 42 };
        Console.Write($"Массив 3: [{string.Join(", ", testArray3)}]");
        Console.WriteLine($" -> Максимум: {FindMax(testArray3)}");
    }
}