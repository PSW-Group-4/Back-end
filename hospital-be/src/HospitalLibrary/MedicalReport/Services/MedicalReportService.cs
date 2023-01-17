using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;
using System.IO;
using HospitalLibrary.AdmissionHistories.Model;
using Font = iTextSharp.text.Font;

namespace HospitalLibrary.MedicalReport.Services
{
    public class MedicalReportService : IMedicalRecordService
    {
        public byte[] GeneratePdf(AdmissionHistory admissionHistory)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                writer.Open();

                document.Open();


                Paragraph para1 = new Paragraph("Izvestaj za " + admissionHistory.Admission.Patient.Name + " " + admissionHistory.Admission.Patient.Surname, new Font(Font.FontFamily.HELVETICA, 20));
                para1.Alignment = Element.ALIGN_CENTER;
                para1.SpacingAfter = 10;
                document.Add(para1);

                Paragraph para2 = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 20));
                para2.Alignment = Element.ALIGN_CENTER;
                para2.SpacingAfter = 10;
                document.Add(para2);

                Paragraph para3 = new Paragraph("Datum prijema u bolnicu :" + admissionHistory.Admission.arrivalDate.Date.ToShortDateString(), new Font(Font.FontFamily.HELVETICA, 12));
                para3.Alignment = Element.ALIGN_LEFT;
                para3.SpacingAfter = 10;
                document.Add(para3);

                Paragraph para4 = new Paragraph("Razlog prijema u bolnicu :" + admissionHistory.Admission.ReasonText, new Font(Font.FontFamily.HELVETICA, 12));
                para4.Alignment = Element.ALIGN_LEFT;
                para4.SpacingAfter = 10;
                document.Add(para4);

                Paragraph para5 = new Paragraph("Broj sobe u bolnici :" + admissionHistory.Admission.Room.Number, new Font(Font.FontFamily.HELVETICA, 12));
                para5.Alignment = Element.ALIGN_LEFT;
                para5.SpacingAfter = 10;
                document.Add(para5);

                Paragraph para6 = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 20));
                para6.Alignment = Element.ALIGN_CENTER;
                para6.SpacingAfter = 10;
                document.Add(para6);

                Paragraph para7 = new Paragraph("Datum otpustanja iz bolnice :" + admissionHistory.DischargeDate.Date.ToShortDateString(), new Font(Font.FontFamily.HELVETICA, 12));
                para7.Alignment = Element.ALIGN_LEFT;
                para7.SpacingAfter = 10;
                document.Add(para7);

                Paragraph para8 = new Paragraph("Razlog otpustanja iz bolnice :" + admissionHistory.DischargeReason, new Font(Font.FontFamily.HELVETICA, 12));
                para8.Alignment = Element.ALIGN_LEFT;
                para8.SpacingAfter = 10;
                document.Add(para8);

                Paragraph para9 = new Paragraph(" ", new Font(Font.FontFamily.HELVETICA, 20));
                para9.Alignment = Element.ALIGN_CENTER;
                para9.SpacingAfter = 10;
                document.Add(para9);

                Paragraph para10 = new Paragraph("Tretman", new Font(Font.FontFamily.HELVETICA, 20));
                para10.Alignment = Element.ALIGN_CENTER;
                para10.SpacingAfter = 10;
                document.Add(para10);

                if(admissionHistory.Admission.Treatments.BloodConsumptionRecord != null)
                {
                    Paragraph para11 = new Paragraph("Kolicina krvi :" + admissionHistory.Admission.Treatments.BloodConsumptionRecord.Amount.Value + "ml", new Font(Font.FontFamily.HELVETICA, 12));
                    para11.Alignment = Element.ALIGN_LEFT;
                    para11.SpacingAfter = 10;
                    document.Add(para11);
                }
                
                if(admissionHistory.Admission.Treatments.Medicine != null)
                {
                    Paragraph para12 = new Paragraph("Lek koji je prepisan pacijentu :" + admissionHistory.Admission.Treatments.Medicine.Name, new Font(Font.FontFamily.HELVETICA, 12));
                    para12.Alignment = Element.ALIGN_LEFT;
                    para12.SpacingAfter = 10;
                    document.Add(para12);
                }
                

                document.Close();
                writer.Close();
                var constant = ms.ToArray();

                return constant;


            }
        }

    }
}
