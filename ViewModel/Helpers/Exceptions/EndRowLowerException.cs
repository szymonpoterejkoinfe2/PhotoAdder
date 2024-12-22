using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class EndRowLowerException : Exception
    {

        public EndRowLowerException() : base("End row can not be lower than start row!")
        {
        }
    }
}
