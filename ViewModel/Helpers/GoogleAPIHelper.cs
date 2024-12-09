using Newtonsoft.Json.Linq;
using PhotoAdder.Model.Classes;
using System;
using System.Collections.Generic;
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
        
        public async Task<string> GetURLAsync(string searchPhrase)
        {

            return await GetFirstImageAsync(searchPhrase);

        }
        private  async Task<string> GetFirstImageAsync(string query)
        {
          
            using (HttpClient client = new HttpClient())
            {
                string encodedQuery = Uri.EscapeDataString(query);
                string requestUrl = $"https://www.googleapis.com/customsearch/v1?q={encodedQuery}&key={API_KEY}&cx={SEARCH_ENGINE_ID}&num=1";
                string? imageUrl = null;

                try
                {
                    // Wykonaj żądanie HTTP
                    var response = await client.GetAsync(requestUrl);
                    //response.EnsureSuccessStatusCode();

                    string content = await response.Content.ReadAsStringAsync();
                    JObject? jsonResponse = JObject.Parse(content);

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
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd podczas pobierania obrazu dla frazy '{query}': {ex.Message}");
                    MessageBox.Show($"Image not found:'{query}', {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return imageUrl;
            }


            //return imageUrls[random.Next(0, 3)];


        }
    }



}
