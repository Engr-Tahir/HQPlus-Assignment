using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Task3.WebServiceAPI.Controllers.Tests
{
    [TestClass()]
    public class HotelsControllerTests
    {
        [TestMethod()]
        public void GetTestPass()
        {
            // Arrange
            HotelsController controller = new HotelsController();
            controller.Request = new HttpRequestMessage();

            // Act
            var result = controller.Get(7294, DateTime.Parse("2016-03-15"));
           
            // Assert
            Assert.IsNotNull(result);
           
        }
        [TestMethod()]
        public void GetTestFailWithInvalidId()
        {
            // Arrange
            HotelsController controller = new HotelsController();
            controller.Request = new HttpRequestMessage();

            // Act
            var result = controller.Get(1, DateTime.Parse("2016-03-15")) ;
          
            // Assert
            Assert.IsNull(result);

        }
    }
}