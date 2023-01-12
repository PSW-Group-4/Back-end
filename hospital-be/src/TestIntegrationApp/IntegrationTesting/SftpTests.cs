using System;
using IntegrationAPI;
using IntegrationAPI.Communications.SharedStorage;
using TestIntegrationApp.Setup;
using Xunit;

namespace TestIntegrationApp.IntegrationTesting
{
    public class SftpTests : BaseIntegrationTest
    {
        private SftpService _sftpService;
        public SftpTests(TestDatabaseFactory<Startup> factory) : base(factory)
        {
            
        }

        [Fact]
        public void Retrieves_Files()
        {
            Exception exception = Record.Exception(() => _sftpService.ListAll());
            Assert.Null(exception);
        }
        
        [Fact]
        public void Uploads_File()
        {
            Exception exception = Record.Exception(() => _sftpService.UploadFile(@"D:\PSW\Back-end\hospital-be\src\IntegrationAPI\Reports\Bankica202212162317008145.pdf", "/reports/Bankica202212162317008155.pdf"));
            Assert.Null(exception);
        }

        [Fact]
        public void Gets_File()
        {
            Exception exception = Record.Exception(() => _sftpService.DownloadFile(@"D:\PSW\Back-end\hospital-be\src\IntegrationAPI\Reports\BankicaReportFromSftpServer.pdf", "/reports/Bankica202212162317008155.pdf"));
            Assert.Null(exception);
        }
    }
}