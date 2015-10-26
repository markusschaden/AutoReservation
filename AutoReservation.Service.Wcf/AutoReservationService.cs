using System;
using System.Diagnostics;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Service.Wcf
{
    public partial class AutoReservationService : IAutoReservationService
    {
        private AutoReservationBusinessComponent AutoReservationBusinessComponent;
        public AutoReservationService()
        {
            AutoReservationBusinessComponent = new AutoReservationBusinessComponent();
        }

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }
    }
}