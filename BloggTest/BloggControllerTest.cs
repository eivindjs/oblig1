using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication3.Models;
using System.Collections.Generic;
using WebApplication3.Controllers;
using System.Web.Mvc;
using System.Collections;

namespace BloggTest
{
    [TestClass]
    public class BloggControllerTest
    {
        private Mock<IBloggRepository> repos;

        [TestInitialize] 
        public void setupindex(){
            repos = new Mock<IBloggRepository>();
        }
        [TestMethod]
        public void TestIndexMethod()
        {

            List<Blogg> fakeBlogs = new List<Blogg> {
                new Blogg { Blogg_tekst = "Blog1", dato = DateTime.Now},
                new Blogg {Blogg_tekst ="Blog2", dato = DateTime.Now}
            };

            repos.Setup(x => x.AlleBlogger()).Returns(fakeBlogs);
            var controller = new BloggController(repos.Object);

            var result = (ViewResult)controller.Index();

            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Blogg));
            Assert.IsNotNull(result, "ViewResult is null");
            var op = result.ViewData.Model as List<Blogg>;
            Assert.AreEqual(2, op.Count, "Got wrong number of blogs");
        }
    }
}
