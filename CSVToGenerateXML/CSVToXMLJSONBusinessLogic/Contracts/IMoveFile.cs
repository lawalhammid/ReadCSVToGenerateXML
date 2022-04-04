using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSVToXMLJSONBusinessLogic.Contracts
{
    public interface IMoveFile
    {
        bool MoveProcessedFile(string fileToMove, string moveTo);
    }
} 