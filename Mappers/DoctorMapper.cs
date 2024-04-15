using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Doctor;

namespace api.Mappers
{
    public static class DoctorMapper
    {
        public static DoctorDTO ToDoctorDTO(this Models.Doctor doctor)
        {
            return new DoctorDTO
            {
                Name = doctor.Name,
                Specialaztion = doctor.Specialaztion
            };
        }
    }
}