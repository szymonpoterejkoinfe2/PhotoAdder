using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class ApiKeyNotSetException : Exception
    {
        public ApiKeyNotSetException() : base("API_KEY value not set in ApiData.txt file!")
        {
        }
    }
}
