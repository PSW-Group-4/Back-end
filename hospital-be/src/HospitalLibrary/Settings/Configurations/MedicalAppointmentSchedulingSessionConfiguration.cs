using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.Settings.Configurations
{
    public class MedicalAppointmentSchedulingSessionConfiguration : IEntityTypeConfiguration<MedicalAppointmentSchedulingSessionEvent>
    {
        public void Configure(EntityTypeBuilder<MedicalAppointmentSchedulingSessionEvent> builder)
        {
            //Table per hierarchy strategy
            builder
                .ToTable("MedicalAppointmentSchedulingSessionEvents")
                .HasDiscriminator<string>("Type")
                .HasValue<ChosenDate>("ChosenDate")
                .HasValue<ChosenDoctor>("ChosenDoctor")
                .HasValue<ChosenSpeciality>("ChosenSpeciality")
                .HasValue<FinishedScheduling>("FinishedScheduling")
                .HasValue<GoneBackToSelection>("GoneBackToSelection")
                .HasValue<StartedScheduling>("StartedScheduling");
        }
    }
}