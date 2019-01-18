using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication4;
using WebApplication4.Controllers;

namespace WebApplication4.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {

            HomeController controller = new HomeController();

            // Act
            //ViewResult result = controller.Index() as ViewResult;
            var result = controller.Session["Exams"];

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CallendarIsEmpty()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var result = controller.Session["Login"];

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SearchForCourse()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.SearchForCourse() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
