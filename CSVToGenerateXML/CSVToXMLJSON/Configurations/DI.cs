using CSVToXMLJSONBusinessLogic.Contracts;
using CSVToXMLJSONBusinessLogic.Services;
using CSVToXMLJSONBusinessLogic.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToXMLJSON.Configurations
{
    public class DI
    {
        public static ServiceProvider RegisterDI()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConvertCSVToXML, ConvertCSVToXMLService>()
                .AddSingleton<IValidatedirectory, ValidatedirectoryService>()
                .AddSingleton<IReadFile, ReadFileLService>()
                .AddSingleton<IMoveFile, MoveFileService>()
                .AddSingleton<IConvertXMLToCSV, ConvertXMLToCSVService>()
               
             .BuildServiceProvider();

            return serviceProvider;
        }
    }
}