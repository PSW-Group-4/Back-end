using IntegrationLibrary.Utilities.Converters;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.UnitTesting.BloodUsageTests
{
    public class HtmToSavedPdfTest
    {
        [Fact]
        public void Checks_if_pdf_exists()
        {
            string testHtml = System.IO.File.ReadAllText(Directory.GetCurrentDirectory().ToString() + @"./UnitTesting/BloodUsageTests/BRHtmlTest.txt");
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).ToString() + Path.DirectorySeparatorChar + "Reports" + Path.DirectorySeparatorChar;
            string pdfPath = HtmlToPdfConverter.Convert(testHtml, path,"TestBank");

            bool exists = System.IO.File.Exists(pdfPath);
            exists.ShouldBe(true);
        }
    }
}
