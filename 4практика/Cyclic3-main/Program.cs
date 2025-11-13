static void Main()
{
    Console.Write("Введите количество чисел в ряду Фибоначчи: ");
    int count = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"Ряд Фибоначчи из {count} чисел:");

    if (count <= 0)
    {
        Console.WriteLine("Количество должно быть положительным числом!");
    }
    else if (count == 1)
    {
        Console.WriteLine("0");
    }
    else if (count == 2)
    {
        Console.WriteLine("0 1");
    }
    else
    {
        long first = 0, second = 1;
        Console.Write(first + " " + second + " ");

        int current = 2;

        // Цикл do-while - генерация оставшихся чисел
        do
        {
            long next = first + second;
            Console.Write(next + " ");

            //обновляем значения
            first = second;
            second = next;

            current++;
        } while (current < count);

        Console.WriteLine();
    }
}
    