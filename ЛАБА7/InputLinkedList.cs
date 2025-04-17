using System;
using System.Collections.Generic;
using System.IO;

namespace Doom
{
    /// Класс для способов ввода данных в связный список.
    internal static class LinkedInputList
    {
        // Метод для ввода данных вручную
        public static LinkedList<double> getManualInput()
        {
            LinkedList<double> list = new LinkedList<double>();
            Console.WriteLine("Введите числа (введите 'end' для завершения):");

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end")
                {
                    break;
                }

                if (double.TryParse(input, out double number))
                {
                    list.AddLast(number);
                }
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                }
            }

            return list;
        }

        // Метод для генерации случайных данных
        public static LinkedList<double> getRandomInput(int count)
        {
            Random random = new Random();
            LinkedList<double> list = new LinkedList<double>();

            for (int i = 0; i < count; i++)
            {
                list.AddLast(Math.Round((random.NextDouble() * 100), 3)); // случайные числа от 0 до 100
            }

            return list;
        }

        // Метод для считывания данных из файла
        public static LinkedList<double> getFileInput(string fileName)
        {
            LinkedList<double> list = new LinkedList<double>();

            try
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("Файл не найден. Попробуйте снова или введите 0 для выхода.");
                    return list;
                }

                var lines = File.ReadLines(fileName);
                foreach (var line in lines)
                {
                    var numbers = line.Split(' ');
                    foreach (var num in numbers)
                    {
                        if (double.TryParse(num, out double n))
                        {
                            list.AddLast(n);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return list;
        }

        // Метод для получения строки с клавиатуры
        public static string getStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // Метод для получения целого числа с клавиатуры
        public static double getInput(string prompt)
        {
            Console.Write(prompt);
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                }
            }
        }

        // Метод для печати списка
        public static void printList(LinkedList<double> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
