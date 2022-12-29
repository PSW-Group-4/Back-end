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
            _sftpService = new SftpService(new SftpConfig());
        }
        
        [Fact]
        public void Connection_Successful()
        {
            Exception exception = Record.Exception(() => _sftpService.Connect());
            Assert.Null(exception);
        }

        [Fact]
        public void Retrieves_Files()
        {
            Exception exception = Record.Exception(() => _sftpService.ListAllFiles());
            Assert.Null(exception);
        }
        
        [Fact]
        public void Uploads_File()
        {
            Exception exception = Record.Exception(() => _sftpService.UploadFile("./Reports/Bankica202212162317008145.pdf", "/Reports/Bankica202212162317008145.pdf"));
            Assert.Null(exception);
        }
    }
}