using System;
using System.Linq;

namespace NumberSystemConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Программа-переводчик систем счисления");
                Console.WriteLine("1 - Двоичная в десятичную");
                Console.WriteLine("2 - Десятичная в двоичную");
                Console.WriteLine("3 - Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();

               
                var result = choice switch
                {
                    "1" => BinaryToDecimal(),
                    "2" => DecimalToBinary(),
                    "3" => ExitProgram(),
                    _ => "Неверный выбор"
                };

                Console.WriteLine(result);
                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static string BinaryToDecimal()
        {
            Console.Write("Введите двоичное число (до 8 знаков): ");
            string binaryString = Console.ReadLine();

            string lengthCheck = binaryString.Length > 8 ? "Ошибка: больше 8 знаков!" : "";

            bool isValid = binaryString.All(c => c == '0' || c == '1');
            string validityCheck = isValid ? "" : "Ошибка: не двоичное число!";

            string error = lengthCheck + validityCheck;

            return error != "" ? error :
                   $"Двоичное: {binaryString} -> Десятичное: {Convert.ToInt32(binaryString, 2)}";
        }

        static string DecimalToBinary()
        {
            Console.Write("Введите десятичное число: ");
            string input = Console.ReadLine();

            bool isNumber = int.TryParse(input, out int decimalNumber);

            string numberCheck = isNumber ? "" : "Ошибка: не число!";
            string signCheck = isNumber && decimalNumber < 0 ? "Ошибка: отрицательное!" : "";

            string error = numberCheck + signCheck;

            return error != "" ? error :
                   $"Десятичное: {decimalNumber} -> Двоичное: {Convert.ToString(decimalNumber, 2).PadLeft(8, '0')}";
        }

        static string ExitProgram()
        {
            Environment.Exit(0);
            return "";
        }
    }
}
