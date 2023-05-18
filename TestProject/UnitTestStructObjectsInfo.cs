using DataAccessLayer;
using DO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using System.IO;

namespace UtilReflectApiPrintStructObjTestProject
{
    public class Tests
    {
        //private Person _inputData;
        private string _expectedResutl = "\nObject of Class Person\n------------------------------------------\n age == 55  \nObject of Class Name\n------------------------------------------\n lastName == Gates  firstName == Bill  ";
        private string _ResponseJson;
        private TrendingJsonResponse _actualResutl;

        [SetUp]
        public void Setup()
        {
            var jsonTestDataFolder = Directory.GetCurrentDirectory();
            var jsonTestDataFile = "Response.json";
            var fullPath = Path.Combine(jsonTestDataFolder, jsonTestDataFile);
            var fileHanlder = new FileHandler();
            _actualResutl = fileHanlder.LoadJsonFile<TrendingJsonResponse>(fullPath); 
        }

        [Test]
        public void TrendingJsonResponseStructureTest()
        {
            Assert.AreEqual(_actualResutl?.data?.Count, 25);
        }
    }
}