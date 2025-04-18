using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doom
{
    /// Класс, который реализует решения задач 6-10
    internal class Tasks610
    {
        /// Задача 6: Удалить из списка L все элементы с указанным значением
        public static void removeElements(List<double> list, double valueToRemove)
        {
            try
            {
                list.RemoveAll(item => item == valueToRemove);
                Console.WriteLine($"Все элементы со значением {valueToRemove} были удалены:");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении элементов из списка: {ex.Message}");
            }
        }

        /// Задача 7: В списке L переставить в обратном порядке все элементы между первым и последним вхождениями элемента E, если E входит в L не менее двух раз
        public static void reverseBetweenFirstAndLast(LinkedList<double> list, double element)
        {
            LinkedListNode<double> firstNode = null;
            LinkedListNode<double> lastNode = null;

            for (var node = list.First; node != null; node = node.Next)
            {
                if (node.Value.Equals(element))
                {
                    if (firstNode == null)
                    {
                        firstNode = node;
                    }
                    lastNode = node;
                }
            }


            if (firstNode != null && lastNode != null && firstNode != lastNode)
            {
                var nodesToReverse = new List<LinkedListNode<double>>();
                for (var node = firstNode.Next; node != lastNode; node = node.Next)
                {
                    nodesToReverse.Add(node);
                }

                nodesToReverse.Reverse();

                foreach (var node in nodesToReverse)
                {
                    list.Remove(node);
                    list.AddBefore(lastNode, node.Value);
                }
            }
        }


        /// Задача 8: Есть перечень фильмов. Определить для каждого фильма, какие из них посмотрели все n зрителей, какие — некоторые из зрителей, и какие — никто из зрителей
        public static void processFilms(List<string> allFilms, List<string> viewerLines)
        {

            List<HashSet<string>> viewersFilms = new List<HashSet<string>>();
            foreach (string line in viewerLines)
            {
                string[] films = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                HashSet<string> filmSet = new HashSet<string>();
                foreach (string film in films)
                {
                    filmSet.Add(film.Trim());
                }
                viewersFilms.Add(filmSet);
            }

            HashSet<string> watchedByEveryone = new HashSet<string>(viewersFilms[0]);
            for (int i = 1; i < viewersFilms.Count; i++)
            {
                watchedByEveryone.IntersectWith(viewersFilms[i]);
            }

            HashSet<string> watchedByAnyone = new HashSet<string>(viewersFilms[0]);
            for (int i = 1; i < viewersFilms.Count; i++)
            {
                watchedByAnyone.UnionWith(viewersFilms[i]);
            }

            HashSet<string> watchedBySome = new HashSet<string>(watchedByAnyone);
            watchedBySome.ExceptWith(watchedByEveryone);

            HashSet<string> watchedByNoOne = new HashSet<string>(allFilms);
            watchedByNoOne.ExceptWith(watchedByAnyone);

            Console.WriteLine("\nФильмы, просмотренные каждым зрителем:");
            printSet(watchedByEveryone);

            Console.WriteLine("\nФильмы, которые посмотрели часть зрителей");
            printSet(watchedBySome);

            Console.WriteLine("\nФильмы, которые никто не посмотрел");
            printSet(watchedByNoOne);
        }

        private static void printSet(HashSet<string> set)
        {
            if (set.Count == 0)
            {
                Console.WriteLine("(none)");
                return;
            }
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }


        /// Задача 9: Файл содержит текст на русском языке. Напечатать в алфавитном порядке все звонкие согласные буквы, которые входят более чем в одно слово
        public static void dict(string fileName)
        {
            HashSet<char> voicedConsonants = new HashSet<char> { 'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'л', 'м', 'н', 'р' };

            string text = File.ReadAllText(fileName).ToLower();


            char[] punctuation = { '.', ',', ';', ':', '!', '?', '-', '_', '"', '<', '>', '(', ')', '[', ']', '{', '}', '/', '\\', '\'', '«', '»' };
            foreach (char c in punctuation)
            {
                text = text.Replace(c, ' ');
            }

            string[] words = text.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);


            Dictionary<char, HashSet<string>> letterToWords = new Dictionary<char, HashSet<string>>();
            foreach (char c in voicedConsonants)
            {
                letterToWords[c] = new HashSet<string>();
            }


            foreach (string word in words)
            {
                foreach (char c in word)
                {
                    if (voicedConsonants.Contains(c))
                    {
                        letterToWords[c].Add(word);
                    }
                }
            }

            Console.WriteLine("Звонкие согласные, входящие более чем в одно слово:");
            foreach (char c in letterToWords.Keys.OrderBy(c => c))
            {
                if (letterToWords[c].Count > 1)
                {
                    Console.Write(c + " ");
                }
            }
            Console.WriteLine();
        }


        /// Задача 10: Сколько в среднем сотрудников работает в одном подразделении данного учреждения
        public static void sl(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                int n = int.Parse(reader.ReadLine());

                var phoneGroups = new SortedList<string, int>();

                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');

                    string phone = parts[2];

                    if (phoneGroups.ContainsKey(phone))
                    {
                        phoneGroups[phone]++;
                    }
                    else
                    {
                        phoneGroups[phone] = 1;
                    }
                }

                double result = 0;
                foreach (var group in phoneGroups.Values)
                {
                    result += group;
                }

                double result2 = Math.Round(result / phoneGroups.Count, 3);

                Console.WriteLine(result2);
            }

        }
    }
}
