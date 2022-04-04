using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CSVToXMLJSONBusinessLogic.Contracts
{
    public interface IReadFile
    {
        Task<StorageFile> ReadFile(string FilePath);
    }
}
