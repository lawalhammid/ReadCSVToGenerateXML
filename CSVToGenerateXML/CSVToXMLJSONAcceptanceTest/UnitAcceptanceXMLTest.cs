using CSVToXMLJSONBusinessLogic.Contracts;
using CSVToXMLJSONBusinessLogic.Services;
using CSVToXMLJSONBusinessLogic.Validation;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Windows.Storage;

namespace CSVToXMLJSONAcceptanceTest
{
    public class UnitAcceptanceXMLTest
    {
        private ValidatedirectoryService _validatedirectoryService;
        private Mock<IReadFile> _iReadFileXML;
       
        private ConvertXMLToCSVService _convertXMLToCSVService;

        //Note: replace below with your own file directory
        private const string DefaultXMLfilePath = @"C:\Users\USER\Documents\LawalInterviewSchedules\Emilia\CSVFiles\XMLGeneratedFolder";

        [SetUp]
        public void Setup()
        {
            _validatedirectoryService = new ValidatedirectoryService();

            _iReadFileXML = new Mock<IReadFile>();
            _iReadFileXML.Setup(x => x.ReadFile(DefaultXMLfilePath)).Returns(ReturnDefaultXMLDirectoryTest());

            _convertXMLToCSVService = new ConvertXMLToCSVService(_iReadFileXML.Object);
        }

        [Test]
        public void ValidateDirectoryTest()
        {
            var res = _validatedirectoryService.ValidateDirectory(DefaultXMLfilePath);

            Assert.IsNotNull(res);
            Assert.IsTrue(res == true);
        }

        [Test]
        public void ConvertXMLTest()
        {
            var res = _convertXMLToCSVService.ConvertXMLToCSV (DefaultXMLfilePath).Result;

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success == true);

        }

        private async Task<StorageFile> ReturnDefaultXMLDirectoryTest()
        {
            var folder = StorageFolder.GetFolderFromPathAsync(DefaultXMLfilePath).GetResults();

            var files = folder.GetFilesAsync().GetResults();

            return files[0];
        }

        
    }
}