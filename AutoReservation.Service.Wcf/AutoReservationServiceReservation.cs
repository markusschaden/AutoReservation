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
        public List<ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();

                return DtoConverter.ConvertToDtos(autoReservationBusinessComponent.Reservationen());
            }
        }

        public ReservationDto FindReservation(int id)
        {
            WriteActualMethod();

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.FindReservation(id));
        }

        public ReservationDto InsertReservation(ReservationDto ReservationDto)
        {
            WriteActualMethod();
            Reservation Reservation = DtoConverter.ConvertToEntity(ReservationDto);

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.InsertReservation(Reservation));
        }

        public ReservationDto UpdateReservation(ReservationDto modifiedDto, ReservationDto originalDto)
        {
            WriteActualMethod();
            Reservation modified = DtoConverter.ConvertToEntity(modifiedDto);
            Reservation original = DtoConverter.ConvertToEntity(originalDto);

            try { 
                return DtoConverter.ConvertToDto(autoReservationBusinessComponent.UpdateReservation(modified, original));
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<ReservationDto>(modifiedDto);
            }
        }

        public ReservationDto DeleteReservation(ReservationDto ReservationDto)
        {
            WriteActualMethod();
            Reservation Reservation = DtoConverter.ConvertToEntity(ReservationDto);

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.DeleteReservation(Reservation));
        }
    }
}
