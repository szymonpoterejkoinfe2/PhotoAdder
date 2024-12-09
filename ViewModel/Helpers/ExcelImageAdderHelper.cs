using ClosedXML.Excel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Threading;
using PhotoAdder.Model.Classes;

namespace PhotoAdder.ViewModel.Helpers
{
    public class ExcelImageAdderHelper
    {
        public string? _ImageFilePath = null;
        public void AddImageToExcelFile(int worksheetPage, int worksheetRow, int worksheetImageCell)
        {
            if (File.Exists(_ImageFilePath))
            {
                using (var workbook = new XLWorkbook(AppData.ExcelFile))
                {
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
                System.Windows.Forms.MessageBox.Show($"Image not found:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
