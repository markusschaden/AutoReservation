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
        public List<AutoDto> Autos
        {
            get
            {
                WriteActualMethod();

                return DtoConverter.ConvertToDtos(autoReservationBusinessComponent.Autos());
            }
        }

        public AutoDto FindAuto(int id)
        {
            WriteActualMethod();

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.FindAuto(id));
        }

        public AutoDto InsertAuto(AutoDto autoDto)
        {
            WriteActualMethod();
            Auto auto = DtoConverter.ConvertToEntity(autoDto);

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.InsertAuto(auto));
        }

        public AutoDto UpdateAuto(AutoDto modifiedDto, AutoDto originalDto)
        {
            WriteActualMethod();
            Auto modified = DtoConverter.ConvertToEntity(modifiedDto);
            Auto original = DtoConverter.ConvertToEntity(originalDto);
            try
            {
                return DtoConverter.ConvertToDto(autoReservationBusinessComponent.UpdateAuto(modified, original));
            }
            catch (LocalOptimisticConcurrencyException<Auto> e)
            {
                throw new FaultException<AutoDto>(modifiedDto);
            }
        }

        public AutoDto DeleteAuto(AutoDto autoDto)
        {
            WriteActualMethod();
            Auto auto = DtoConverter.ConvertToEntity(autoDto);

            return DtoConverter.ConvertToDto(autoReservationBusinessComponent.DeleteAuto(auto));
        }
    }
}
