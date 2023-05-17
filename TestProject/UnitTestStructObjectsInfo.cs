using NUnit.Framework;

namespace UtilReflectApiPrintStructObjTestProject
{
    public class Tests
    {
        private Person _inputData;
        private string _expectedResutl = "\nObject of Class Person\n------------------------------------------\n age == 55  \nObject of Class Name\n------------------------------------------\n lastName == Gates  firstName == Bill  ";

        [SetUp]
        public void Setup()
        {

            var n = new Name()
            {
                firstName = "Bill",
                lastName = "Gates"
            };

             _inputData = new Person()
            {
                age = 55,
                name = n
            };

        }

        [Test]
        public void StructObjectsInfoTest()
        {
            var actualResutl = new utility().StructObjectsInfo(_inputData).ToString();
            Assert.AreEqual(actualResutl, _expectedResutl);
        }
    }
}