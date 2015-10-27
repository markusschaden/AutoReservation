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
        public List<ReservationDto> Reservationen
        {
            get
            {
                WriteActualMethod();

                return DtoConverter.ConvertToDtos(AutoReservationBusinessComponent.Reservationen());
            }
        }

        public ReservationDto FindReservation(int id)
        {
            WriteActualMethod();

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.FindReservation(id));
        }

        public ReservationDto InsertReservation(ReservationDto ReservationDto)
        {
            WriteActualMethod();
            Reservation Reservation = DtoConverter.ConvertToEntity(ReservationDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.InsertReservation(Reservation));
        }

        public ReservationDto UpdateReservation(ReservationDto modifiedDto, ReservationDto originalDto)
        {
            WriteActualMethod();
            Reservation modified = DtoConverter.ConvertToEntity(modifiedDto);
            Reservation original = DtoConverter.ConvertToEntity(originalDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.UpdateReservation(modified, original));
        }

        public ReservationDto DeleteReservation(ReservationDto ReservationDto)
        {
            WriteActualMethod();
            Reservation Reservation = DtoConverter.ConvertToEntity(ReservationDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.DeleteReservation(Reservation));
        }
    }
}
