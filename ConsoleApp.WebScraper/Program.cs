using HtmlAgilityPack;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp.API
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos");

            var responseBody = await response.Content.ReadAsStringAsync();

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(responseBody);

            var links = htmlDoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Contains("offer_primary_info")).ToList();

            var children = links.Select(l => l.FirstChild.FirstChild.InnerHtml);

        }
    }
}
