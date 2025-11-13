using System;
using System.Collections.Generic;
using System.Text;

namespace StringPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Практическая работа №7 - Работа со строками");
            Task1();
            Task2();
            Task3();
        }

        static void Task1()
        {
            Console.WriteLine("\nЗадание 1: Разбиение строки по символу");

            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            Console.Write("Введите символ-разделитель: ");
            char separator = Console.ReadKey().KeyChar;
            Console.WriteLine();

            string[] parts = input.Split(separator);
            string result = string.Join(" ", parts);

            Console.WriteLine($"Результат: {result}");
        }

        static void Task2()
        {
            Console.WriteLine("\nЗадание 2: Подсчет символов и преобразование в верхний регистр");

            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            Console.Write("Введите символ для поиска: ");
            char searchChar = Console.ReadKey().KeyChar;
            Console.WriteLine();

            int count = 0;
            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == searchChar)
                {
                    count++;
                    chars[i] = char.ToUpper(chars[i]);
                }
            }

            string result = new string(chars);

            Console.WriteLine($"Количество символов '{searchChar}': {count}");
            Console.WriteLine($"Результат: {result}");
        }

        static void Task3()
        {
            Console.WriteLine("\nзадание 3: Шифратор и дешифратор Цезаря");

            char[] russianAlphabet = {
                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й',
                'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
                'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
            };

            Console.Write("Введите слово (кириллица): ");
            string word = Console.ReadLine().ToUpper();

            Console.Write("Введите число для сдвига: ");
            int shift = int.Parse(Console.ReadLine());

            string encrypted = CaesarCipher(word, shift, russianAlphabet, true);
            Console.WriteLine($"Зашифрованное слово: {encrypted}");

            string decrypted = CaesarCipher(encrypted, shift, russianAlphabet, false);
            Console.WriteLine($"Расшифрованное слово: {decrypted}");
        }

        static string CaesarCipher(string text, int shift, char[] alphabet, bool encrypt)
        {
            StringBuilder result = new StringBuilder();
            int alphabetSize = alphabet.Length;

            foreach (char c in text)
            {
                if (c == ' ')
                {
                    result.Append(' ');
                    continue;
                }

                int index = Array.IndexOf(alphabet, c);
                if (index == -1)
                {
                    result.Append(c);
                    continue;
                }

                int newIndex;
                if (encrypt)
                {
                    newIndex = (index + shift) % alphabetSize;
                    if (newIndex < 0) newIndex += alphabetSize;
                }
                else
                {
                    newIndex = (index - shift) % alphabetSize;
                    if (newIndex < 0) newIndex += alphabetSize;
                }

                result.Append(alphabet[newIndex]);
            }

            return result.ToString();
        }
    }
}