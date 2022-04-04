using CSVToXMLJSONBusinessLogic.Contracts;
using CSVToXMLJSONBusinessLogic.Services;
using CSVToXMLJSONBusinessLogic.Validation;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Windows.Storage;

namespace CSVToXMLJSONAcceptanceTest
{
    public class UnitAcceptanceCSVTest
    {
        private ValidatedirectoryService _validatedirectoryService;

        private Mock<IReadFile> _iReadFile;

        private ConvertCSVToXMLService _convertCVSToXMLService;

        //Note: replace below with your own file directory
        private const string DefaultCSVfilePath = @"C:\Users\USER\Documents\LawalInterviewSchedules\Emilia\CSVFiles";

        [SetUp]
        public void Setup()
        {
            _validatedirectoryService = new ValidatedirectoryService();

            _iReadFile = new Mock<IReadFile>();

            _iReadFile.Setup(x => x.ReadFile(DefaultCSVfilePath)).Returns(ReturnDefaultDirectoryTest());
            _convertCVSToXMLService = new ConvertCSVToXMLService(_iReadFile.Object); 
        }

        [Test]
        public void ValidateDirectoryTest()
        {
            var res = _validatedirectoryService.ValidateDirectory(DefaultCSVfilePath);

            Assert.IsNotNull(res);
            Assert.IsTrue(res == true);
        }

        [Test]
        public void ConvertCSVTest()
        {
            var res = _convertCVSToXMLService.ConvertCSVToXML(DefaultCSVfilePath).Result;

            Assert.IsNotNull(res);
            Assert.IsTrue(res.Success == true);

        }
        private async Task<StorageFile> ReturnDefaultDirectoryTest()
        {
            var folder = StorageFolder.GetFolderFromPathAsync(DefaultCSVfilePath).GetResults();

            var files = folder.GetFilesAsync().GetResults();

            return files[0];
        }  
    }
}