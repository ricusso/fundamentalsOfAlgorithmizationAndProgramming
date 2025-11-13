using System;

class PowersOfTwo
{
    static void Main()
    {
        Console.Write("Введите максимальное число i: ");
        int maxNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Последовательность степеней двойки до {maxNumber}:");

        int current = 1;

     
        while (current <= maxNumber)
        {
            Console.Write(current + " ");
            current *= 2; 
        }

        Console.WriteLine(); 
    }
}