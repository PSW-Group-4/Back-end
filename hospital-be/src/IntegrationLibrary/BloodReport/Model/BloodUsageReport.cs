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

        public string GenerateHtml()
        {
            string html = "" +
                Environment.NewLine + "<h1>Blood Usage Report</h1>" +
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
            html = string.Format(html,this.BloodBank.Name,this.timeOfCreation.ToString(),this.ReportConfiguration.RequestFrequency.ToString());
            html = "<html><head><style>body{background-color:#bbf6fc; color: black; font-family: Arial, Helvetica, sans-serif; display:flex; flex-direction: column; align-items: center;}table{border-collapse: collapse;} table td{padding: .5em;} table th{padding: .5em;} table tr{ border-bottom: 2px solid lightslategray;}</style></head><body>" + html;
            foreach (BloodUsageDto bloodUsage in BloodUsage)
            {
                html += Environment.NewLine + "\t<tr>" +
                        Environment.NewLine + "\t\t<td>" + bloodUsage.BloodType.BloodGroup.ToString() + "</td>" +
                        Environment.NewLine + "\t\t<td>" + bloodUsage.BloodType.RhFactor.ToString() + "</td>" +
                        Environment.NewLine + "\t\t<td>" + bloodUsage.Milliliters.ToString() + "</td>" +
                        Environment.NewLine + "\t</tr>";
            }

            html += Environment.NewLine + "</table> </body> </html>";
            return html;
        }
    }
}
