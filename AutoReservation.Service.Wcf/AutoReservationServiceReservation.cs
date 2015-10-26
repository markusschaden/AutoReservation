using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Service.Wcf
{
    public partial class AutoReservationService
    {
        public List<ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();
                throw new NotImplementedException();
            }
        }

        public ReservationDto FindReservation(int id)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public ReservationDto InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public ReservationDto UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public ReservationDto DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }
    }
}
