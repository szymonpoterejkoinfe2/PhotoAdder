using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class NullOrEmptyImageUrlException : Exception
    {
        public NullOrEmptyImageUrlException() : base("Empty image URL")
        {
        }
    }
}
