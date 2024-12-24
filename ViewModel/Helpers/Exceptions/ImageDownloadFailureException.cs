using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class ImageDownloadFailureException : Exception
    {
        public ImageDownloadFailureException(string? imageUrl) : base($"Failed to download: {imageUrl} image!")
        {
        }
    }
}
