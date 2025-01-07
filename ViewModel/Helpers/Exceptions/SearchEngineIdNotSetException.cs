using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class SearchEngineIdNotSetException : Exception
    {
        public SearchEngineIdNotSetException() : base("SEARCH_ENGINE_ID value not set in ApiData.txt file!")
        {
        }
    }
}
