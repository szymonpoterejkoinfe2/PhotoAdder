using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class InvalidFileExtensionException : Exception
    {
        public InvalidFileExtensionException(string? filePath): base($"Unsupported file extension for file path: {filePath ?? "Unknown"}")
        {

        }
        

    }
}
