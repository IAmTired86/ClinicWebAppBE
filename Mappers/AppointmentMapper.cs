using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Appointment;
using Npgsql.Replication;
using api.Models;

namespace api.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentDTO ToAppointmentDto(this Appointment appointment)
        {
            return new AppointmentDTO
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                Reason = appointment.Reason
            };
        }
    }
}