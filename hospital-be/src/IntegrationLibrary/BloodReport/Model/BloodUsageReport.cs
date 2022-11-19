using IntegrationLibrary.BloodUsages.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    [Table("blood_usage_report")]
    public class BloodUsageReport
    {
        public Guid Id { get; set; }
        public virtual BloodBank BloodBank { get; set; }
        public virtual ReportConfiguration ReportConfiguration { get; set; }
        [NotMapped]
        public List<BloodUsageDto> BloodUsage { get; set; }
        public DateTime timeOfCreation { get; set; }

        public String GenerateHtml()
        {
            String html = "<h1>Blood Usage Report</h1>" +
                Environment.NewLine + "<h2>Bank: {0}</h2>" +
                Environment.NewLine + "<h2>Date: {1}</h2>" +
                Environment.NewLine + "<h2>Frequency: {2}</h2>" +
                Environment.NewLine +
                Environment.NewLine + "<table>" +
                Environment.NewLine + "\t<tr>" +
                Environment.NewLine + "\t\t<th>Blood type</th>" +
                Environment.NewLine + "\t\t<th>RH factor</th>" +
                Environment.NewLine + "\t\t<th>Amount(ml)</th>" +
                Environment.NewLine + "\t</tr>";
            html = String.Format(html,this.BloodBank.Name,this.timeOfCreation.ToString(),this.ReportConfiguration.RequestFrequency.ToString());

            foreach (BloodUsageDto bloodUsage in BloodUsage)
            {
                html += Environment.NewLine + "\t<tr>" +
                        Environment.NewLine + "\t\t<td>" + bloodUsage.Type.ToString() + "</td>" +
                        Environment.NewLine + "\t\t<td>" + bloodUsage.RHFactor.ToString() + "</td>" +
                        Environment.NewLine + "\t\t<td>" + bloodUsage.Milliliters.ToString() + "</td>" +
                        Environment.NewLine + "\t</tr>";
            }

            html += Environment.NewLine + "</table>";
            return html;
        }
    }
}
