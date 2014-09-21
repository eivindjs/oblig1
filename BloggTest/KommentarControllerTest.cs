using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Models;
using WebApplication3.Controllers;
using System.Web.Mvc;
using Moq;

namespace BloggTest
{
    [TestClass]
    public class KommentarControllerTest
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
            Innlegg lukketInnlegg = new Innlegg { Innlegg_Tittel = "test", Innlegg_Tekst = "tester", Innlegg_Id = 1, KommentarTillat = false };
            Kommentar k = new Kommentar { Kom_id = 2, Kommentar_Tittel = "test", Kommentar_tekst = "test", Innlegg_Id =1};

            repos.Setup(x => x.GetInnleggMedKommentarer(1)).Returns(lukketInnlegg);
            repos.Setup(x => x.CreateKommentar(k)).Returns(true);

            var controller = new KommentarController(repos.Object);

            var result = controller.Create(k, k.Innlegg_Id);

            repos.Verify(x => x.CreateKommentar(k));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }
        [TestMethod]
        public void KommentarTestOpen()
        {
            Innlegg åpentInnlegg = new Innlegg { Innlegg_Tittel = "test", Innlegg_Tekst = "tester", Innlegg_Id = 1, KommentarTillat = true };
            Kommentar k = new Kommentar { Kom_id = 1, Kommentar_Tittel = "test", Kommentar_tekst = "test"};

            repos.Setup(x => x.GetInnleggMedKommentarer(1)).Returns(åpentInnlegg);
            repos.Setup(x => x.CreateKommentar(k)).Returns(true);

            var controller = new KommentarController(repos.Object);

            var result = controller.Create(k, k.Innlegg_Id);

            repos.Verify(x => x.CreateKommentar(k));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

        }
    }
}
