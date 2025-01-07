using PhotoAdder.Model.Classes;
using PhotoAdder.ViewModel.Helpers.Exceptions;
using PhotoAdder.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAdder
{
    //[TestClass]
    //public class ImageDownloadHelperTests
    //{
    //    string saveFolderPath = "Images\\";

    //    [TestMethod]
    //    public async Task DownloadImageAsync_NotExistingSaveDirectory_ThrowsSaveFolderNotExistException()
    //    {
    //        ImageDownloadHelper imageDownload = new ImageDownloadHelper() { _SaveDirectory = string.Empty };
    //        string imageUrl = "";

    //        await Assert.ThrowsExceptionAsync<SaveFolderNotExistException>(() => imageDownload.DownloadImageAsync(imageUrl));
    //    }

    //    [TestMethod]
    //    public async Task DownloadImageAsync_EmptyImageUrl_ThrowsNullOrEmptyImageUrlException()
    //    {
    //        ImageDownloadHelper imageDownload = new ImageDownloadHelper() { _SaveDirectory = saveFolderPath };
    //        string imageUrl = string.Empty;

    //        await Assert.ThrowsExceptionAsync<NullOrEmptyImageUrlException>(() => imageDownload.DownloadImageAsync(imageUrl));
    //    }

    //    [TestMethod]
    //    public async Task DownloadImageAsync_NullImageUrl_ThrowsNullOrEmptyImageUrlException()
    //    {
    //        ImageDownloadHelper imageDownload = new ImageDownloadHelper() { _SaveDirectory = saveFolderPath };
    //        string? imageUrl = null;

    //        await Assert.ThrowsExceptionAsync<NullOrEmptyImageUrlException>(() => imageDownload.DownloadImageAsync(imageUrl));
    //    }

    //    [TestMethod]
    //    public async Task DownloadImageAsync_InvalidImageUrl_ThrowsImageDownloadFailureException()
    //    {
    //        ImageDownloadHelper imageDownload = new ImageDownloadHelper() { _SaveDirectory = saveFolderPath };
    //        string? imageUrl = "https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719";

    //        await Assert.ThrowsExceptionAsync<ImageDownloadFailureException>(() => imageDownload.DownloadImageAsync(imageUrl));
    //    }

    //    [TestMethod]
    //    public async Task DownloadImageAsync_ValidImageUrl_ReturnsTrue()
    //    {
    //        ImageDownloadHelper imageDownload = new ImageDownloadHelper() { _SaveDirectory = saveFolderPath };
    //        string? imageUrl = "https://cdn.pixabay.com/photo/2023/08/18/15/02/dog-8198719_1280.jpg";
    //        string imagePath = saveFolderPath + "\\CellPhotoToAdd.jpg";

    //        await imageDownload.DownloadImageAsync(imageUrl);

    //        Assert.IsTrue(File.Exists(imagePath));
    //    }

    //}
}
