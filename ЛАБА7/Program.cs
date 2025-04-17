using System;
using System.Collections.Generic;
namespace Doom
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("0 — Сгенерировать файл (для заданий 1-5)");
                Console.WriteLine("1 — Задача 1: Проверка наличия числа в файле");
                Console.WriteLine("2 — Задача 2: Сумма чисел, кратных k");
                Console.WriteLine("3 — Задача 3: Переписать в другой файл строки, в которых нет цифр ");
                Console.WriteLine("4 — Задача 4: Из исходного файла получить новый файл, исключив повторные вхождения чисел");
                Console.WriteLine("5 — Задача 5: Получить название игрушек, цена которых не превышает k руб. и которые подходят детям 5 лет");
                Console.WriteLine("6 — Задача 6: Удалить из списка L все элементы с указанным значением");
                Console.WriteLine("7 — Задача 7: Перестановка в обратном порядке всех элементов между первым и последним вхождениями элемента E, если E входит в L не менее двух раз");
                Console.WriteLine("8 — Задача 8: Есть перечень фильмов. Определить для каждого фильма, какие из них посмотрели все n зрителей, какие — некоторые из зрителей, и какие — никто из зрителей.");
                Console.WriteLine("9 — Задача 9: Файл содержит текст на русском языке. Напечатать в алфавитном порядке все звонкие согласные буквы, которые входят более чем в одно слово");
                Console.WriteLine("10 — Задача 10: Сколько в среднем сотрудников работает в одном подразделении данного учреждения");
                Console.WriteLine("11 — Выход");

                int choice = Helper.getIntInput("Введите номер действия: ");

                if (choice == 11)
                {
                    Console.WriteLine("Выход из программы.");
                    break;
                }

                if (choice == 0)
                {
                    Console.WriteLine("Файл для какой задачи сгенерировать (1-5)?");
                    int choiseFile = Helper.getIntInput("Введите номер файла: ");
                    if (choiseFile == 1)
                    {
                        string fileName = Helper.getNewFileNameInput("Введите название файла с расширением (например, task1File.txt): ");
                        int count = Helper.getPositiveIntInput("Введите количество чисел для файла с одиночными значениями: ");
                        FileHelper.generateSingleNumberFile(fileName, count, 1, 100);
                        Console.WriteLine($"Файл \"{fileName}\" успешно создан/обновлён.");
                    }
                    if (choiseFile == 2)
                    {
                        string fileName = Helper.getNewFileNameInput("Введите название файла с расширением (например, task2File.txt): ");
                        int lines = Helper.getPositiveIntInput("Введите количество строк для файла с множественными значениями: ");
                        int numbersPerLine = Helper.getPositiveIntInput("Введите количество чисел в строке: ");
                        FileHelper.generateMultiNumberFile(fileName, lines, numbersPerLine, 1, 100);
                        Console.WriteLine($"Файл \"{fileName}\" успешно создан/обновлён.");
                    }
                    if (choiseFile == 3)
                    {
                        string fileName = Helper.getNewFileNameInput("Введите название файла с расширением (например, task3File.txt): ");
                        FileHelper.generateEmptyFile(fileName);
                        Console.WriteLine($"Файл \"{fileName}\" успешно создан/обновлён.");
                    }

                    if (choiseFile == 4)
                    {
                        Console.WriteLine("Введите количество чисел в бинарном файле: ");
                        Console.WriteLine("Введите название файла с расширением (например, task4File.bin):");
                        string fileName = Console.ReadLine(); // Считываем название файла
                        FileHelper.getNewFileNameInputBin(fileName); // Вызываем метод для создания файла
                        Console.WriteLine("Введите название для пустого файла с расширением (например, task4File2.bin):");
                        string fileName2 = Console.ReadLine(); // Считываем название файла
                        FileHelper.generateEmptyFile(fileName2);
                    }

                    if (choiseFile == 5)
                    {
                        Console.WriteLine("Введите название файла с расширением (например, task5File.xml):");
                        string fileName = Console.ReadLine(); // Считываем название файла
                        FileHelper.getNewFileNameInputBin(fileName); // Вызываем метод для создания файла
                    }
                }

                if (choice == 1)
                {
                    string fileName = Helper.getExistingFileNameInput("Введите название файла для проверки (например, task1File.txt): ");
                    if (fileName == null)
                    {
                        continue;
                    }
                    int b = Helper.getIntInput("Введите число для поиска в файле: ");
                    bool contains = FileTasks.containsNumber(fileName, b);
                    Console.WriteLine(contains
                        ? $"Число {b} найдено в файле."
                        : $"Число {b} не найдено в файле.");
                }

                if (choice == 2)
                {
                    string fileName = Helper.getExistingFileNameInput("Введите название файла для подсчёта (например, task2File.txt): ");
                    if (fileName == null)
                    {
                        continue;
                    }
                    int k = Helper.getIntInput("Введите число k для подсчёта суммы кратных ему значений: ");
                    int sum = FileTasks.sumOfMultiples(fileName, k);
                    Console.WriteLine($"Сумма чисел, кратных {k}, составляет: {sum}");
                }

                if (choice == 3)
                {
                    string inputFileName = Helper.getExistingFileNameInput("Введите название файла, в который нужно переписать строки без цифр (например, task3FileInput.txt): ");
                    if (inputFileName == null)
                    {
                        continue;
                    }
                    string outputFileName = Helper.getExistingFileNameInput("Введите название файла, из которого нужно переписать строки без цифр (например, task3FileOutut.txt): ");
                    if (outputFileName == null)
                    {
                        continue;
                    }
                    FileTasks.copyLineFile(outputFileName, inputFileName);
                }

                if (choice == 4)
                {
                    string inputFileName1 = Helper.getExistingFileNameInput("Введите название файла, из которого нужно получить количество противоположных чисел (например, task4File.bin): ");
                    if (inputFileName1 == null)
                    {
                        continue;
                    }
                    string inputFileName2 = Helper.getExistingFileNameInput("Введите название файла, в котором нужно получить количество противоположных чисел (например, task4File2.bin): ");
                    if (inputFileName2 == null)
                    {
                        continue;
                    }
                    FileTasks.binaryFile(inputFileName1, inputFileName2);
                }

                if (choice == 5)
                {
                    Console.Write("Введите имя XML-файла (например, toys.xml): ");
                    string fileName = Console.ReadLine();

                    FileTasks.CreateToyXmlFile(fileName);
                    if (int.TryParse(Console.ReadLine(), out int k))
                    {
                        FileTasks.FilterToys(fileName, k);
                    }
                    else
                    {
                        Console.WriteLine("Некорректное значение.");
                    }
                }

                if (choice == 6)
                {
                    Console.WriteLine("Выберите способ ввода данных:");
                    Console.WriteLine("1 — Ввести данные вручную");
                    Console.WriteLine("2 — Сгенерировать случайные данные");
                    Console.WriteLine("3 — Считать данные из файла");

                    int choiceList = Helper.getIntInput("Введите номер действия: ");

                    List<double> manualData = null;
                    List<double> randomData = null;
                    List<double> fileData = null;

                    // Ввести данные вручную
                    if (choiceList == 1)
                    {
                        manualData = InputList.getManualInput();
                        Console.WriteLine("Введенные данные:");
                        foreach (var num in manualData)
                        {
                            Console.Write(num + " ");
                        }
                        Console.WriteLine();
                    }

                    // Сгенерировать случайные данные
                    if (choiceList == 2)
                    {
                        int count = Helper.getPositiveIntInput("Введите количество случайных чисел для генерации: ");
                        randomData = InputList.getRandomInput(count);
                        Console.WriteLine("Сгенерированные случайные данные:");
                        foreach (var num in randomData)
                        {
                            Console.Write(num + " ");
                        }
                        Console.WriteLine();
                    }

                    // Считать данные из файла
                    if (choiceList == 3)
                    {
                        string fileName = Helper.getExistingFileNameInput("Введите имя файла для чтения данных: ");
                        fileData = InputList.getFileInput(fileName);
                        if (fileData != null)
                        {
                            Console.WriteLine("Данные из файла:");
                            foreach (var num in fileData)
                            {
                                Console.Write(num + " ");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Не удалось считать данные из файла.");
                        }
                    }

                    double valueToRemove = InputList.getInput("Введите значение для удаления: ");

                    // Удаление элементов из соответствующего списка
                    if (choiceList == 1 && manualData != null)
                    {
                        Tasks610.removeElements(manualData, valueToRemove);
                        InputList.printList(manualData);
                    }
                    else if (choiceList == 2 && randomData != null)
                    {
                        Tasks610.removeElements(randomData, valueToRemove);
                        InputList.printList(randomData);
                    }
                    else if (choiceList == 3 && fileData != null)
                    {
                        Tasks610.removeElements(fileData, valueToRemove);
                        InputList.printList(fileData);
                    }
                }

                if (choice == 7)
                {
                    Console.WriteLine("Выберите способ ввода данных:");
                    Console.WriteLine("1 — Ввести данные вручную");
                    Console.WriteLine("2 — Сгенерировать случайные данные");
                    Console.WriteLine("3 — Считать данные из файла");

                    int choiceList = Helper.getIntInput("Введите номер действия: ");

                    LinkedList<double> manualData = null;
                    LinkedList<double> randomData = null;
                    LinkedList<double> fileData = null;

                    // 1) Ввести данные вручную
                    if (choiceList == 1)
                    {
                        manualData = LinkedInputList.getManualInput();
                        if (manualData.Count < 2)
                        {
                            Console.WriteLine("Ошибка: должно быть не менее двух введённых чисел.");
                            return; // или повтор ввода
                        }

                        Console.WriteLine("Введённые данные:");
                        foreach (var num in manualData)
                            Console.Write(num + " ");
                        Console.WriteLine();
                    }

                    // 2) Сгенерировать случайные данные
                    if (choiceList == 2)
                    {
                        int count = Helper.getPositiveIntInput("Введите количество случайных чисел для генерации: ");
                        randomData = LinkedInputList.getRandomInput(count);
                        if (randomData.Count < 2)
                        {
                            Console.WriteLine("Ошибка: нужно сгенерировать как минимум два числа.");
                            return; // или повтор запроса количества
                        }

                        Console.WriteLine("Сгенерированные случайные данные:");
                        foreach (var num in randomData)
                            Console.Write(num + " ");
                        Console.WriteLine();
                    }

                    // 3) Считать данные из файла
                    if (choiceList == 3)
                    {
                        string fileName = Helper.getExistingFileNameInput("Введите имя файла для чтения данных: ");
                        fileData = LinkedInputList.getFileInput(fileName);
                        if (fileData == null)
                        {
                            Console.WriteLine("Не удалось считать данные из файла.");
                            return;
                        }
                        if (fileData.Count < 2)
                        {
                            Console.WriteLine("Ошибка: в файле должно быть не менее двух чисел.");
                            return;
                        }

                        Console.WriteLine("Данные из файла:");
                        foreach (var num in fileData)
                            Console.Write(num + " ");
                        Console.WriteLine();
                    }

                    double valueToReverse = LinkedInputList.getInput("Введите элемент E: ");

                    // Удаление элементов из соответствующего списка
                    if (choiceList == 1 && manualData != null)
                    {
                        Tasks610.reverseBetweenFirstAndLast(manualData, valueToReverse);
                        LinkedInputList.printList(manualData);
                    }
                    else if (choiceList == 2 && randomData != null)
                    {
                        Tasks610.reverseBetweenFirstAndLast(randomData, valueToReverse);
                        LinkedInputList.printList(randomData);
                    }
                    else if (choiceList == 3 && fileData != null)
                    {
                        Tasks610.reverseBetweenFirstAndLast(fileData, valueToReverse);
                        LinkedInputList.printList(fileData);
                    }
                }

                if (choice == 8)
                {
                    // Читаем общий список фильмов
                    List<string> allFilms = null;
                    while (true)
                    {
                        try
                        {
                            string allFilmsFile = Helper.getExistingFileNameInput("Введите имя файла со списком всех фильмов (например, AllFilms.txt): ");
                            allFilms = FileHelper.readLines(allFilmsFile);
                            if (allFilms.Count == 0)
                            {
                                throw new Exception("Файл пуст.");
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка при чтении файла со всеми фильмами: " + ex.Message);
                            int choiceFilms = Helper.getIntInput("Нажмите 1, чтобы попробовать снова, или 0 для выхода: ");
                            if (choice == 0)
                                return;
                        }
                    }

                    // Читаем файлы, содержащие списки фильмов каждого зрителя
                    List<string> viewerLines = null;
                    while (true)
                    {
                        try
                        {
                            string viewersFile = Helper.getExistingFileNameInput("Введите имя файла со списками фильмов зрителей (например, viewersFilms.txt): ");
                            viewerLines = FileHelper.readLines(viewersFile);
                            if (viewerLines.Count == 0)
                            {
                                throw new Exception("Файл пуст.");
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка при чтении файла со списками зрителей: " + ex.Message);
                            int choiceFilms = Helper.getIntInput("Нажмите 1, чтобы попробовать снова, или 0 для выхода: ");
                            if (choiceFilms == 0)
                                return;
                        }
                    }
                    Tasks610.processFilms(allFilms, viewerLines);
                }

                if (choice == 9)
                {
                    string fileName = Helper.getExistingFileNameInput("Введите имя файла для чтения данных: ");
                    Tasks610.dict(fileName);
                }

                if (choice == 10)
                {
                    string fileName = Helper.getExistingFileNameInput("Введите имя файла для чтения данных: ");
                    Tasks610.sl(fileName);
                }

            }
        }
    }
}