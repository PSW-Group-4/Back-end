using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Renci.SshNet.Sftp;

using Rebex.Net;

namespace IntegrationAPI.Communications.SharedStorage
{
    public class SftpService : ISftpService
    {
        //private readonly SftpConfig _config;
        private readonly Sftp _client;

        public SftpService()//SftpConfig sftpConfig)
        {
           // _config = sftpConfig;
            Rebex.Licensing.Key = "==AFeeZVSzy8xk4CHcnI9hkMoxe6IW+JSJ/2DJeRjjBAuM==";
            _client = new Rebex.Net.Sftp();
            SetupClient();
        }

        ~SftpService()
        {
          _client.Disconnect();  
        }

        public void SetupClient()
        {
            _client.Connect("localhost");
            _client.Login("psw", "psw");
            if (!_client.DirectoryExists("/reports"))
                _client.CreateDirectory("/reports");
        }

        public SftpItemCollection ListAll()
        {
            return _client.GetList();
        }

        public void UploadFile(string localFilePath, string remoteFilePath)
        {
            _client.PutFile(localFilePath, remoteFilePath);
        }

        public void DownloadFile(string localFilePath, string remoteFilePath)
        {
            _client.GetFile(remoteFilePath, localFilePath);
        }
    }
}