using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication3.Models;
using WebApplication3.Controllers;
using System.Web.Mvc;

namespace BloggTest
{
    [TestClass]
    public class KommentarLukketTest
    {
        private Mock<IBloggRepository> repos;

        [TestInitialize]
        public void Setup()
        {
            repos = new Mock<IBloggRepository>();
        }
        
        [TestMethod]
        public void KommentarTestLukket()
        {
            

        }
    }
}
