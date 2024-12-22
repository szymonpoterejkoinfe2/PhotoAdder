using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class ExcelWorksheetNotExistException : Exception
    {
        public ExcelWorksheetNotExistException() { }

        int WorksheetNumber { get; set; }
        public ExcelWorksheetNotExistException(int worksheetNumber) : base($"Worksheet with number: {worksheetNumber} does not exist. Please evaluate Excel file!")
        {
            WorksheetNumber = worksheetNumber;
        }
    }
}
