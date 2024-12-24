using PhotoAdder.Model.Classes;
using PhotoAdder.ViewModel.Helpers.Exceptions;
using System;
using System.CodeDom;
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
        public string? _SaveDirectory { get; set; } = AppData.OutputFolder;

        public async Task DownloadImageAsync(string? imageUrl)
        {
            if (!Directory.Exists(_SaveDirectory))
            {
                throw new SaveFolderNotExistException(_SaveDirectory);
            }

            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new NullOrEmptyImageUrlException();
            }

            using (HttpClient client = new HttpClient())
            {
                    string imageSavePath = _SaveDirectory + "\\CellPhotoToAdd.jpg";

                    // Send HTTP request to download the image
                    HttpResponseMessage imageResponse = await client.GetAsync(imageUrl);

                    // Check if the response is successful
                    if (imageResponse.IsSuccessStatusCode)
                    {
                        // Read the image content as a byte array
                        byte[] imageBytes = await imageResponse.Content.ReadAsByteArrayAsync();

                        // Save the image to a file
                        await File.WriteAllBytesAsync(imageSavePath, imageBytes);
                    }
                    else
                    {
                        throw new ImageDownloadFailureException(imageUrl);
                    }

            }
        }
    }
}
