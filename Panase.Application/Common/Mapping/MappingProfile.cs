using AutoMapper;
using Panase.Application.Feature.Appointments.Commands;
using Panase.Application.Feature.Appointments.Dtos;
using Panase.Application.Feature.Doctors.Commands;
using Panase.Application.Feature.Doctors.Dtos;
using Panase.Application.Feature.Patients.Commands;
using Panase.Application.Feature.Patients.Dtos;
using Panase.Application.Feature.Patients.Queries;
using Panase.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Application.Common.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Patient Mapping
            CreateMap<CreatePatientCommand, Patient>().ReverseMap();
            CreateMap<UpdatePatientCommand, Patient>().ReverseMap();

            // Entity -> DTO
            CreateMap<Patient, PatientDto>().ReverseMap();

            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentCommand>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentCommand>().ReverseMap();

            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorCommand>().ReverseMap();



        }
    }
}
