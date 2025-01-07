using PhotoAdder.ViewModel.Helpers;
using PhotoAdder.ViewModel.Helpers.Exceptions;

namespace PhotoAdder
{
    //    [TestClass]
    //    public class ExcelReaderHelperTests
    //    {
    //        string filePath = "testProgram.xlsx";


    //        #region ReadFileAsync_LimitOFF

    //        [TestMethod]
    //        public async Task ReadFileAsync_NegativeStartRowNumberLimitOff_ThrowsNegativeNumberExceptionAsync() //MethodeName_Scenario_ExpectedBehaviour
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "",
    //                WorkSheetNumber = 1,
    //                StartRow = -1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = false;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<NegativeNumberException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_NegativeWorkSheetNumberLimitOff_ThrowsNegativeNumberExceptionAsync()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "",
    //                WorkSheetNumber = -1, 
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = false;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<NegativeNumberException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_NegativePhraseCellNumberLimitOff_ThrowsNegativeNumberExceptionAsync() 
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "",
    //                WorkSheetNumber = 1,
    //                StartRow = 1, 
    //                EndRow = 1,
    //                PhraseColumnNumber = -1
    //            };

    //            bool limit = false;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<NegativeNumberException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_InvalidExcelFilePathLimitOff_ThrowsExcelFileNotExistsExceptionAsync()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "",
    //                WorkSheetNumber = 1,
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = false;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<ExcelFileNotExistsException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_NotExistingWorksheetLimitOff_ThrowsExcelWorksheetNotExistException()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = filePath,
    //                WorkSheetNumber = 100,
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = false;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<ExcelWorksheetNotExistException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_ProperlySetExcelFileLimitOff_Length15()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = filePath,
    //                WorkSheetNumber = 1,
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };
    //            bool limit = false;

    //            // Act
    //            var result = (await reader.ReadFileAsync(limit)).RowCount;

    //            //Assert
    //            Assert.AreEqual(15, result);

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_EndRowLowerThanStartRowLimitOff_Length14()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = filePath,
    //                WorkSheetNumber = 1,
    //                StartRow = 2,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };
    //            bool limit = false;

    //            // Act
    //            var result = (await reader.ReadFileAsync(limit)).RowCount;

    //            //Assert
    //            Assert.AreEqual(14, result);

    //        }


    //        #endregion


    //        #region ReadFileAsync_LimitON

    //        [TestMethod]
    //        public async Task ReadFileAsync_NegativeStartRowNumberLimitOn_ThrowsNegativeNumberExceptionAsync() //MethodeName_Scenario_ExpectedBehaviour
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "",
    //                WorkSheetNumber = -1,
    //                StartRow = -1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = true;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<NegativeNumberException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_NegativeWorkSheetNumberLimitOn_ThrowsNegativeNumberExceptionAsync()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "",
    //                WorkSheetNumber = -1,
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = true;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<NegativeNumberException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_NegativePhraseCellNumberLimitOn_ThrowsNegativeNumberExceptionAsync()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "",
    //                WorkSheetNumber = 1,
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = -1
    //            };

    //            bool limit = true;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<NegativeNumberException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_NegativEndRowNumberLimitOn_ThrowsNegativeNumberExceptionAsync()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "",
    //                WorkSheetNumber = 1,
    //                StartRow = 1,
    //                EndRow = -1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = true;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<NegativeNumberException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_InvalidExcelFilePathLimitOn_ThrowsExcelFileNotExistsExceptionAsync()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = "asddfs//dsf//",
    //                WorkSheetNumber = 1,
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = true;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<ExcelFileNotExistsException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_NotExistingWorksheetLimitOn_ThrowsExcelWorksheetNotExistException()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = filePath,
    //                WorkSheetNumber = 100,
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };

    //            bool limit = true;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<ExcelWorksheetNotExistException>(() => reader.ReadFileAsync(limit));

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_StartRowEqualEndRowLimitOn_Length1()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = filePath,
    //                WorkSheetNumber = 1,
    //                StartRow = 1,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };
    //            bool limit = true;

    //            // Act
    //            var result = (await reader.ReadFileAsync(limit)).RowCount;

    //            //Assert
    //            Assert.AreEqual(1, result);

    //        }

    //        [TestMethod]
    //        public async Task ReadFileAsync_EndRowLowerThanStartRowLimitOn_ThrowsEndRowLowerException()
    //        {
    //            //Arrange
    //            var reader = new ExcelReaderHelper
    //            {
    //                ExcelFilePath = filePath,
    //                WorkSheetNumber = 1,
    //                StartRow = 2,
    //                EndRow = 1,
    //                PhraseColumnNumber = 1
    //            };
    //            bool limit = true;

    //            // Act & Assert
    //            await Assert.ThrowsExceptionAsync<EndRowLowerException>(() => reader.ReadFileAsync(limit));

    //        }


    //        #endregion
    //    }
}