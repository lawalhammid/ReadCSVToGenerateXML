using ChoETL;
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
using System.Xml.Serialization;

namespace CSVToXMLJSONBusinessLogic.Services
{
    /// <summary>
    /// The class convert XMl  file to CSV file
    /// </summary>
    public class ConvertXMLToCSVService : IConvertXMLToCSV
    {
        private const string TargetFileType = ".xml";
        private const string CSVGeneratedFolder = "CSVGeneratedFolder";
        private const string xmlFormat = ".csv";
        private readonly IReadFile _iReadFile;
 
        public ConvertXMLToCSVService(IReadFile iReadFile)
        {
            _iReadFile = iReadFile;
        }

        //The function below convert XML file to CSV file
        public async Task<FileGenResponse> ConvertXMLToCSV(string XMLFilePath)
        {
            var file = await _iReadFile.ReadFile(XMLFilePath);
            if (file == null) return new FileGenResponse { Success = false };
            //Vaidate that the file is a valid csv file
            if (file.Path.Trim().EndsWith($"{TargetFileType}"))
            {
                XElement xfile = XElement.Load(file.Path.Trim());
                XElement dataElement = XElement.Parse(xfile.ToString());
                var csvData = GetCSVFromXML(dataElement);

                var validateCSVPathDirectory = $@"{XMLFilePath}\{CSVGeneratedFolder}";
                if (!Directory.Exists(validateCSVPathDirectory))
                {
                    Directory.CreateDirectory(validateCSVPathDirectory);
                }

                var writeToDirectory = $@"{validateCSVPathDirectory}\{file.DisplayName}-{AutoGenerateFileName.IdforeachFile()}{xmlFormat}";

                File.WriteAllText(writeToDirectory, csvData.ToString());

                return new FileGenResponse { Success = true, 
                                             Message = $"The file was converted successfully into {validateCSVPathDirectory} directory!"
                };
            }
            return new FileGenResponse { Success = false };
        }

        private static object GetCSVFromXML(XElement dataElement)
        {
            StringBuilder sb = new StringBuilder();
            var elements = dataElement.Elements();
            var forHeader = elements.First();
            var header = string.Join(",", forHeader.Elements().Select(n => n.Name));
            sb.Append(header + Environment.NewLine);
            var lines = from d in elements
                        let line = string.Join(",", d.Elements().Select(s => s.Value))
                        select line;

            sb.Append(string.Join(Environment.NewLine, lines));

            return sb.ToString();
        }
    }
}

