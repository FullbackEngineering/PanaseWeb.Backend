using AutoMapper;
using Panase.Application.Features.Appointments.Commands;
using Panase.Application.Features.Appointments.Dtos;
using Panase.Application.Features.Doctors.Commands;
using Panase.Application.Features.Doctors.Dtos;
using Panase.Application.Features.Patients.Commands;
using Panase.Application.Features.Patients.Dtos;
using Panase.Application.Features.Patients.Queries;
using Panase.Application.Features.SessionNotes.Commands;
using Panase.Application.Features.SessionNotes.Dtos;
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

            CreateMap<SessionNote, SessionNoteDto>().ReverseMap();
            CreateMap<SessionNote, CreateSessionNoteCommand>().ReverseMap();
            CreateMap<SessionNote, UpdateSessionNoteCommand>().ReverseMap();



        }
    }
}
