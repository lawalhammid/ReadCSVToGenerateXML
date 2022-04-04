using CSVToXMLJSON.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSVToXMLJSONBusinessLogic.Contracts
{
    public interface IConvertXMLToCSV
    {
        Task<FileGenResponse> ConvertXMLToCSV(string XMLFilePath);
    }
} 