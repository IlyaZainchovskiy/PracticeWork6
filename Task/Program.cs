using System;
using System.Collections;
using System.Collections.Generic;

namespace Task
{
    public class Document : IComparable<Document>, IComparer<Document>
    {
        public string Title { get; set; }
        public int PageCount { get; set; }

        public int SecrecyLevel { get; set; }

        public Document(string title, int pageCount, int secrecyLevel)
        {
            Title = title;
            PageCount = pageCount;
            SecrecyLevel = secrecyLevel;
        }

        public int CompareTo(Document? other)
        {

            if (other == null) return 1;
            return this.PageCount.CompareTo(other.PageCount);
        }

        public int Compare(Document? x, Document? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int pageCompare = x.PageCount.CompareTo(y.PageCount);

            if (pageCompare != 0)
            {
                return pageCompare;
            }
            else
            {
                return x.SecrecyLevel.CompareTo(y.SecrecyLevel);
            }
        }

        public override string ToString()
        {
            return $"Документ: '{Title}', Сторінок: {PageCount}, Рівень: {SecrecyLevel}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Document[] documents = new Document[]
            {
                new Document("Річний звіт", 120, 3),
                new Document("Маркетинговий план", 50, 4),
                new Document("Секретний проект X", 15, 1),
                new Document("Інструкція користувача", 50, 4),
                new Document("План евакуації", 50, 2),
                new Document("Внутрішній наказ", 2, 3)
            };

            Console.WriteLine("--- Початковий список документів ---");
            PrintDocuments(documents);
            Array.Sort(documents);

            Console.WriteLine("\n--- Список, впорядкований за кількістю сторінок ---");
            PrintDocuments(documents);

            Document comparer = new Document("", 0, 0);

            Array.Sort(documents, comparer);

            Console.WriteLine("\n--- Список, впорядкований за сторінками ---");
            PrintDocuments(documents);
        }

        public static void PrintDocuments(IEnumerable<Document> docs)
        {
            foreach (var doc in docs)
            {
                Console.WriteLine(doc);
            }
        }
    }
}