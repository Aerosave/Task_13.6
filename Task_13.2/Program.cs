using System;
using System.IO;
using System.Collections.Generic;


namespace Task_13._2
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите путь к файлу:");
            string filePath = Console.ReadLine().Trim('"');

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден. Проверьте правильность пути и повторите попытку.");
                return;
            }

            string text = File.ReadAllText(filePath);

            // Удаление знаков пунктуации
            text = RemovePunctuation(text);

            // Разделение текста на слова
            string[] words = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Создание словаря для подсчета частоты слов
            Dictionary<string, int> chasotaSlov = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (chasotaSlov.ContainsKey(word))
                {
                    chasotaSlov[word]++;
                }
                else
                {
                    chasotaSlov[word] = 1;
                }
            }

            // Сортировка словаря по убыванию частоты и выбор топ-10
            List<KeyValuePair<string, int>> sortedWords = SortByFrequency(chasotaSlov);

            // Вывод топ-10 слов
            Console.WriteLine("Топ-10 слов по частоте:");
            for (int i = 0; i < Math.Min(10, sortedWords.Count); i++)
            {
                Console.WriteLine($"{sortedWords[i].Key}: {sortedWords[i].Value} раз");
            }
        }

        //Метод ремува точечек
        static string RemovePunctuation(string text)
        {
            char[] result = new char[text.Length];
            int index = 0;

            foreach (char c in text)
            {
                if (!char.IsPunctuation(c))
                {
                    result[index++] = c;
                }
            }

            return new string(result, 0, index);
        }
        // Сортировка пузырьком
        static List<KeyValuePair<string, int>> SortByFrequency(Dictionary<string, int> chasotaSlov)
        {
            List<KeyValuePair<string, int>> wordList = new List<KeyValuePair<string, int>>(chasotaSlov);

            for (int i = 0; i < wordList.Count - 1; i++)
            {
                for (int j = i + 1; j < wordList.Count; j++)
                {
                    if (wordList[i].Value < wordList[j].Value)
                    {
                        var temp = wordList[i];
                        wordList[i] = wordList[j];
                        wordList[j] = temp;
                    }
                }
            }

            return wordList;
        }
    }
}