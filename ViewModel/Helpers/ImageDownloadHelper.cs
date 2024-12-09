using PhotoAdder.Model.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoAdder.ViewModel.Helpers
{
    public class ImageDownloadHelper
    {
        public string _SavePath { get; set; } = AppData.OutputFolder;

        public async Task DownloadImageAsync(string imageUrl)
        {          
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send HTTP request to download the image
                    HttpResponseMessage imageResponse = await client.GetAsync(imageUrl);

                    // Check if the response is successful
                    if (imageResponse.IsSuccessStatusCode)
                    {
                        // Read the image content as a byte array
                        byte[] imageBytes = await imageResponse.Content.ReadAsByteArrayAsync();

                        // Save the image to a file
                        await File.WriteAllBytesAsync(_SavePath, imageBytes);
                    }
                    else
                    {
                        MessageBox.Show("Failed to download image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error downloading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
