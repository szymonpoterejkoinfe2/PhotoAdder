using PhotoAdder.ViewModel.Helpers.Exceptions;
using PhotoAdder.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAdder.Model.Classes;

namespace PhotoAdder
{
    //    [TestClass]
    //    public class ExcelImageAdderHelperTests
    //    {

    //        [TestMethod]
    //        public void AddImageToExcelFile_NullFilePath_ThrowsInvalidImageFilePathException()
    //        {
    //            AppData.ExcelFile = "testProgram.xlsx";
    //            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = null};

    //            Assert.ThrowsException<InvalidImageFilePathException>(() => excelImageAdder.AddImageToExcelFile(1,1,1));
    //        }

    //        [TestMethod]
    //        public void AddImageToExcelFile_NotExistingFilePath_ThrowsInvalidImageFilePathException()
    //        {
    //            AppData.ExcelFile = "testProgram.xlsx";
    //            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "Images\\NotExisting.jpg" };

    //            Assert.ThrowsException<InvalidImageFilePathException>(() => excelImageAdder.AddImageToExcelFile(1, 1, 1));
    //        }

    //        [TestMethod]
    //        public void AddImageToExcelFile_EmptyExcelFilePath_ThrowsExcelFileNotExistsException()
    //        {
    //            AppData.ExcelFile = string.Empty;
    //            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "Images\\dog.jpg" };

    //            Assert.ThrowsException<ExcelFileNotExistsException>(() => excelImageAdder.AddImageToExcelFile(1, 1, 1));
    //        }

    //        [TestMethod]
    //        public void AddImageToExcelFile_NegativeWorksheetPage_ThrowsExcelWorksheetNotExistException()
    //        {
    //            AppData.ExcelFile = "ExcelFiles\\testProgram.xlsx";
    //            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "Images\\dog.jpg" };

    //            Assert.ThrowsException<ExcelWorksheetNotExistException>(() => excelImageAdder.AddImageToExcelFile(-1, 1, 1));
    //        }

    //        [TestMethod]
    //        public void AddImageToExcelFile_NotExistingWorksheetPage_ThrowsExcelWorksheetNotExistException()
    //        {
    //            AppData.ExcelFile = "ExcelFiles\\testProgram.xlsx";
    //            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "Images\\dog.jpg" };

    //            Assert.ThrowsException<ExcelWorksheetNotExistException>(() => excelImageAdder.AddImageToExcelFile(7, 1, 1));
    //        }

    //        [TestMethod]
    //        public void AddImageToExcelFile_InvalidImageFileExtension_ThrowsInvalidFileExtensionException()
    //        {
    //            AppData.ExcelFile = "ExcelFiles\\testProgram.xlsx";
    //            ExcelImageAdderHelper excelImageAdder = new ExcelImageAdderHelper() { _ImageFilePath = "Images\\InvalidExtension.gif" };

    //            Assert.ThrowsException<InvalidFileExtensionException>(() => excelImageAdder.AddImageToExcelFile(7, 1, 1));
    //        }


    //    }
}
