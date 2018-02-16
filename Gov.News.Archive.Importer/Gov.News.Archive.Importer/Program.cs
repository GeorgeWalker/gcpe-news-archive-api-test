using Gov.News.Archive.Api.Models;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using Gov.News.Archive.Api;

namespace Gov.News.Archive.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiServiceLocation = "http://localhost:9010";
            string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2NzYzOTg4MTcsImlzcyI6Imh0dHA6Ly9nY3BlIiwiYXVkIjoiaHR0cDovL2djcGUifQ.U3wZHowTyNg7XaHFyEjH4Uoq5Ezo8uRxJjU9aUajAbQ";
            var newsArchiveApiClient = new Client(new Uri(apiServiceLocation));
            newsArchiveApiClient.HttpClient.DefaultRequestHeaders.Clear();
            newsArchiveApiClient.HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            

            string sourceDir = "C:\\Projects\\GCPE\\News Archive files\\Web Site - Releases\\news_releases_2017-2021";

            // Create a Collection for the directory.

            Gov.News.Archive.Api.Models.Collection c = new Api.Models.Collection();
            c.StartDate = DateTime.Parse("2017-07-18");
            c.EndDate = null;
            c.Name = "July 18, 2017 to current date";

            // spin through all of the htm files in the directory.
            string[] paths = Directory.GetFiles(sourceDir, "*.htm", SearchOption.TopDirectoryOnly);

            foreach (string path in paths)
            {
                string filename = Path.GetFileName(path);
                Console.Out.WriteLine(filename);

                var doc = new HtmlDocument();
                doc.Load(path);

                // get some meta data.

                var node = doc.DocumentNode;

                var title = node.SelectSingleNode("//title")
                    .InnerText;
                string ministry = "Unknown";
                
                var tempMinistry = node.SelectSingleNode("//td[@style='width: 70%; text-align: right; vertical-align: top;']");
                    if (tempMinistry != null)
                {
                    ministry = tempMinistry.InnerText;
                }

                DateTime dt = DateTime.Now;

                var tempDate = node.SelectSingleNode("//meta[@name='dc.date']");
                if (tempDate != null)
                {
                    dt = DateTime.Parse (tempDate.Attributes["content"].Value);
                }


                Console.Out.WriteLine("title=" + title);
                Console.Out.WriteLine("ministry=" + ministry);
                Console.Out.WriteLine("datePublished" + dt.ToShortDateString());


                Api.Models.Archive payload = new Api.Models.Archive();

                payload.Collection = c;
                payload.DateReleased =  dt ;
                payload.MinistryText = ministry;
                payload.Title = title;
                
                
                newsArchiveApiClient.ApiArchivesPost(payload);

            }

            Console.ReadLine();

        }
    }
}
