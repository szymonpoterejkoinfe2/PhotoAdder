using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.ViewModel.Helpers.Exceptions
{
    public class SaveFolderNotExistException: Exception
    {
        public SaveFolderNotExistException(string? folderPath) : base($"Save folder with path: {folderPath ?? "Unknown"} not exists!")
        {
        }
    }
}
