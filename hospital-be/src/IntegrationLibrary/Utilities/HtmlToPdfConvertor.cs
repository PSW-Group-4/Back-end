using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPdf;

namespace IntegrationLibrary.Utilities
{
    public class HtmlToPdfConvertor
    {
        public static String Convert(String html, String path, String BloodBankTitle)
        {
            var Renderer = new IronPdf.ChromePdfRenderer();
            var pdf = Renderer.RenderHtmlAsPdf(html);
            path += BloodBankTitle + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf";
            pdf.SaveAs(path);
            return path;
        }
    }
}
