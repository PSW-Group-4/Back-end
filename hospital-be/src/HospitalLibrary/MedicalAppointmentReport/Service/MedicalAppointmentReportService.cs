using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.AppointmentReport.Model;
using iTextSharp.text.pdf.draw;
using System.Reflection.Metadata;

namespace HospitalLibrary.AppointmentReport.Service
{
    public class MedicalAppointmentReportService : IMedicalAppointmentReportService
    {
        private BaseColor mainColor = new BaseColor(System.Drawing.Color.DarkBlue);

        public byte[] GeneratePdf(MedicalAppointmentReport medicalAppointmentReport)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Rectangle documentPage = new Rectangle(PageSize.A4);
                documentPage.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);

                //Fonts
                Font titleFont = FontFactory.GetFont("Segoe UI", 22, iTextSharp.text.Font.BOLD,
                    mainColor);
                Font elementFont = FontFactory.GetFont("Segoe UI", 14, iTextSharp.text.Font.BOLD,
                    mainColor);

                iTextSharp.text.Document document = new iTextSharp.text.Document(documentPage, 75, 75, 40, 40);

                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                writer.Open();
                document.Open();

                PdfContentByte cb = writer.DirectContent;

                DrawBorders(cb, document);
                //AddLogo(document);

                AddHorizontalSpace(document, titleFont);

                Image logo = Image.GetInstance("../HospitalLibrary/Images/health-check.png");
                Chunk image = new Chunk(logo, -55f, 0, true);
                Chunk title = new Chunk("Appointment report", titleFont);

                Paragraph par = new Paragraph();
                par.Add(image);
                par.Add(title);

                par.Alignment = Element.ALIGN_CENTER;
                par.SpacingAfter = 30;
                document.Add(par);

                String[] setting = medicalAppointmentReport.Settings[0].Split(",");
                if (setting.Contains("pacijent"))
                {
                    Paragraph para2 = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 20));
                    para2.Alignment = Element.ALIGN_CENTER;
                    para2.SpacingAfter = 51;
                    AddSeparator(para2, true);

                    document.Add(para2);
                }

                Chunk pat1 = new Chunk("Patient: ", elementFont);
                Chunk pat2 = new Chunk(medicalAppointmentReport.Report.MedicalAppointment.Patient.Name + " " +
                    medicalAppointmentReport.Report.MedicalAppointment.Patient.Surname, new Font(Font.FontFamily.HELVETICA, 12));

                Paragraph para1 = new Paragraph();
                para1.Add(pat1);
                para1.Add(pat2);
                para1.Alignment = Element.ALIGN_LEFT;
                para1.SpacingAfter = 40;
                AddSeparator(para1, false);

                document.Add(para1);

                if (setting.Contains("simptomi"))
                {
                    String simp = "";
                    foreach (Symptom s in medicalAppointmentReport.Report.Symptoms)
                    {
                        simp = simp + s.Name + ", ";
                    }

                    if (!simp.Equals("")) {
                        simp = simp.TrimEnd(' ');
                        simp = simp.TrimEnd(',');
                    }

                    Chunk simp1 = new Chunk("Symptoms: ", elementFont);
                    Chunk simp2 = new Chunk(simp, new Font(Font.FontFamily.HELVETICA, 12));

                    Paragraph para3 = new Paragraph();
                    para3.Add(simp1);
                    para3.Add(simp2);
                    para3.Alignment = Element.ALIGN_LEFT;
                    para3.SpacingAfter = 40;
                    AddSeparator(para3, false);

                    document.Add(para3);
                }
                if (setting.Contains("dijagnoza"))
                {
                    Chunk diag1 = new Chunk("Diagnosis: ", elementFont);
                    Chunk diag2 = new Chunk(medicalAppointmentReport.Report.Text, new Font(Font.FontFamily.HELVETICA, 12));

                    Paragraph para4 = new Paragraph();
                    para4.Add(diag1);
                    para4.Add(diag2);
                    para4.Alignment = Element.ALIGN_JUSTIFIED;
                    para4.SpacingAfter = 40;
                    AddSeparator(para4, false);

                    document.Add(para4);
                }

                if (setting.Contains("lek"))
                {
                    String lek = "";
                    foreach (Prescription s in medicalAppointmentReport.Report.Prescriptions)
                    {
                        foreach (Medicine m in s.Medicines)
                            lek = lek + m.Name + ", ";
                    }

                    if (!lek.Equals(""))
                    {
                        lek = lek.TrimEnd(' ');
                        lek = lek.TrimEnd(',');
                    }

                    Chunk med1 = new Chunk("Prescribed medicine: ", elementFont);
                    Chunk med2 = new Chunk(lek, new Font(Font.FontFamily.HELVETICA, 12));

                    Paragraph para5 = new Paragraph();
                    para5.Add(med1);
                    para5.Add(med2);
                    para5.Alignment = Element.ALIGN_LEFT;
                    para5.SpacingAfter = 40;
                    AddSeparator(para5, false);

                    document.Add(para5);

                    Paragraph para6 = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 20));
                    para6.Alignment = Element.ALIGN_CENTER;
                    para6.SpacingAfter = 51;
                    document.Add(para6);
                }

                Chunk doc1 = new Chunk("Doctor: ", elementFont);
                doc1.SetUnderline(0.5f, -1.5f);
                Chunk doc2 = new Chunk(medicalAppointmentReport.Report.MedicalAppointment.Doctor.Name + " " +
                    medicalAppointmentReport.Report.MedicalAppointment.Doctor.Surname, new Font(Font.FontFamily.HELVETICA, 12));
                doc2.SetUnderline(0.5f, -1.5f);

                Chunk space = new Chunk("               ");

                Chunk date1 = new Chunk("Date: ", elementFont);
                date1.SetUnderline(0.5f, -1.5f);

                Chunk date2 = new Chunk(medicalAppointmentReport.Report.MedicalAppointment.DateRange.StartTime.ToShortDateString()
                    , new Font(Font.FontFamily.HELVETICA, 12));
                date2.SetUnderline(0.5f, -1.5f);

                Paragraph para7 = new Paragraph();

                para7.Add(doc1);
                para7.Add(doc2);
                para7.Add(space);
                para7.Add(date1);
                para7.Add(date2);

                para7.Alignment = Element.ALIGN_RIGHT;
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

        private void AddLogo(iTextSharp.text.Document document)
        {
            Image logo = Image.GetInstance("../HospitalLibrary/Images/health-check.png");
            document.Add(logo);
        }

        private static void AddHorizontalSpace(iTextSharp.text.Document document, Font titleFont)
        {
            Paragraph whiteSpace = new Paragraph(" ", titleFont);
            whiteSpace.SpacingAfter = 10;
            document.Add(whiteSpace);
        }

        private void DrawBorders(PdfContentByte cb, iTextSharp.text.Document document)
        {
            cb.SetColorStroke(mainColor);

            //Left border
            cb.MoveTo(document.PageSize.Width / 14, document.PageSize.Height / 15);
            cb.LineTo(document.PageSize.Width / 14, document.PageSize.Height * 14 / 15);
            cb.Stroke();

            //Right border
            cb.MoveTo(document.PageSize.Width * 13 / 14, document.PageSize.Height / 15);
            cb.LineTo(document.PageSize.Width * 13 / 14, document.PageSize.Height * 14 / 15);
            cb.Stroke();

            //Top border
            cb.MoveTo(document.PageSize.Width / 14, document.PageSize.Height * 14 / 15);
            cb.LineTo(document.PageSize.Width * 13 / 14, document.PageSize.Height * 14 / 15);
            cb.Stroke();

            //Bottom border
            cb.MoveTo(document.PageSize.Width / 14, document.PageSize.Height / 15);
            cb.LineTo(document.PageSize.Width * 13 / 14, document.PageSize.Height / 15);
            cb.Stroke();
        }

        private void AddSeparator(Paragraph p, bool isHeader)
        {
            DottedLineSeparator line = new DottedLineSeparator();
            line.Gap = 0f;
            line.Alignment = Element.ALIGN_CENTER;
            line.LineColor = mainColor;

            if (isHeader)
            {   
                line.Offset = 20;
                line.LineWidth = 2f;
            }
            else
            {
                line.Offset = -10f;
                line.LineWidth = 0.8f;
            }

            p.Add(line);
            return;
        }
    }
}
