# PhotoAdder
C# application, utilizing Google Programmable Search Engine and Google Search API or Web scraping for search, download and addition to excel file of image related to received  phrase. 

# Detailed Description
**PhotoAdder** is a Desktop application in C# with WPF interface enables searching and organizing photos. It uses Google Programmable Search Engine and Google
Search API for precise searches, allowing to download images and
save them in Excel file. Additionally, it offers web scraping, enabling to
search photos from the Internet, which increases flexibility and versatility.

## How It Works
1. **Phrase Extraction**:  
   The application extracts search phrases from a specified column in the Excel file.  

2. **Image Search**:  
   Using the **Google Programmable Search Engine**, the application searches for images based on the extracted phrases.

3. **Image Download and Insertion**:  
   Once an image is found, it is downloaded to the device and inserted into the specified column in the Excel file.

## Features
- **Configurable Search Range**:  
  Users can limit the number of phrases extracted for Google Search, ensuring they stay within the free tier of the Google Search API (100 requests per day).  

- **Customizable Settings**:  
  Users can specify:
  - The column for search phrases.
  - The column where images will be saved.
  - The starting row for processing.

This tool simplifies the process of automating image insertion into Excel files while maintaining full control over search limits and output customization.


## Tech stack
**Tech:** WPF, C# .NET 6, HTTP Requests, Google Search API, Google Programmable Search Engine, JSON, UnitT esting

**Packages:** CloedXML, Newtonsoft.Json

## Application looks
![PhotoAdderLooks](https://github.com/user-attachments/assets/bac38d97-73ef-4310-a92c-0afb2b982031)

# Application Setup
To use the application, some modifications need to be made to the **`ApiData.txt`** file:

1. **Replace the `ApiKey` Field**  
   Update the `ApiKey:` field with your own API key.

2. **Replace the `SearchEngineId` Field**  
   Update the `SearchEngineId:` field with your Google Programmable Search Engine ID.

Ensure both fields are correctly updated to allow the application to function properly.

# How to Use the Program

Follow these steps to run the image search and download process using the program:

## 1. Select the Path to the Excel File
Begin by selecting the path to the Excel file containing the search phrases.

## 2. Provide the Path to the Save Folder
Specify the folder where images will be temporarily saved.

## 3. Configure Phrase Extraction and Image Saving
Set the following details to extract phrases and save images in the Excel file:

- **Worksheet Number**: Enter the number of the worksheet containing the search phrases and where images will be saved.
- **Phrase Column**: Specify the column number that contains the search phrases.
- **Image Column**: Specify the column number where the images will be inserted.
- **Starting Row**: Enter the row number from which phrase extraction and image insertion will begin.

## 4. Optional: Limit Request to Free Version
- If this option is enabled, you can set the last row to be evaluated by the program.
- If disabled, the program will extract every occupied row from the Excel file.

## 5. Execute the Program
Once all the settings are configured, press the **"Execute"** button to start the process.

## 6. Completion
When the program successfully completes all operations, a message box will appear to inform you that the Excel file with images is ready.


