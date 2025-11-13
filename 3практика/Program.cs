using System;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор с расширенным функционалом");
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.WriteLine("5. Возведение в степень");
            Console.WriteLine("6. Извлечение квадратного корня");
            Console.WriteLine("7. Остаток от деления");
            Console.WriteLine("8. Решение квадратного уравнения");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Addition();
                    break;
                case 2:
                    Subtraction();
                    break;
                case 3:
                    Multiplication();
                    break;
                case 4:
                    Division();
                    break;
                case 5:
                    Power();
                    break;
                case 6:
                    SquareRoot();
                    break;
                case 7:
                    Modulo();
                    break;
                case 8:
                    QuadraticEquation();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void Addition()
        {
            Console.Write("Введите первое число: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {a + b}");
        }

        static void Subtraction()
        {
            Console.Write("Введите первое число: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {a - b}");
        }

        static void Multiplication()
        {
            Console.Write("Введите первое число: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {a * b}");
        }

        static void Division()
        {
            Console.Write("Введите делимое: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите делитель: ");
            double b = double.Parse(Console.ReadLine());
            if (b != 0)
                Console.WriteLine($"Результат: {a / b}");
            else
                Console.WriteLine("Ошибка: деление на ноль.");
        }

        static void Power()
        {
            Console.Write("Введите основание: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите степень: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {Math.Pow(a, b)}");
        }

        static void SquareRoot()
        {
            Console.Write("Введите число: ");
            double a = double.Parse(Console.ReadLine());
            if (a >= 0)
                Console.WriteLine($"Результат: {Math.Sqrt(a)}");
            else
                Console.WriteLine("Ошибка: корень из отрицательного числа.");
        }

        static void Modulo()
        {
            Console.Write("Введите делимое: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите делитель: ");
            int b = int.Parse(Console.ReadLine());
            if (b != 0)
                Console.WriteLine($"Результат: {a % b}");
            else
                Console.WriteLine("Ошибка: деление на ноль.");
        }
        static void QuadraticEquation()
        {
            Console.Write("Введите коэффициент a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите коэффициент b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите коэффициент c: ");
            double c = double.Parse(Console.ReadLine());

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Корни уравнения: x1 = {x1}, x2 = {x2}");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Уравнение имеет один корень: x = {x}");
            }
            else
            {
                Console.WriteLine("Уравнение не имеет действительных корней.");
            }
        }
    }
}