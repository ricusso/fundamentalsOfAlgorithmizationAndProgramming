using System;

class Program
{
    static void Main()
    {
      
        // Задание 1
        Console.WriteLine("Задание 1: Смена регистра через один символ");
        Console.Write("Введите строку: ");
        string inputString = Console.ReadLine();
        string resultString = ChangeCaseEveryOther(inputString);
        Console.WriteLine($"Результат: {resultString}\n");

        // Задание 2
        Console.WriteLine("Задание 2: Вывод чисел от 0 до N");
        Console.Write("Введите число (до 1000): ");
        if (int.TryParse(Console.ReadLine(), out int number) && number <= 1000 && number >= 0)
        {
            PrintNumbersFromZero(number);
        }
        else
        {
            Console.WriteLine("Ошибка: введите корректное число от 0 до 1000");
        }
        Console.WriteLine();

        // Задание 3
        Console.WriteLine("Задание 3: Массив и обратный вывод");
        int[] array = CreateAndReverseArray();
        Console.WriteLine($"Массив в обратном порядке: {string.Join(".", array)}\n");

        Console.WriteLine("Программа успешно выполнена!");
    }

    //Задания 1
    static string ChangeCaseEveryOther(string input)
    {
        char[] chars = input.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (i % 2 == 0) 
            {
                chars[i] = char.ToUpper(chars[i]);
            }
            else 
            {
                chars[i] = char.ToLower(chars[i]);
            }
        }
        return new string(chars);
    }

    //Задания 2
    static void PrintNumbersFromZero(int n)
    {
        Console.Write($"Числа от 0 до {n}: ");
        for (int i = 0; i <= n; i++)
        {
            Console.Write(i);
            if (i < n) Console.Write(".");
        }
        Console.WriteLine();
    }

    //Задания 3
    static int[] CreateAndReverseArray()
    {
        int[] array = new int[5];
        Console.WriteLine("Введите 5 элементов массива:");

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Элемент {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.Write("Ошибка! Введите целое число: ");
            }
        }

        Console.Write($"Введенный массив: {string.Join(".", array)}");
        Console.WriteLine();

        return array;
    }
}