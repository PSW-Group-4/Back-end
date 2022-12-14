using HospitalLibrary.AdmissionHistories.Model;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Prescriptions.Model;

namespace HospitalLibrary.AppointmentReport.Service
{
    public class AppointmentReportService : IAppointmentReportService
    {
        public byte[] GeneratePdf(Report report,List<String> settings)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                writer.Open();

                document.Open();
                String[] setting = settings[0].Split(",");
                if (setting.Contains("pacijent"))
                {
                    Paragraph para1 = new Paragraph("Izvestaj za " + report.MedicalAppointment.Patient.Name + " " + report.MedicalAppointment.Patient.Surname, new Font(Font.FontFamily.HELVETICA, 20));
                    para1.Alignment = Element.ALIGN_CENTER;
                    para1.SpacingAfter = 10;
                    document.Add(para1);
                }

                Paragraph para2 = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 20));
                para2.Alignment = Element.ALIGN_CENTER;
                para2.SpacingAfter = 10;
                document.Add(para2);

                if (setting.Contains("simptomi"))
                {
                    String simp = "";
                    foreach (Symptom s in report.Symptoms)
                    {
                        simp = simp + "," + s.Name;
                    }
                    Paragraph para3 = new Paragraph("Simptomi su :" + simp, new Font(Font.FontFamily.HELVETICA, 12));
                    para3.Alignment = Element.ALIGN_LEFT;
                    para3.SpacingAfter = 10;
                    document.Add(para3);
                }
                if (setting.Contains("dijagnoza"))
                {
                    Paragraph para4 = new Paragraph("Dijagnoza :" + report.Text, new Font(Font.FontFamily.HELVETICA, 12));
                    para4.Alignment = Element.ALIGN_LEFT;
                    para4.SpacingAfter = 10;
                    document.Add(para4);
                }

                if (setting.Contains("lek"))
                {
                    String lek = "";
                    foreach (Prescription s in report.Prescriptions)
                    {
                        foreach (Medicine m in s.Medicines)
                            lek = lek + "," + m.Name;
                    }
                    Paragraph para5 = new Paragraph("Lekovi koji su prepisani :" + lek, new Font(Font.FontFamily.HELVETICA, 12));
                    para5.Alignment = Element.ALIGN_LEFT;
                    para5.SpacingAfter = 10;
                    document.Add(para5);
                }

                Paragraph para6 = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 20));
                para6.Alignment = Element.ALIGN_CENTER;
                para6.SpacingAfter = 10;
                document.Add(para6);

                Paragraph para7 = new Paragraph("Datum pregleda :" + report.MedicalAppointment.DateRange.StartTime.ToShortDateString(), new Font(Font.FontFamily.HELVETICA, 12));
                para7.Alignment = Element.ALIGN_LEFT;
                para7.SpacingAfter = 10;
                document.Add(para7);

                Paragraph para9 = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 20));
                para9.Alignment = Element.ALIGN_CENTER;
                para9.SpacingAfter = 10;
                document.Add(para9);

                document.Close();
                writer.Close();
                var constant = ms.ToArray();

                return constant;


            }
        }
    }
}
