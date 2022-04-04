using System;
using System.Collections.Generic;
using System.Text;

namespace CSVToXMLJSONBusinessLogic.Helpers
{
    public static class AutoGenerateFileName
    {
        public static string IdforeachFile()
        {
            try
            {
                return DateTime.Now.ToString("MMddyyyyHHmmss");


            }
            catch (Exception ex)
            {
                var exM = ex == null ? ex.InnerException.Message : ex.Message;
                return "0.00";
            }
        }
    }
}
