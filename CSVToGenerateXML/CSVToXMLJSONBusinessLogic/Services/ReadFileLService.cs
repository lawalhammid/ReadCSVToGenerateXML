using CSVToXMLJSONBusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace CSVToXMLJSONBusinessLogic.Services
{
    /// <summary>
    /// This class read any kind of files with the specified directory by using 
    /// UwpDesktop  library
    /// </summary>
    public class ReadFileLService : IReadFile
    {
        //public async Task<IReadOnlyList<StorageFile>> ReadFile(string FilePath)
        //{
        //   var folder = await StorageFolder.GetFolderFromPathAsync(FilePath);

        //   return  await folder.GetFilesAsync();
        //}

        public async Task<StorageFile> ReadFile(string FilePath)
        {
            var folder = await StorageFolder.GetFolderFromPathAsync(FilePath);

            var files = await folder.GetFilesAsync();

            return files[0];
        }
    }

    
}