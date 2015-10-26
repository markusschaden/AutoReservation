using System.Collections.Generic;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        List<AutoDto> Autos { get; }
        AutoDto FindAuto(int id);
        AutoDto InsertAuto(AutoDto auto);
        AutoDto UpdateAuto(AutoDto modified, AutoDto original);
        AutoDto DeleteAuto(AutoDto auto);

        List<KundeDto> Kunden { get; }
        KundeDto FindKunde(int id);
        KundeDto InsertKunde(KundeDto kunde);
        KundeDto UpdateKunde(KundeDto modified, KundeDto original);
        KundeDto DeleteKunde(KundeDto kunde);

        List<ReservationDto> Reservationen { get; }
        ReservationDto FindReservation(int id);
        ReservationDto InsertReservation(ReservationDto reservation);
        ReservationDto UpdateReservation(ReservationDto modified, ReservationDto original);
        ReservationDto DeleteReservation(ReservationDto reservation);
    }
}
