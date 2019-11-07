using ServiceParser.SearchServices.Yandex;
using ServiceParser.SearchEngine;
using System;

namespace ServiceParser
{
    public class Program
    {
        public static void Main()
        {
            var searchEngine = new Engine();

            var yandex = new Yandex();

            searchEngine.AddSearchService(yandex);
            var snippets = searchEngine.Start("qwerty");

            foreach (var s in snippets)
            {
                Console.WriteLine(s.Title + "\n" + s.Url + "\n");
            }
        }
    }
}
