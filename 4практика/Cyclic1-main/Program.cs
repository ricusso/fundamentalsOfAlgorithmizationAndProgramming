using System;

class WhileVsDoWhile
{
    static void Main()
    {
        int i = 5;

        Console.WriteLine("Демонстрация цикла while:");
        while (i < 5)
        {
            Console.WriteLine($"Это сообщение не выведется, т.к. i = {i}");
            i++;
        }

        i = 5;

        Console.WriteLine("\nДемонстрация цикла do-while:");
        
        do
        {
            Console.WriteLine($"Это сообщение ВЫВЕДЕТСЯ, т.к. do-while выполняется хотя бы один раз. i = {i}");
            i++;
        } while (i < 5);
    }
}