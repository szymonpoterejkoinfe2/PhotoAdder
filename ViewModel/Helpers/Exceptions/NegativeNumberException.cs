using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() { }

        int? NegativeNumber { get; set; }
        public NegativeNumberException(int? number) : base($"Error occured while trying to operate on negative number:{number}! Please enter valid positive integer number") { NegativeNumber = number; }
    }
}
