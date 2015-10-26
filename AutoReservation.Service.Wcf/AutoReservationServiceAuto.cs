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
        public List<AutoDto> Autos
        {
            get
            {
                WriteActualMethod();

                return DtoConverter.ConvertToDtos(AutoReservationBusinessComponent.Autos());
            }
        }

        public AutoDto FindAuto(int id)
        {
            WriteActualMethod();

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.FindAuto(id));
        }

        public AutoDto InsertAuto(AutoDto autoDto)
        {
            WriteActualMethod();
            Auto auto = DtoConverter.ConvertToEntity(autoDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.InsertAuto(auto));
        }

        public AutoDto UpdateAuto(AutoDto modifiedDto, AutoDto originalDto)
        {
            WriteActualMethod();
            Auto modified = DtoConverter.ConvertToEntity(modifiedDto);
            Auto original = DtoConverter.ConvertToEntity(originalDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.UpdateAuto(modified, original));
        }

        public AutoDto DeleteAuto(AutoDto autoDto)
        {
            WriteActualMethod();
            Auto auto = DtoConverter.ConvertToEntity(autoDto);

            return DtoConverter.ConvertToDto(AutoReservationBusinessComponent.DeleteAuto(auto));
        }
    }
}
