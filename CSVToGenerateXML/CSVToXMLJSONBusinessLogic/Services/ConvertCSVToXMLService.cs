using CSVToXMLJSON.Response;
using CSVToXMLJSONBusinessLogic.Contracts;
using CSVToXMLJSONBusinessLogic.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSVToXMLJSONBusinessLogic.Services
{
    /// <summary>
    /// The class convert CSV file to XMl file
    /// </summary>
    public class ConvertCSVToXMLService : IConvertCSVToXML
    {
        private const string TargetFileType = ".csv";
        private const string XMLGeneratedFolder = "XMLGeneratedFolder";
        private const string xmlFormat = ".xml";
        private readonly IReadFile _iReadFile;
 
        public ConvertCSVToXMLService(IReadFile iReadFile)
        {
            _iReadFile = iReadFile;
        }

        //The function below convert to CSV file to XML
        public async Task<FileGenResponse> ConvertCSVToXML(string CSVFilePath)
        {
            var file = await _iReadFile.ReadFile(CSVFilePath);
            if (file == null) return new FileGenResponse { Success = false };
            //Vaidate that the file is a valid csv file
            if (file.Path.Trim().EndsWith($"{TargetFileType}"))
            {
                var lines = File.ReadAllLines(file.Path);

                string[] headers = lines[0].Split(',').Select(x => x.Trim('\"')).ToArray();

                //I used .Replace(" ", ""), below because xml does not allow space in xml element name
                var xml = new XElement($"Items",
                   lines.Where((line, index) => index > 0).Select(line => new XElement("Item-Details",
                      line.Split(',').Select((column, index) => new XElement(headers[index].Replace(" ", ""), column)))));

                var validateXMLPathDirectory = $@"{CSVFilePath}\{XMLGeneratedFolder}";
                if (!Directory.Exists(validateXMLPathDirectory))
                {
                    Directory.CreateDirectory(validateXMLPathDirectory);
                }

                xml.Save(@$"{validateXMLPathDirectory}\{file.DisplayName}-{AutoGenerateFileName.IdforeachFile()}{xmlFormat}");

                //Move file after processed this would be done later in the future because of time

                return new FileGenResponse
                {
                    Success = true,
                    Message = $"The file was converted successfully into {validateXMLPathDirectory} directory!"
                };
            }
            return new FileGenResponse
            {
                Success = false,
                Message = "The file could not be converted this time"
            };
        }
    }
}