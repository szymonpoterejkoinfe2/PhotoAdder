using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class ExcelFileNotExistsException : Exception
    {
        public ExcelFileNotExistsException()
        {
        }

        string FilePath { get; set; }
        public ExcelFileNotExistsException(string filePath) : base($"File with path:{filePath} does not exists!")
        {
            FilePath = filePath;
        }
    }
}
