using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        List<AutoDto> Autos { get; }
        [OperationContract]
        AutoDto FindAuto(int id);
        [OperationContract]
        AutoDto InsertAuto(AutoDto auto);
        [OperationContract]
        AutoDto UpdateAuto(AutoDto modified, AutoDto original);
        [OperationContract]
        AutoDto DeleteAuto(AutoDto auto);

        List<KundeDto> Kunden { get; }
        [OperationContract]
        KundeDto FindKunde(int id);
        [OperationContract]
        KundeDto InsertKunde(KundeDto kunde);
        [OperationContract]
        KundeDto UpdateKunde(KundeDto modified, KundeDto original);
        [OperationContract]
        KundeDto DeleteKunde(KundeDto kunde);
        
        List<ReservationDto> Reservationen { get; }
        [OperationContract]
        ReservationDto FindReservation(int id);
        [OperationContract]
        ReservationDto InsertReservation(ReservationDto reservation);
        [OperationContract]
        ReservationDto UpdateReservation(ReservationDto modified, ReservationDto original);
        [OperationContract]
        ReservationDto DeleteReservation(ReservationDto reservation);
    }
}
