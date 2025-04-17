using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Numerics;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace Doom
{

    /// Класс, содержащий задачи для работы с файлами
    internal static class FileTasks
    {
        /// Задача 1: Проверка наличия числа в файле
        public static bool containsNumber(string fileName, int number)
        {
            try
            {
                var lines = File.ReadLines(fileName);
                foreach (var line in lines)
                {
                    var numbers = line.Split(' ');
                    foreach (var num in numbers)
                    {
                        if (int.TryParse(num, out int n) && n == number)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return false;
            }
        }

        /// Задача 2: Сумма чисел, кратных k
        public static int sumOfMultiples(string fileName, int k)
        {
            int sum = 0;
            try
            {
                var lines = File.ReadLines(fileName);
                foreach (var line in lines)
                {
                    var numbers = line.Split(' ');
                    foreach (var num in numbers)
                    {
                        if (int.TryParse(num, out int n) && n % k == 0)
                        {
                            sum += n;
                        }
                    }
                }
                return sum;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return 0;
            }
        }


        /// Задача 3: строки, в которых нет цифр
        public static void copyLineFile(string inputFileName, string outputFileName)
        {
            try
            {

                using (var reader = new StreamReader(inputFileName))
                using (var writer = new StreamWriter(outputFileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!containsDigit(line))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                Console.WriteLine("Строки без цифр были успешно записаны в новый файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
            }
        }

        /// Проверяет, содержит ли строка хотя бы одну цифру.
        private static bool containsDigit(string input)
        {
            foreach (var c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }


        /// Задача 4: 
        public static void binaryFile(string inputFileName, string outputFileName)
        {
            try
            {
                var numbers = new List<int>();

                using (var reader = new BinaryReader(File.Open(inputFileName, FileMode.Open)))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                        numbers.Add(reader.ReadInt32());
                }

                numbers.Sort();

                using (var writer = new BinaryWriter(File.Open(outputFileName, FileMode.Create)))
                {
                    int? prev = null;
                    foreach (int num in numbers)
                    {
                        if (prev == null || num != prev.Value)
                        {
                            writer.Write(num);
                            prev = num;
                        }
                    }
                }

                Console.WriteLine($"Файл без повторов успешно создан (сортировка): {outputFileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
            }
        }


        /// Задача 5: Получить название игрушек, цена которых не превышает k руб. и которые подходят детям 5 лет 
        /// [Serializable]
        public class Toy
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int AgeFrom { get; set; }
            public int AgeTo { get; set; }
        }

        public static void CreateToyXmlFile(string fileName)
        {
            var toys = new List<Toy>();
            Console.Write("Сколько игрушек вы хотите ввести? ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count < 1)
            {
                Console.WriteLine("Некорректное число.");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nИгрушка #{i + 1}:");

                Console.Write("Название: ");
                string name = Console.ReadLine();

                int price = GetIntInput("Цена: ");
                int ageFrom = GetIntInput("Возраст от: ");
                int ageTo = GetIntInput("Возраст до: ");

                toys.Add(new Toy
                {
                    Name = name,
                    Price = price,
                    AgeFrom = ageFrom,
                    AgeTo = ageTo
                });
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    serializer.Serialize(fs, toys);
                }
                Console.WriteLine($"\nФайл '{fileName}' успешно создан.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи XML: {ex.Message}");
            }
        }

        public static void FilterToys(string fileName, int maxPrice)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    var toys = (List<Toy>)serializer.Deserialize(fs);

                    var result = toys.Where(t => t.Price <= maxPrice && t.AgeFrom <= 5 && t.AgeTo >= 5);

                    Console.WriteLine($"\nИгрушки по цене до {maxPrice} руб. и для 5 лет:");
                    foreach (var toy in result)
                    {
                        Console.WriteLine(toy.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении XML: {ex.Message}");
            }
        }

        private static int GetIntInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                    return result;

                Console.WriteLine("Введите корректное число.");
            }
        }


    }
}

