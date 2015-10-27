using System;
using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void Test_UpdateAuto()
        {
            int newTagestarif = 1000;
            Auto modifiedAuto = Target.FindAuto(1);
            Auto originalAuto = Target.FindAuto(1);
            modifiedAuto.Tagestarif = newTagestarif;

            Target.UpdateAuto(modifiedAuto, originalAuto);

            Auto updatedAuto = Target.FindAuto(1);

            Assert.AreEqual(newTagestarif, updatedAuto.Tagestarif);

        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            string newVorname = "Markus";
            string newNachname = "Schaden";
            Kunde modifiedKunde = Target.FindKunde(1);
            Kunde originalKunde = Target.FindKunde(1);
            modifiedKunde.Nachname = newNachname;
            modifiedKunde.Vorname = newVorname;

            Target.UpdateKunde(modifiedKunde, originalKunde);

            Kunde updatedKunde = Target.FindKunde(1);

            Assert.AreEqual(newNachname, updatedKunde.Nachname);
            Assert.AreEqual(newVorname, updatedKunde.Vorname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            DateTime von = DateTime.Now.AddYears(1);
            DateTime bis = DateTime.Now.AddYears(2);
            Reservation modifiedReservation = Target.FindReservation(1);
            Reservation originalReservation = Target.FindReservation(1);
            modifiedReservation.Bis = bis;
            modifiedReservation.Von = von;

            Target.UpdateReservation(modifiedReservation, originalReservation);

            Reservation updatedReservation = Target.FindReservation(1);

            Assert.AreEqual(von.ToShortDateString(), updatedReservation.Von.ToShortDateString());
            Assert.AreEqual(von.ToShortTimeString(), updatedReservation.Von.ToShortTimeString());

            Assert.AreEqual(bis.ToShortDateString(), updatedReservation.Bis.ToShortDateString());
            Assert.AreEqual(bis.ToShortTimeString(), updatedReservation.Bis.ToShortTimeString());

        }
    }
}
