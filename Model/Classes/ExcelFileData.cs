using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder.Model.Classes
{
    public class ExcelFileData
    {
        public int RowCount { get; set; }
        public List<RowData> RowsData { get; set; } = new List<RowData>();
    }
}
