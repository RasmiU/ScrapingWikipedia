using HtmlAgilityPack;
using CsvHelper;
using ScrapySharp.Extensions;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Formats.Asn1;
using System.Text;

namespace ScrapingWikipedia
{
    class Program
    {
        static void Main(string[] args)
        {
            int Count = 0;
            var HtmlURL = "https://en.wikipedia.org/wiki/Computer_science";
            HtmlWeb Web = new HtmlWeb();
            var HtmlDoc = Web.Load(HtmlURL);

            var Links = HtmlDoc.DocumentNode.SelectNodes("//div[@id='mw-content-text']//div[@class='mw-parser-output']//p[2]//a");
            
            var RefLinks = new List<string>();
            foreach(var Link in Links)
            {
                Count++;
                RefLinks.Add(Link.Attributes["href"].Value);
                Console.WriteLine(Link.Attributes["href"].Value);
            }
            Console.WriteLine("Count : {0}", Count);

            StringBuilder sb = new StringBuilder();
            foreach(var RefLink in RefLinks)
            {
                sb.AppendLine(RefLink);
            }

            File.WriteAllText("ReferenceLinks.txt", sb.ToString());
        }
    }
}
