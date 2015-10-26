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
        public List<KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();
                throw new NotImplementedException();
            }
        }

        public KundeDto FindKunde(int id)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public KundeDto InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public KundeDto UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }

        public KundeDto DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            throw new NotImplementedException();
        }
    }
}
