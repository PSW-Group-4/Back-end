using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.Settings.Configurations
{
    public class ChosenDoctorConfiguration : IEntityTypeConfiguration<ChosenDoctor>
    {
        public void Configure(EntityTypeBuilder<ChosenDoctor> builder)
        {
            builder.Navigation(cd => cd.Doctor).AutoInclude();
        }
    }
}