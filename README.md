# PhotoAdder
C# application, utilizing Google Programmable Search Engine and Google Search API for search, download and addition to excel file of image related recived to phrase. 

## Detiled description
PhotoAdder is desktop application which should be used to retrive images from the internet to add them into specified by the user collumn in the provided Excel file. Images are broswed by the Google Programmable Search Engine with phrases extracted from the Exccel file. When image is found then it is downloaded in the device and saved into Excel file. Application allows user to set the number of phrases extracted for the Google Search in order to stay within the free limit of Google Search API which is 100 requests per day.


## Tech stack
**Tech:** WPF, C# .NET 6, HTTP Requests, Google Search API, Google Programmable Search Engine, JSON 

**Packages:** CloedXML, Newtonsoft.Json

## Application looks

## Application setup
In order to use the application some changes need to be performed on the *"ApiData.txt"* file. Field *ApiKey:* needs to be replaced with users own API key. The same should be done for the field *SearchEngineId:* wher it should be replaced with users Google Programmable Search Engine ID.

## How to use
