using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task_13._1
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
            string[] words = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            //Время вставки в List<string>
            List<string> list = new List<string>();
            Stopwatch stopwatchList = Stopwatch.StartNew();
            foreach (var word in words)
            {
                list.Add(word);
            }
            stopwatchList.Stop();
            long timestamp = Stopwatch.GetTimestamp();
            Console.WriteLine($"Текущий Timestamp: {timestamp}");
            Console.WriteLine($"List<T> производительность вставки в милисекундах: {stopwatchList.ElapsedMilliseconds} ms");
            var result_1 = stopwatchList.ElapsedMilliseconds;
            // Время вставки в LinkedList<string>
            LinkedList<string> linkedList = new LinkedList<string>();
            Stopwatch stopwatchLinkedList = Stopwatch.StartNew();
            foreach (var word in words)
            {
                linkedList.AddLast(word);
            }
            stopwatchLinkedList.Stop();
            long timestamplinkedList = Stopwatch.GetTimestamp();
            Console.WriteLine($"Текущий Timestamp: {timestamplinkedList}");
            Console.WriteLine($"LinkedList<T> производительность вставки в милисекундах: {stopwatchLinkedList.ElapsedMilliseconds} ms");
            var result_2 = stopwatchLinkedList.ElapsedMilliseconds;

            if (result_2 > result_1)
            {

                double difTime = result_2 / result_1;
                Console.WriteLine($"LinkedList<T> быстрее в : {difTime} раз(а), для болеее точных измерений необходимо уменьшить единицы измерения, например ноносекунды.");
            }
            else
            {
                double difTime = result_1 / result_2;
                Console.WriteLine($"List<T> быстрее в : {difTime} раз(а), для болеее точных измерений необходимо уменьшить единицы измерения, например ноносекунды.");
            }
            Console.ReadKey();  
            }
    }
}
