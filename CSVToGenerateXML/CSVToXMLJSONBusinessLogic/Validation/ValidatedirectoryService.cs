using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVToXMLJSONBusinessLogic.Validation
{
    public class ValidatedirectoryService : IValidatedirectory
    {
        public bool ValidateDirectory(string FileDirectory)
        {
            if (Directory.Exists(FileDirectory))
            {
                return true;
            }

            return false;
        }
    }
}
