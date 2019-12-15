using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Reporting.Tests {
 
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void GetPassTest()  {
            
            //Arrange.
            string fileName = "task 2 - hotelrates.json";
            string outputFileName = "output.csv";
            string jsonText = System.IO.File.ReadAllText(fileName);
            
            //Act
            var convertor = new JsonToCSV(jsonText);
            convertor.ExportTo(outputFileName);

            //Assert
            var result = System.IO.File.ReadAllText(outputFileName);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetFailTest()  {
            
            //Arrange
            string outputFileName = "output.csv";
            string jsonText = System.IO.File.ReadAllText(outputFileName);
            
            //Act
            var convertor = new JsonToCSV(jsonText);
            convertor.ExportTo(outputFileName);

            //Assert
            var result = System.IO.File.Exists("output2.csv");
            Assert.IsFalse(result);
        }
    }
}
