using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.BusinessLayer;
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

                return DtoConverter.ConvertToDtos(autoReservationBusinessComponent.Kunden());
            }
        }

        public KundeDto FindKunde(int id)
        {
            WriteActualMethod();

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.FindKunde(id));
        }

        public KundeDto InsertKunde(KundeDto KundeDto)
        {
            WriteActualMethod();
            Kunde Kunde = DtoConverter.ConvertToEntity(KundeDto);

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.InsertKunde(Kunde));
        }

        public KundeDto UpdateKunde(KundeDto modifiedDto, KundeDto originalDto)
        {
            WriteActualMethod();
            Kunde modified = DtoConverter.ConvertToEntity(modifiedDto);
            Kunde original = DtoConverter.ConvertToEntity(originalDto);
            try { 
                return DtoConverter.ConvertToDto(autoReservationBusinessComponent.UpdateKunde(modified, original));
            }
            catch (LocalOptimisticConcurrencyException<Kunde> e)
            {
                throw new FaultException<KundeDto>(modifiedDto);
            }

        }

        public KundeDto DeleteKunde(KundeDto KundeDto)
        {
            WriteActualMethod();
            Kunde Kunde = DtoConverter.ConvertToEntity(KundeDto);

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.DeleteKunde(Kunde));
        }
    }
}
