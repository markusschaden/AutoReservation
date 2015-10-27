using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using AutoReservation.Dal;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void Test_GetAutos()
        {
            Assert.AreEqual(3,Target.Autos.Count);
        }

        [TestMethod]
        public void Test_GetKunden()
        {
            Assert.AreEqual(4, Target.Kunden.Count);
        }

        [TestMethod]
        public void Test_GetReservationen()
        {
            Assert.AreEqual(3, Target.Reservationen.Count);
        }

        [TestMethod]
        public void Test_GetAutoById()
        {
            AutoDto auto = Target.FindAuto(2);
            Assert.AreEqual("VW Golf", auto.Marke);
            Assert.AreEqual(AutoKlasse.Mittelklasse, auto.AutoKlasse);
            Assert.AreEqual(120, auto.Tagestarif);
        }

        [TestMethod]
        public void Test_GetKundeById()
        {
            KundeDto kunde = Target.FindKunde(3);
            Assert.AreEqual("Pfahl", kunde.Nachname);
            Assert.AreEqual("Martha", kunde.Vorname);
            Assert.AreEqual("03.07.1950", kunde.Geburtsdatum.ToShortDateString());
        }

        [TestMethod]
        public void Test_GetReservationByNr()
        {
            ReservationDto reservation = Target.FindReservation(1);

            Assert.AreEqual("10.01.2020", reservation.Von.ToShortDateString());
            Assert.AreEqual("20.01.2020", reservation.Bis.ToShortDateString());

            AutoDto auto = Target.FindAuto(reservation.Auto.Id);
            Assert.AreEqual(auto.Marke, reservation.Auto.Marke);
            Assert.AreEqual(auto.AutoKlasse, reservation.Auto.AutoKlasse);
            Assert.AreEqual(auto.Tagestarif, reservation.Auto.Tagestarif);

            KundeDto kunde = Target.FindKunde(reservation.Kunde.Id);
            Assert.AreEqual(kunde.Nachname, reservation.Kunde.Nachname);
            Assert.AreEqual(kunde.Vorname, reservation.Kunde.Vorname);
            Assert.AreEqual(kunde.Geburtsdatum.ToShortDateString(), reservation.Kunde.Geburtsdatum.ToShortDateString());
        }

        [TestMethod]
        public void Test_GetReservationByIllegalNr()
        {
            ReservationDto reservation = Target.FindReservation(-1);
            Assert.AreEqual(null, reservation);

        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            AutoDto newAuto = new AutoDto()
            {
                Basistarif = 5000, Marke = "Audi R8", Tagestarif = 500, AutoKlasse = AutoKlasse.Luxusklasse
            };
            AutoDto temp = Target.InsertAuto(newAuto);

            AutoDto auto = Target.FindAuto(temp.Id);
            Assert.AreEqual("Audi R8", auto.Marke);
            Assert.AreEqual(AutoKlasse.Luxusklasse, auto.AutoKlasse);
            Assert.AreEqual(500, auto.Tagestarif);
            Assert.AreEqual(5000, auto.Basistarif);
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            KundeDto newKunde = new KundeDto()
            {
                Vorname = "Markus",
                Nachname = "Schaden",
                Geburtsdatum = DateTime.ParseExact("11.07.1991","dd.MM.yyyy", new CultureInfo("de-CH"))
            };
            KundeDto temp = Target.InsertKunde(newKunde);

            KundeDto kunde = Target.FindKunde(temp.Id);
            Assert.AreEqual("Markus", kunde.Vorname);
            Assert.AreEqual("Schaden", kunde.Nachname);
            Assert.AreEqual("11.07.1991", kunde.Geburtsdatum.ToShortDateString());
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            AutoDto tempAuto = Target.FindAuto(2);
            KundeDto tempKunde = Target.FindKunde(3);

            ReservationDto newReservation = new ReservationDto()
            {
                Auto = tempAuto,
                Kunde = tempKunde,
                Bis = DateTime.Now.AddMonths(2),
                Von = DateTime.Now.AddMonths(1)
            };

            ReservationDto temp = Target.InsertReservation(newReservation);
            ReservationDto reservation = Target.FindReservation(temp.ReservationNr);

            Assert.AreEqual(newReservation.Von.ToShortDateString(), reservation.Von.ToShortDateString());
            Assert.AreEqual(newReservation.Bis.ToShortDateString(), reservation.Bis.ToShortDateString());
            
            Assert.AreEqual(tempAuto.Marke, reservation.Auto.Marke);
            Assert.AreEqual(tempAuto.AutoKlasse, reservation.Auto.AutoKlasse);
            Assert.AreEqual(tempAuto.Tagestarif, reservation.Auto.Tagestarif);
            
            Assert.AreEqual(tempKunde.Nachname, reservation.Kunde.Nachname);
            Assert.AreEqual(tempKunde.Vorname, reservation.Kunde.Vorname);
            Assert.AreEqual(tempKunde.Geburtsdatum.ToShortDateString(), reservation.Kunde.Geburtsdatum.ToShortDateString());
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            Target.DeleteKunde(Target.FindKunde(1));
            Assert.AreEqual(3, Target.Kunden.Count);
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Target.DeleteAuto(Target.FindAuto(1));
            Assert.AreEqual(2, Target.Autos.Count);
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            Target.DeleteReservation(Target.FindReservation(1));
            Assert.AreEqual(2, Target.Reservationen.Count);
        }
    }
}
