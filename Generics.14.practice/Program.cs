using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics._14.practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // текст 
            string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме," +
                " Который построил Джек. А это веселая птица-синица, Которая часто ворует пшеницу, Которая в темном " +
                "чулане хранится В доме, Который построил Джек.";
            // список Dictionary 
            Dictionary<string, int> wordStatistics = CountWordOccurrences(text);

            DisplayStatistics(wordStatistics);
        }

        static Dictionary<string, int> CountWordOccurrences(string text)
        {
            // создаем массив слов без лишних символов 
            string[] words = text.Split(new char[] { ' ', '.', ',', '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            // создаем Dictionary где key-слова а где value-частота этих слов в тексте.
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            // с помощью метода ContainsKey проверяем есть ли это слово
            // в Dictionary если есть то увеличивем value на один если нет то присваеваем 1.
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            return wordCount;
        }
        /// <summary>
        /// Метод для вывода значение как таблицы где слева слова а где справа их частота этих слов в тексте.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="statistics"></param>
        static void DisplayStatistics<TKey, TValue>(Dictionary<TKey, TValue> statistics)
        {
            Console.WriteLine("Слово\t\tЧастота");

            foreach (var entry in statistics)
            {
                Console.WriteLine($"{entry.Key}\t\t{entry.Value}");
            }
        }
    }
}
