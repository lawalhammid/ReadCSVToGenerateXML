using CSVToXMLJSON.Configurations;
using CSVToXMLJSON.Response;
using CSVToXMLJSONBusinessLogic.Contracts;
using CSVToXMLJSONBusinessLogic.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSVToXMLJSON
{
    public class MainProgram
    {
        public static async void MainAsync(string[] args)
        {
            try
            {
                await InvokeJob();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred when converting file");
            }

            async Task<string> InvokeJob()
            {
                //setup our DI
                var serviceProvider = DI.RegisterDI();

                Console.WriteLine("To convert file, enter 1 to convert from CSV to XML or enter 2 to convert from XML to CSV, then press enter button");

                //Validate File Path
                var validateUserfilePath = serviceProvider.GetService<IValidatedirectory>();

                var res = new FileGenResponse();

                int userInput = 0;
                
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:  //Convert CSV to XML

                            string PastedDirectoryFromuser = retrunfilePath(userInput);

                            var convertCSVToXLM = serviceProvider.GetService<IConvertCSVToXML>();
                            res = validateUserfilePath.ValidateDirectory(PastedDirectoryFromuser) == true ? await convertCSVToXLM.ConvertCSVToXML(PastedDirectoryFromuser) : await warningMessage(userInput);
                            Console.WriteLine(res.Message);
                            break;

                        case 2:  //Convert XML to CSV

                            PastedDirectoryFromuser = retrunfilePath(userInput);

                            var convertXLMToCSV = serviceProvider.GetService<IConvertXMLToCSV>();
                            res = validateUserfilePath.ValidateDirectory(PastedDirectoryFromuser) == true ? await convertXLMToCSV.ConvertXMLToCSV(PastedDirectoryFromuser) : await warningMessage(userInput);
                            Console.WriteLine(res.Message);
                            break;

                        default:
                            await warningMessageInvalInput(userInput);
                            break;
                    }     
                }
                return String.Empty;
            }

            //Get file path from users
            string retrunfilePath(int userInput)
            {
                string fileType = userInput == 1 ? "CSV" : "XML";
                Console.WriteLine($"Paste the directory to read the {fileType} file from then press enter button: ");
                return Console.ReadLine();
            }

            //warning message for invalid directory
            async Task<FileGenResponse> warningMessage(int userInput)
            {
                string fileType = userInput == 1 ? "CSV" : "XML";
                Console.WriteLine($"You pasted an invalid directory. Kindly copy and paste the right directory where you have the {fileType} file in your local machine/server.");
                await InvokeJob();
                return null;
            }

            //warning message for invalid directory
            async Task<FileGenResponse> warningMessageInvalInput(int userInput)
            {
                string fileType = userInput == 1 ? "CSV" : "XML";
                Console.WriteLine($"You entered an invalid input to process the file");
                await InvokeJob();
                return null;
            }
              
        }
    }
}