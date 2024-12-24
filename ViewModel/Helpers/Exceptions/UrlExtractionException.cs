using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class UrlExtractionException : Exception
    {
        public UrlExtractionException() : base($"Image element to extract not found!")
        {
        }
    }
}
