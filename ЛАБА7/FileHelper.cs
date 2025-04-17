using System;
using System.IO;
using System.Collections.Generic;
namespace Doom
{
    /// Класс для генерации файлов с числами
    internal static class FileHelper
    {
        /// Генерация файла с одиночными значениями для задачи 1 
        public static void generateSingleNumberFile(string fileName, int count, int minValue, int maxValue)
        {
            var random = new Random();
            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteLine(random.Next(minValue, maxValue + 1));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации файла: {ex.Message}");
            }
        }

        /// Генерация файла с множественными значениями для задачи 2 
        public static void generateMultiNumberFile(string fileName, int lines, int numbersPerLine, int minValue, int maxValue)
        {
            var random = new Random();
            try
            {
                using (var writer = new StreamWriter(fileName))
                {
                    for (int i = 0; i < lines; i++)
                    {
                        for (int j = 0; j < numbersPerLine; j++)
                        {
                            writer.Write(random.Next(minValue, maxValue + 1));
                            if (j < numbersPerLine - 1)
                            {
                                writer.Write(" ");
                            }
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации файла: {ex.Message}");
            }
        }

        /// Генерация пустого файла для задачи 3 
        public static void generateEmptyFile(string fileName)
        {
            using (var stream = File.Create(fileName))
            {

            }
        }

        /// Генерация файла для задачи 4
        public static void getNewFileNameInputBin(string fileName)
        {
            var random = new Random();
            int n = random.Next(10, 101);
            try
            {
                List<int> numbers = new List<int>();

                int half = n / 2;
                for (int i = 0; i < half; i++)
                {
                    int number = random.Next(-100, 101);
                    numbers.Add(number);
                }

                while (numbers.Count < n)
                {
                    int index = random.Next(half);
                    int opposite = -numbers[index];


                    if (numbers.Count(x => x == opposite) < 1)
                    {
                        numbers.Add(opposite);
                    }
                    else
                    {
                        numbers.Add(random.Next(-100, 101));
                    }
                }

                numbers = numbers.OrderBy(x => random.Next()).ToList();

                using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    foreach (int number in numbers)
                    {
                        writer.Write(number);
                    }
                }

                Console.WriteLine($"Файл '{fileName}' успешно создан");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации файла: {ex.Message}");
            }
        }


        /// задача 8
        /// Считывает непустые строки из указанного файла.
        public static List<string> readLines(string fileName)
        {
            List<string> linesList = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        linesList.Add(line.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Невозможно прочитать файл {fileName}: {ex.Message}");
            }
            return linesList;
        }

    }
}