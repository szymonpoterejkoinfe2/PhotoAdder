using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class InvalidImageFilePathException : Exception
    {
        public InvalidImageFilePathException(string? filePath): base($"Invalid image file path: {filePath ?? "Unknown"}")
        {
        }
    }
}
