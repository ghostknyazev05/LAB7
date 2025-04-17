using System;
using System.Collections.Generic;
namespace Doom
{
    /// Класс, содержащий методы для ввода данных от пользователя 
    internal static class Helper
    {
        /// Получение положительного целого числа
        public static int getPositiveIntInput(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value > 0)
            {
                return value;
            }
            return getPositiveIntInput("Пожалуйста, введите положительное целое число: ");
        }

        /// Получение целого числа
        public static int getIntInput(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                return value;
            }
            return getIntInput("Пожалуйста, введите корректное целое число: ");
        }

        /// Получение имени файла с расширением для создания нового файла
        public static string getNewFileNameInput(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Contains("."))
            {
                return input;
            }
            Console.WriteLine("Некорректное имя файла. Попробуйте снова.");
            return getNewFileNameInput(prompt);
        }

        /// Получение существующего имени файла для проверки.
        /// Если файл не существует, запрашивает действия у пользователя.
        public static string getExistingFileNameInput(string prompt)
        {
            string fileName;
            while (true)
            {
                Console.Write(prompt);
                fileName = Console.ReadLine();
                if (File.Exists(fileName))
                {
                    return fileName;
                }

                Console.WriteLine("Файл не существует. Хотите попробовать снова? (y/n)");
                string input = Console.ReadLine();
                if (input?.ToLower() == "n")
                {
                    return null;
                }
                Console.WriteLine("Попробуйте ввести имя файла снова.");
            }
        }
    }
}