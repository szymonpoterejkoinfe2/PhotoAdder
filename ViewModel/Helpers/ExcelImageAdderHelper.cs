using ClosedXML.Excel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Threading;
using PhotoAdder.Model.Classes;
using PhotoAdder.ViewModel.Helpers.Exceptions;
using System.Linq;

namespace PhotoAdder.ViewModel.Helpers
{
    public class ExcelImageAdderHelper
    {
        public string? _ImageFilePath = null;
        public void AddImageToExcelFile(int worksheetPage, int worksheetRow, int worksheetImageCell)
        {

            if (File.Exists(_ImageFilePath) && _ImageFilePath != null)
            {
                if (!validExtension(_ImageFilePath))
                {
                    throw new InvalidFileExtensionException(_ImageFilePath);
                }

                if (!File.Exists(AppData.ExcelFile))
                {
                    throw new ExcelFileNotExistsException(AppData.ExcelFile);
                }


                using (var workbook = new XLWorkbook(AppData.ExcelFile))
                {
                    if (workbook.Worksheets.Count < worksheetPage || worksheetPage < 1)
                    {
                        throw new ExcelWorksheetNotExistException(worksheetPage);
                    }

                    var worksheet = workbook.Worksheet(worksheetPage);
                    var row = worksheet.Row(worksheetRow);
                    var imageCell = row.Cell(worksheetImageCell);

                    var picture = worksheet.AddPicture(_ImageFilePath).MoveTo(imageCell).WithSize(100, 100);

                    worksheet.Column(imageCell.Address.ColumnNumber).Width = 15;
                    worksheet.Row(worksheetRow).Height = 75;
                    
                    workbook.Save();

                    Thread.Sleep(200);
                }

            }
            else {
                throw new InvalidImageFilePathException(_ImageFilePath);
            }

        }

        private bool validExtension(string filePath)
        {
            string extension = Path.GetExtension(filePath)?.ToLower();
            string[] validExtensions = { ".jpg", ".jpeg", ".png"};

            return validExtensions.Contains(extension);
        }


    }
}
