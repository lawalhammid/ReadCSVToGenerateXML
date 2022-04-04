using CSVToXMLJSON.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSVToXMLJSONBusinessLogic.Contracts
{
    public interface IConvertCSVToXML
    {
        Task<FileGenResponse> ConvertCSVToXML(string CSVFilePath);
    }
}