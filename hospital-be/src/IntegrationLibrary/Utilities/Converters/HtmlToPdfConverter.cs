using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;

namespace IntegrationLibrary.Utilities.Converters
{
    public class HtmlToPdfConverter
    {
        public static string defaultPath = Directory.GetCurrentDirectory().ToString() + Path.DirectorySeparatorChar + "Reports" + Path.DirectorySeparatorChar;
        public static string Convert(string html, string path, string BloodBankTitle)
        {
            var Renderer = new ChromePdfRenderer();
            var pdf = Renderer.RenderHtmlAsPdf(html);
            path += BloodBankTitle + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
            pdf.SaveAs(path);
            return path;
        }
    }
}
