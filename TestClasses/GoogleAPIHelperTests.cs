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
    //[TestClass]
    //public class GoogleAPIHelperTests
    //{

    //    [TestMethod]
    //    public async Task GetURLAsync_ApiKeyNotSet_ThrowsApiKeyNotSetException()
    //    {
    //        ApiData.ApiKey = "API_KEY";
    //        GoogleAPIHelper googleAPIHelper = new GoogleAPIHelper();

    //        await Assert.ThrowsExceptionAsync<ApiKeyNotSetException>(() => googleAPIHelper.GetURLAsync("Phrase"));

    //    }

    //    [TestMethod]
    //    public async Task GetURLAsync_SearchEngineIdNotSet_ThrowsSearchEngineIdNotSetException()
    //    {

    //        ApiData.ApiKey = "";
    //        ApiData.SearchEngineId = "SEARCH_ENGINE_ID";

    //        GoogleAPIHelper googleAPIHelper = new GoogleAPIHelper();

    //        await Assert.ThrowsExceptionAsync<SearchEngineIdNotSetException>(() => googleAPIHelper.GetURLAsync("Phrase"));

    //    }

    //    [TestMethod]
    //    public async Task GetURLAsync_NullSearchPhrase_ThrowsNullOrEmptySearchPhraseException()
    //    {
    //        ApiData.ApiKey = "";
    //        ApiData.SearchEngineId = "";
    //        string? searchPhrase = null;

    //        GoogleAPIHelper googleAPIHelper = new GoogleAPIHelper();

    //        await Assert.ThrowsExceptionAsync<NullOrEmptySearchPhraseException>(() => googleAPIHelper.GetURLAsync(searchPhrase));

    //    }

    //    [TestMethod]
    //    public async Task GetURLAsync_NoResultSearchPhrase_ThrowsUrlExtractionException()
    //    {
    //        ApiData.ApiKey = "";
    //        ApiData.SearchEngineId = "";
    //        string? searchPhrase = "hsbhjsdfgbsdn_vdhsdfh_feghfsidfghbia_fheahg8e_fheihfishfis_a";

    //        GoogleAPIHelper googleAPIHelper = new GoogleAPIHelper();

    //        await Assert.ThrowsExceptionAsync<UrlExtractionException>(() => googleAPIHelper.GetURLAsync(searchPhrase));

    //    }

    //}
}
