using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        List<AutoDto> Autos
        {
            [OperationContract]
            get;
        }
        [OperationContract]
        AutoDto FindAuto(int id);
        [OperationContract]
        AutoDto InsertAuto(AutoDto auto);
        [OperationContract]
        [FaultContract(typeof(AutoDto))]
        AutoDto UpdateAuto(AutoDto modified, AutoDto original);
        [OperationContract]
        AutoDto DeleteAuto(AutoDto auto);

        List<KundeDto> Kunden
        {
            [OperationContract]
            get;
        }
        [OperationContract]
        KundeDto FindKunde(int id);
        [OperationContract]
        KundeDto InsertKunde(KundeDto kunde);
        [OperationContract]
        [FaultContract(typeof(KundeDto))]
        KundeDto UpdateKunde(KundeDto modified, KundeDto original);
        [OperationContract]
        KundeDto DeleteKunde(KundeDto kunde);

        List<ReservationDto> Reservationen
        {
            [OperationContract]
            get;
        }
        [OperationContract]
        ReservationDto FindReservation(int id);
        [OperationContract]
        ReservationDto InsertReservation(ReservationDto reservation);
        [OperationContract]
        [FaultContract(typeof(ReservationDto))]
        ReservationDto UpdateReservation(ReservationDto modified, ReservationDto original);
        [OperationContract]
        ReservationDto DeleteReservation(ReservationDto reservation);
    }
}
