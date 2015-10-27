using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

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
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            Assert.Inconclusive("Test not implemented.");
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
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }
    }
}
