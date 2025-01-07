using DocumentFormat.OpenXml.Wordprocessing;
using PhotoAdder.Model.Classes;
using PhotoAdder.View.MessageBox;
using PhotoAdder.ViewModel.Commands;
using PhotoAdder.ViewModel.Helpers;
using PhotoAdder.ViewModel.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;


// Code written by Szymon Poterejko.
// All rights reserved ®.

namespace PhotoAdder.ViewModel.VMs
{
    public class PhotoAdderVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isFolderSelected = false;
        private bool isExcelFileSelected = false;

        #region Commands
        // Commands
        public ExitApplicationCommand ExitApplicationCommand { set; get; }
        public SelectSaveFolderCommand SelectSaveFolderCommand { get; set; }
        public SelectExcelFileCommand SelectExcelFileCommand { get; set; }
        public MinimizeWindowCommand MinimizeWindowCommand { get; set; }
        public ExecuteCommand ExecuteCommand { get; set; }
        #endregion

        #region Binding properties
        //Private 
        private string saveFolderPath;
        private string excelFilePath;
        private bool limitRequests;
        private int rowBegin;
        private int rowEnd;
        private int progressValue;
        private int phraseColumnNumber;
        private int workSheet;
        private int imageCell;
        private int maxProgressValue;
        private bool buttonEnable;
        private bool progressBarVis;
        private bool apiExtractor;
        private bool limitVisible;

        //Public
        public string SaveFolderPath
        {
            get { return saveFolderPath; }
            set 
            {
                saveFolderPath = value;
                OnPropertyChanged(nameof(SaveFolderPath));
            }
        }
        public string ExcelFilePath
        {
            get { return excelFilePath; }
            set
            {
                excelFilePath = value;
                OnPropertyChanged(nameof(ExcelFilePath));
            }
        }
        public bool LimitRequests
        {
            get { return limitRequests; }
            set { 
                limitRequests = value;
                OnPropertyChanged(nameof(LimitRequests));
            }
        }
        public int RowBegin
        {
            get { return rowBegin; }
            set 
            {
                rowBegin = value;
                if (rowBegin < 0)
                {
                    rowBegin = 1;
                }
                OnPropertyChanged(nameof(RowBegin));
            }
        }
        public int RowEnd
        {
            get { return rowEnd; }
            set 
            { 
                rowEnd = value;
                OnPropertyChanged( nameof(RowEnd));
            }
        }
        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                progressValue = value;
                OnPropertyChanged(nameof(progressValue));
            }
        }
        public int PhraseCell
        {
            get { return phraseColumnNumber; }
            set
            {
                phraseColumnNumber = value;
                OnPropertyChanged(nameof(PhraseCell));
            }
        }
        public int WorkSheet
        {
            get { return workSheet; }
            set
            {
                workSheet = value;
                OnPropertyChanged(nameof(WorkSheet));
            }
        }
        public int ImageCell
        {
            get { return imageCell; }
            set { 
                imageCell = value;
                OnPropertyChanged(nameof(ImageCell));
            }
        }
        public int MaxProgressValue
        {
            get { return maxProgressValue; }
            set
            {
                maxProgressValue = value;
                OnPropertyChanged(nameof(MaxProgressValue));
            }
        }
        public bool ButtonEnable
        {
            get { return buttonEnable; }
            set
            {
                buttonEnable = value;
                OnPropertyChanged(nameof(ButtonEnable));
            }
        }
        public bool ProgressBarVis
        {
            get { return progressBarVis; }
            set
            {
                progressBarVis = value;
                OnPropertyChanged(nameof(ProgressBarVis));
            }
        }
        public bool ApiExtractor
        {
            get { return apiExtractor; }
            set { 
                apiExtractor = value;
                OnPropertyChanged(nameof(ApiExtractor));
                SetLimitRequests(apiExtractor);
            }
        }
        #endregion

        private ExcelFileData excelFileData = new ExcelFileData();
        private List<string> imageURLsToDownload = new List<string>();
        private MessageBoxDisplayer messageBoxDisplayer = new MessageBoxDisplayer();


        public PhotoAdderVM()
        {
            ExitApplicationCommand = new ExitApplicationCommand(this);
            SelectSaveFolderCommand = new SelectSaveFolderCommand(this);
            SelectExcelFileCommand = new SelectExcelFileCommand(this);
            MinimizeWindowCommand = new MinimizeWindowCommand(this);
            ExecuteCommand = new ExecuteCommand(this);

            SaveFolderPath = "Select save folder";
            ExcelFilePath = "Select excel file";
            LimitRequests = true;
            RowBegin = 1;
            RowEnd = 100;
            ProgressValue = 0;
            WorkSheet = 1;
            ImageCell = 1;
            PhraseCell = 3;
            MaxProgressValue = 100;
            ButtonEnable = true;
            ProgressBarVis = false;
            ApiExtractor = true;

        }

        #region Buttons_Conrtol_Function
        internal void ExitAPP()
        { 
            System.Windows.Application.Current.Shutdown();
        }
        internal void SelectSaveFolder()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder";
                dialog.RootFolder = System.Environment.SpecialFolder.Desktop;

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SaveFolderPath = dialog.SelectedPath;
                    AppData.OutputFolder = SaveFolderPath;
                    isFolderSelected = true;
                }
                else {
                    isFolderSelected = false;
                }
            }
        }
        internal void SelectExcelFile()
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Excel File";
                openFileDialog.Filter = "Excel Files (*.xlsx;*.xls;*.xlsm)|*.xlsx;*.xls;*.xlsm|All Files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ExcelFilePath = openFileDialog.FileName;
                    AppData.ExcelFile = ExcelFilePath;
                    isExcelFileSelected = true;
                }
                else {
                    isExcelFileSelected = false;
                }
                
            }
        }
        internal void MinimizeWindow()
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        internal async void Execute()
        {
            if (isExcelFileSelected && isExcelFileSelected)
            {
                ButtonEnable = false;
                ProgressBarVis = true;


                ExcelReaderHelper excelReaderHelper = new ExcelReaderHelper
                {
                    ExcelFilePath = AppData.ExcelFile, // Path to the Excel file  
                    StartRow = rowBegin, // Row number from which we start working, for example, 1, 2, 3...  
                    EndRow = rowEnd,    // Row number where we will perform the last operation.  
                    WorkSheetNumber = workSheet, // Sheet number from which we retrieve the data  
                    PhraseColumnNumber = phraseColumnNumber // Column number that contains the phrases to retrieve
                };

                try
                {
                    excelFileData = await excelReaderHelper.ReadFileAsync(limitRequests); //Pobranie wszystkich faraz z pliku excel
                }
                catch (NegativeNumberException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("Negative number error", ex.Message);
                }
                catch (ExcelWorksheetNotExistException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("Worksheet not exist", ex.Message);
                }
                catch (ExcelFileNotExistsException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("Excel file not exist", ex.Message);
                }


                if (excelFileData.RowCount > 0)
                {
                    MaxProgressValue = excelFileData.RowCount;

                    if (ApiExtractor)
                    {
                        imageURLsToDownload = await GetImageURLsAsyncAPI(excelFileData.RowsData);
                    }
                    else {

                        imageURLsToDownload = await GetImageURLsAsyncScraper(excelFileData.RowsData);
                    }
                }

                if (imageURLsToDownload.Count > 0)
                {
                    await AddImagesToExcel(excelFileData.RowsData, imageURLsToDownload);
                }

                messageBoxDisplayer.ShowInformationBox("Information","Done");

                ButtonEnable = true;
                ProgressBarVis = false;

            }
            else if (!isFolderSelected)
            {
                messageBoxDisplayer.ShowErrorBox("Folder not selected", "Please select location of image save folder!");
            }
            else if(!isExcelFileSelected) 
            {
                messageBoxDisplayer.ShowErrorBox("Folder not selected", "Please select location of Excel file!");
            }

            ProgressValue = 0;
        }
        #endregion

        #region URL_Get_Functions
        // Geting images URLs using Google custom search API
        private async Task<List<string>> GetImageURLsAsyncAPI(List<RowData> excelFileData)
        {
            List<string> imageURLs = new List<string>();
            GoogleAPIHelper googleAPIHelper = new GoogleAPIHelper();

            // Get URL for every cell phrase 
            foreach (RowData excelRow in excelFileData)
            {
                try
                {
                    string url = await googleAPIHelper.GetURLAsync(excelRow.RowPhrase);
                    imageURLs.Add(url);
                }
                catch(ApiKeyNotSetException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("API key error", ex.Message);
                }
                catch (SearchEngineIdNotSetException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("Search engine error", ex.Message);
                }
                catch (NullOrEmptySearchPhraseException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("Search phrase error", ex.Message);
                }
                catch (UrlExtractionException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("URL extraction error", ex.Message);
                }

            }

            return imageURLs;
        }
        // Geting images URLs using Web Scraping
        private async Task<List<string>> GetImageURLsAsyncScraper(List<RowData> excelFileData)
        {

            List<string> imageURLs = new List<string>();
            WebScraperHelper webScraperHelper = new WebScraperHelper();

            // Get URL for every cell phrase 
            foreach (RowData excelRow in excelFileData)
            {
                try
                {
                    string url = await webScraperHelper.GetImageURLAsync(excelRow.RowPhrase);
                    imageURLs.Add(url);
                }
                catch (UrlExtractionException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("URL extraction error", ex.Message);
                }
                catch (ImageForPhraseNotExistException ex)
                {
                    messageBoxDisplayer.ShowErrorBox("Phrase error", ex.Message);
                }


            }

            return imageURLs;
        }
        #endregion

        private async Task AddImagesToExcel(List<RowData> fileData, List<string> imageURLs)
        {
           
            ImageDownloadHelper imageDownloadHelper = new ImageDownloadHelper();

            int rowCounter = rowBegin;

            foreach (string imageUrl in imageURLs)
            {
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    string savePath = AppData.OutputFolder + "\\CellPhotoToAdd.jpg";

                    try
                    {
                        await imageDownloadHelper.DownloadImageAsync(imageUrl);
                    }
                    catch (SaveFolderNotExistException ex)
                    {
                        messageBoxDisplayer.ShowErrorBox("Save folder error", ex.Message);
                    }
                    catch (NullOrEmptyImageUrlException ex)
                    {
                        messageBoxDisplayer.ShowErrorBox("URL error", ex.Message);
                    }
                    catch (ImageDownloadFailureException ex)
                    {
                        messageBoxDisplayer.ShowErrorBox("Image download error", ex.Message);
                    }

                    ExcelImageAdderHelper excelImageAdderHelper = new ExcelImageAdderHelper
                    {
                        _ImageFilePath = savePath
                    };

                    try
                    {
                        excelImageAdderHelper.AddImageToExcelFile(workSheet, rowCounter, ImageCell);
                    }
                    catch (InvalidFileExtensionException ex)
                    {
                        messageBoxDisplayer.ShowErrorBox("File type error", ex.Message);
                    }
                    catch (ExcelFileNotExistsException ex)
                    {
                        messageBoxDisplayer.ShowErrorBox("Excel file error", ex.Message);
                    }
                    catch (ExcelWorksheetNotExistException ex)
                    {
                        messageBoxDisplayer.ShowErrorBox("Excel worksheet error", ex.Message);
                    }
                    catch (InvalidImageFilePathException ex)
                    {
                        messageBoxDisplayer.ShowErrorBox("Image path error", ex.Message);
                    }
                    
                    rowCounter++;

                    ProgressValue = rowCounter;
                }
            }

        }

        private void SetLimitRequests(bool apiExtractor)
        {
            if (!apiExtractor)
            {
                LimitRequests = false;
            }
            else
            {
                LimitRequests = true;
            }
        }


        #region On_Property_Changed
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
