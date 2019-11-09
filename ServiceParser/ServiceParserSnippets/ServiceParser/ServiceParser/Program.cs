
using AngleSharp.Html.Parser;
using PuppeteerSharp;
using ServiceParser.SearchServices.Google;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceParser
{
    public class Program
    {
        public async static Task Main()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            // Create an instance of the browser and configure launch options
            Browser browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });

            // Create a new page and go to Bing Maps
            Page page = await browser.NewPageAsync();
            await page.GoToAsync(@"https://www.google.com/search?q=qwerty");

            var html = await page.GetContentAsync();


            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);

            var snippetsContainers = document.QuerySelectorAll(".g").Take(20);

            foreach (var snippet in snippetsContainers)
            {
                if (snippet != null)
                {
                    var title = snippet.QuerySelector(".LC20lb");

                    if (title != null)
                    {
                        var s = snippet.QuerySelector(".r>a").GetAttribute("href");

                        Console.WriteLine(title.TextContent + "\t" + s);
                    }

                }
            }

        }
    }
}
