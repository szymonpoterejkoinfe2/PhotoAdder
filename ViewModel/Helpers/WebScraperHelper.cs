using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PhotoAdder.ViewModel.Helpers.Exceptions;

namespace PhotoAdder.ViewModel.Helpers
{
    public class WebScraperHelper
    {
        private string googleURL = "https://www.google.com/search?tbm=isch&q=";

        public async Task<string> GetImageURLAsync(string phrase)
        {
            string? imgURL;
            string encodedQuery = Uri.EscapeDataString(phrase);
            string url = googleURL + encodedQuery;

            string htmlContent = await GetPageHTMLAsync(url);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlContent);

            string? imageDiv = document.DocumentNode.Descendants("img").FirstOrDefault(node => node.OuterHtml.Contains("DS1iW"))?.OuterHtml;

            if (imageDiv != null)
            {
                imgURL = ExtractImageURL(imageDiv);

                if (imgURL != null)
                {
                    return imgURL;
                }

                throw new UrlExtractionException();
            }
            else {
                throw new ImageForPhraseNotExistException(encodedQuery);
            }

        }

        private static async Task<string> GetPageHTMLAsync(string fullUrl)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(fullUrl);
            return response;
        }

        private string ExtractImageURL(string imgDiv)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(imgDiv);

            // Find the <img> node and extract the src attribute
            var imgNode = htmlDoc.DocumentNode.SelectSingleNode("//img");
            
            
            return imgNode.GetAttributeValue("src", "");
            
            
        }

    }
}
