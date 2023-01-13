using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.Settings.Configurations
{
    public class MedicalAppointmentReportSessionConfiguration : IEntityTypeConfiguration<MedicalAppointmentReportSessionEvent>
    {
        public void Configure(EntityTypeBuilder<MedicalAppointmentReportSessionEvent> builder)
        {
            //Table per hierarchy strategy
            builder
                .ToTable("MedicalAppointmentReportSessionEvents")
                .HasDiscriminator<string>("Type")
                .HasValue<ChosenSymptom>("ChosenSymptom")
                .HasValue<ChosenReportText>("ChosenReportText")
                .HasValue<ChosenMedicine>("ChosenMedicine")
                .HasValue<FinishedScheduling>("FinishedScheduling")
                .HasValue<GoneBackToSelection>("GoneBackToSelection")
                .HasValue<StartedScheduling>("StartedScheduling");
        }
    }
}
