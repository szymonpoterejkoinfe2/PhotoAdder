using ClosedXML.Excel;
using PhotoAdder.Model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Code written by Szymon Poterejko.
// All rights reserved ®.

namespace PhotoAdder.ViewModel.Helpers
{
    public class ExcelReaderHelper
    {
        private string excelFilePath;
        private int workSheetNumber;
        private int startRow;
        private int endRow;
        private int phraseCellNumber;

        public int PhraseCellNumber
        {
            get { return phraseCellNumber; }
            set { phraseCellNumber = value; }
        }
        public int EndRow
        {
            get { return endRow; }
            set { endRow = value; }
        }
        public int StartRow
        {
            get { return startRow; }
            set { startRow = value; }
        }
        public int WorkSheetNumber
        {
            get { return workSheetNumber; }
            set { workSheetNumber = value; }
        }
        public string ExcelFilePath
        {
            get { return excelFilePath; }
            set { excelFilePath = value; }
        }

        public async Task<ExcelFileData> ReadFileAsync(bool limitOn)
        {
            if (limitOn)
            {
                return await ExtractDataLimitAsync(excelFilePath, workSheetNumber, phraseCellNumber, startRow, endRow);

            }
            else 
            {
                return await ExtractDataNoLimitAsync(excelFilePath, workSheetNumber, phraseCellNumber,startRow);
            }

        }

        // Reading every occupied cell in excel worksheet
        private async Task<ExcelFileData> ExtractDataNoLimitAsync(string pathToFile, int workSheetNumber, int phraseCellNumber, int startRow)
        {
            ExcelFileData excelFileData = new ExcelFileData();
            
            await Task.Run(() =>
            {
                using (var workbook = new XLWorkbook(pathToFile))
                {
                    var worksheet = workbook.Worksheet(workSheetNumber);
                    excelFileData.RowCount = 0;

                    var endRow = worksheet.RowsUsed().Count();

                    for (int rowNumber = startRow; rowNumber <= endRow; rowNumber++)
                    {
                        var row = worksheet.Row(rowNumber);

                        if (!string.IsNullOrEmpty(row.Cell(phraseCellNumber).GetString()))
                        {
                            RowData rowData = new RowData();
                            rowData.RowNumber = row.RowNumber();
                            rowData.RowPhrase = row.Cell(phraseCellNumber).GetString();

                            excelFileData.RowsData.Add(rowData);
                            excelFileData.RowCount++;
                        }
                    }
                }
            });

            return excelFileData;
        }
        // Reading every occupied cell from range specyfied by the user
        private async Task<ExcelFileData> ExtractDataLimitAsync(string pathToFile, int workSheetNumber, int phraseCellNumber, int startRow, int endRow)
        {
            ExcelFileData excelFileData = new ExcelFileData();
            await Task.Run(() =>
            {
                using (var workbook = new XLWorkbook(pathToFile))
                {
                    var worksheet = workbook.Worksheet(workSheetNumber);
                    excelFileData.RowCount = 0;

                    for (int rowNumber = startRow; rowNumber <= endRow; rowNumber++)
                    {
                        var row = worksheet.Row(rowNumber);

                        if (!string.IsNullOrEmpty(row.Cell(phraseCellNumber).GetString()))
                        {
                            RowData rowData = new RowData();
                            rowData.RowNumber = row.RowNumber();
                            rowData.RowPhrase = row.Cell(phraseCellNumber).GetString();

                            excelFileData.RowsData.Add(rowData);
                            excelFileData.RowCount++;
                        }
                    }  
                }
            });
            return excelFileData;
        }
    }
}
