using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Service.Wcf
{
    [DataContract]
    public partial class AutoReservationService : IAutoReservationService
    {
        private readonly AutoReservationBusinessComponent autoReservationBusinessComponent;
        public AutoReservationService()
        {
            autoReservationBusinessComponent = new AutoReservationBusinessComponent();
        }

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }
    }
}