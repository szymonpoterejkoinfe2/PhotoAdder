using PhotoAdder.ViewModel.Helpers.Exceptions;
using PhotoAdder.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAdder.Model.Classes;

namespace PhotoAdder.UnitTests
{
    [TestClass]
    public class ExcelImageAdderHelperTests
    {

        [TestMethod]
        public void AddImageToExcelFile_NullFilePath_ThrowsInvalidImageFilePathException()
        {
            AppData.ExcelFile = "H:\\Git\\PhotoAdder.UnitTests\\ExcelFiles\\testProgram.xlsx";
            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = null};
            
            Assert.ThrowsException<InvalidImageFilePathException>(() => excelImageAdder.AddImageToExcelFile(1,1,1));
        }

        [TestMethod]
        public void AddImageToExcelFile_NotExistingFilePath_ThrowsInvalidImageFilePathException()
        {
            AppData.ExcelFile = "H:\\Git\\PhotoAdder.UnitTests\\ExcelFiles\\testProgram.xlsx";
            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "H:\\Git\\PhotoAdder.UnitTests\\Images\\NotExisting.jpg" };

            Assert.ThrowsException<InvalidImageFilePathException>(() => excelImageAdder.AddImageToExcelFile(1, 1, 1));
        }

        [TestMethod]
        public void AddImageToExcelFile_EmptyExcelFilePath_ThrowsExcelFileNotExistsException()
        {
            AppData.ExcelFile = string.Empty;
            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "H:\\Git\\PhotoAdder.UnitTests\\Images\\dog.jpg" };

            Assert.ThrowsException<ExcelFileNotExistsException>(() => excelImageAdder.AddImageToExcelFile(1, 1, 1));
        }

        [TestMethod]
        public void AddImageToExcelFile_NegativeWorksheetPage_ThrowsExcelWorksheetNotExistException()
        {
            AppData.ExcelFile = "H:\\Git\\PhotoAdder.UnitTests\\ExcelFiles\\testProgram.xlsx";
            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "H:\\Git\\PhotoAdder.UnitTests\\Images\\dog.jpg" };

            Assert.ThrowsException<ExcelWorksheetNotExistException>(() => excelImageAdder.AddImageToExcelFile(-1, 1, 1));
        }

        [TestMethod]
        public void AddImageToExcelFile_NotExistingWorksheetPage_ThrowsExcelWorksheetNotExistException()
        {
            AppData.ExcelFile = "H:\\Git\\PhotoAdder.UnitTests\\ExcelFiles\\testProgram.xlsx";
            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "H:\\Git\\PhotoAdder.UnitTests\\Images\\dog.jpg" };

            Assert.ThrowsException<ExcelWorksheetNotExistException>(() => excelImageAdder.AddImageToExcelFile(7, 1, 1));
        }

        [TestMethod]
        public void AddImageToExcelFile_InvalidImageFileExtension_ThrowsInvalidFileExtensionException()
        {
            AppData.ExcelFile = "H:\\Git\\PhotoAdder.UnitTests\\ExcelFiles\\testProgram.xlsx";
            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "H:\\Git\\PhotoAdder.UnitTests\\Images\\InvalidExtension.gif" };

            Assert.ThrowsException<InvalidFileExtensionException>(() => excelImageAdder.AddImageToExcelFile(7, 1, 1));
        }


    }
}
