using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication4.Tests;
using WebApplication4.Controllers;
using WebApplication4.Data.Singleton;
using WebApplication4.Data;

namespace WebApplication4.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        public static string s;

        [TestMethod]
        public void Contact()
        {
            HomeController homeController = new HomeController();
            ViewResult view = homeController.Login() as ViewResult;
            Assert.IsNotNull(view);
        }
        
        [TestMethod]
        public void TestSearching()
        {
            HomeController homeController = new HomeController();
            ViewResult view = homeController.SearchForCourse() as ViewResult;
            ViewResult view2 = homeController.SearchForPerson() as ViewResult;
            Assert.AreNotEqual(view, view2);
        }

        [TestMethod]
        public void About()
        {
            TestController testController = new TestController();
            ViewResult view = testController.TestLogin() as ViewResult;
            Assert.IsNotNull(view);

        }
    }
}
