using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class NullOrEmptySearchPhraseException : Exception
    {
        public NullOrEmptySearchPhraseException() : base("Search phrase can not be empty")
        {
        }
    }
}
