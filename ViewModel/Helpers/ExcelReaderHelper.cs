using ClosedXML.Excel;
using PhotoAdder.Model.Classes;
using PhotoAdder.ViewModel.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
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

        public int PhraseColumnNumber
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

            if (CheckForNegativeNumbers(workSheetNumber, phraseCellNumber, startRow) != null)
            {
                throw new NegativeNumberException(CheckForNegativeNumbers(workSheetNumber, phraseCellNumber, startRow));
            }

            if (!File.Exists(pathToFile))
            {
                throw new ExcelFileNotExistsException(pathToFile);
            }
            await Task.Run(() =>
                {
                    using (var workbook = new XLWorkbook(pathToFile))
                    {
                        if (WorksheetExists(workbook.Worksheets.Count, workSheetNumber))
                        {
                            var worksheet = workbook.Worksheet(workSheetNumber);

                            excelFileData = GetAllRows(worksheet, startRow, worksheet.RowsUsed().Count());
                        }
                        else 
                        {
                            throw new ExcelWorksheetNotExistException(workSheetNumber);
                        }

                    }
                });
            
            return excelFileData;
        }
        // Reading every occupied cell from range specyfied by the user
        private async Task<ExcelFileData> ExtractDataLimitAsync(string pathToFile, int workSheetNumber, int phraseCellNumber, int startRow, int endRow)
        {
            ExcelFileData excelFileData = new ExcelFileData();

            if (CheckForNegativeNumbers(workSheetNumber, phraseCellNumber, startRow, endRow) != null)
            {
                throw new NegativeNumberException(CheckForNegativeNumbers(workSheetNumber, phraseCellNumber, startRow, endRow));
            }

            if (!File.Exists(pathToFile) )
            {
                throw new ExcelFileNotExistsException(pathToFile);
            }

            if (endRow < startRow)
            {
                throw new EndRowLowerException();
            }

            await Task.Run(() =>
                {
                    using (var workbook = new XLWorkbook(pathToFile))
                    {
                        if (WorksheetExists(workbook.Worksheets.Count, workSheetNumber))
                        {
                            var worksheet = workbook.Worksheet(workSheetNumber);
                            
                            excelFileData = GetAllRows(worksheet, startRow, endRow);
                        }
                        else { 
                            throw new ExcelWorksheetNotExistException(workSheetNumber);
                        }
                    }
                });
            
            return excelFileData;
        }

        private ExcelFileData GetAllRows(IXLWorksheet worksheet, int startRow, int endRow) {

            ExcelFileData excelFileData = new ExcelFileData();

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

            return excelFileData;
        }

        private int? CheckForNegativeNumbers(int workSheetNumber, int phraseCellNumber, int startRow)
        {
            if (workSheetNumber < 0)
            {
                return workSheetNumber;
            }
            else if (phraseCellNumber < 0)
            {
                return phraseCellNumber;
            }
            else if (startRow < 0)
            {
                return startRow;
            }


            return null;
        }

        private int? CheckForNegativeNumbers(int workSheetNumber, int phraseCellNumber, int startRow, int endRow)
        {
            if (workSheetNumber < 0)
            {
                return workSheetNumber;
            }
            else if (phraseCellNumber < 0)
            {
                return phraseCellNumber;
            }
            else if (startRow < 0)
            {
                return startRow;
            }
            else if (endRow < 0)
            {
                return endRow;
            }

            return null;
        }

        private bool WorksheetExists(int worksheetsCount, int worksheetNumber)
        {
            return (worksheetNumber <= worksheetsCount);
        }
    }
}
