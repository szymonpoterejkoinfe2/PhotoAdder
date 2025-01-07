//using DocumentFormat.OpenXml.Math;
//using PhotoAdder.ViewModel.Helpers;
//using PhotoAdder.ViewModel.Helpers.Exceptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PhotoAdder.UnitTests
//{
//    [TestClass]
//    public class WebScraperHelperTests
//    {

//        [TestMethod]
//        public async Task GetImageURLAsync_NotExistingImage_ThrowsImageForPhraseNotExistException()
//        {
//            string searchPhrase = "1ZXCVBNMSAFSD234567890-12345678901234567890-";
//            var webScraper = new WebScraperHelper();

//            await Assert.ThrowsExceptionAsync<ImageForPhraseNotExistException>(() => webScraper.GetImageURLAsync(searchPhrase));
//        }

//        [TestMethod]
//        public async Task GetImageURLAsync_CatPhrase_ReturnsTrueIfProperResult()
//        {
//            string searchPhrase = "cat";
//            var webScraper = new WebScraperHelper();

//            var result = await webScraper.GetImageURLAsync(searchPhrase);

//            Assert.IsTrue(!string.IsNullOrEmpty(result))
//;       }

//        [TestMethod]
//        public async Task GetImageURLAsync_SpacePhrase_ThrowsImageForPhraseNotExistException()
//        { 
//            string searchPhrase = " ";
//            var webScraper = new WebScraperHelper();
//            await Assert.ThrowsExceptionAsync<ImageForPhraseNotExistException>(() => webScraper.GetImageURLAsync(searchPhrase));
            
//        }



//    } 
//}
