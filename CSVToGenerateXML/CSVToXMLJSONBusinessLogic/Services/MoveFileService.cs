using CSVToXMLJSONBusinessLogic.Contracts;
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
    /// The class moves files after processed
    /// </summary>
    public class MoveFileService : IMoveFile
    {
        //move file
        public bool MoveProcessedFile(string fileToMove, string moveTo)
        {
            if (!Directory.Exists(moveTo))
            {
                Directory.CreateDirectory(moveTo);
            }

            File.Move(fileToMove, moveTo);
            return true;
        }
    }
}