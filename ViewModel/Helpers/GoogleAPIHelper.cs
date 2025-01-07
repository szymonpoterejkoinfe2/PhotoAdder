using Newtonsoft.Json.Linq;
using PhotoAdder.Model.Classes;
using PhotoAdder.ViewModel.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

// Code written by Szymon Poterejko.
// All rights reserved ®.

namespace PhotoAdder.ViewModel.Helpers
{
    public class GoogleAPIHelper
    {
        private readonly string SEARCH_ENGINE_ID = ApiData.SearchEngineId;
        private readonly string API_KEY = ApiData.ApiKey;

        public async Task<string> GetURLAsync(string? searchPhrase)
        {
            if (string.IsNullOrEmpty(API_KEY) || API_KEY == "API_KEY")
            {
                throw new ApiKeyNotSetException();
            }

            if (string.IsNullOrEmpty(SEARCH_ENGINE_ID) || SEARCH_ENGINE_ID == "SEARCH_ENGINE_ID")
            {
                throw new SearchEngineIdNotSetException();
            }
                
            if (string.IsNullOrEmpty(searchPhrase) || string.IsNullOrWhiteSpace(searchPhrase))
            {
                throw new NullOrEmptySearchPhraseException();
            }


            using (HttpClient client = new HttpClient())
            {
                string encodedQuery = Uri.EscapeDataString(searchPhrase);
                string requestUrl = $"https://www.googleapis.com/customsearch/v1?q={encodedQuery}&key={API_KEY}&cx={SEARCH_ENGINE_ID}&num=1";
                string? imageUrl = null;

                //Make HTTP request
                var response = await client.GetAsync(requestUrl);
                //response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                JObject? jsonResponse = JObject.Parse(content);

                if (jsonResponse["items"] != null && jsonResponse["items"].ToArray().Length > 0)
                {
                    foreach (var item in jsonResponse["items"])
                    {
                        // Attempt to get the first image URL (from cse_image)
                        imageUrl = item["pagemap"]?["cse_image"]?[0]?["src"]?.ToString();
                        if (string.IsNullOrEmpty(imageUrl))
                        {
                            // Fallback to cse_thumbnail if no cse_image exists
                            imageUrl = item["pagemap"]?["cse_thumbnail"]?[0]?["src"]?.ToString();
                        }
                    }

                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        throw new UrlExtractionException();
                    }
                }
                else
                {
                    throw new UrlExtractionException();
                }

                return imageUrl;
            }

        }
    }

}
