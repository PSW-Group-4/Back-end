using Rebex.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Communications.SharedStorage
{
    public interface ISftpService
    {
        public SftpItemCollection ListAll();
        public void UploadFile(string localFilePath, string remoteFilePath);
        public void DownloadFile(string localFilePath, string remoteFilePath);
    }
}
