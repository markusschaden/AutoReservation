using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal;

namespace AutoReservation.Service.Wcf
{
    public partial class AutoReservationService
    {
        public List<KundeDto> Kunden
        {
            get
            {
                WriteActualMethod();

                return DtoConverter.ConvertToDtos(AutoReservationBusinessComponent.Kunden());
            }
        }

        public KundeDto FindKunde(int id)
        {
            WriteActualMethod();

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.FindKunde(id));
        }

        public KundeDto InsertKunde(KundeDto KundeDto)
        {
            WriteActualMethod();
            Kunde Kunde = DtoConverter.ConvertToEntity(KundeDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.InsertKunde(Kunde));
        }

        public KundeDto UpdateKunde(KundeDto modifiedDto, KundeDto originalDto)
        {
            WriteActualMethod();
            Kunde modified = DtoConverter.ConvertToEntity(modifiedDto);
            Kunde original = DtoConverter.ConvertToEntity(originalDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.UpdateKunde(modified, original));
        }

        public KundeDto DeleteKunde(KundeDto KundeDto)
        {
            WriteActualMethod();
            Kunde Kunde = DtoConverter.ConvertToEntity(KundeDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.DeleteKunde(Kunde));
        }
    }
}
