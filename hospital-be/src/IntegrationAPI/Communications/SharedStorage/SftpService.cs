using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace IntegrationAPI.Communications.SharedStorage
{
    public class SftpService
    {
        private readonly SftpConfig _config;

        public SftpService(SftpConfig sftpConfig)
        {
            _config = sftpConfig;
        }

        public void Connect()
        {
            using SftpClient client = new(_config.Host, _config.Username, _config.Password);
            try
            {
                client.Connect();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Connection failed.");
            }
        }

        public IEnumerable<SftpFile> ListAllFiles(string remoteDirectory = ".")
        {
            using SftpClient client = new(_config.Host, _config.Username, _config.Password);
            try
            {
                client.Connect();
                return client.ListDirectory(remoteDirectory);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Failed in listing files under [{remoteDirectory}]");
                return null;
            }
            finally
            {
                client.Disconnect();
            }
        }

        public void UploadFile(string localFilePath, string remoteFilePath)
        {
            using SftpClient client = new(_config.Host, _config.Username, _config.Password);
            try
            {
                client.Connect();
                using FileStream s = File.OpenRead(localFilePath);
                client.UploadFile(s, remoteFilePath);
                Console.WriteLine($"Finished uploading file [{localFilePath}] to [{remoteFilePath}]");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Failed in uploading file [{localFilePath}] to [{remoteFilePath}]");
            }
            finally
            {
                client.Disconnect();
            }
        }

        public void DownloadFile(string remoteFilePath, string localFilePath)
        {
            using SftpClient client = new(_config.Host, _config.Username, _config.Password);
            try
            {
                client.Connect();
                using FileStream s = File.Create(localFilePath);
                client.DownloadFile(remoteFilePath, s);
                Console.WriteLine($"Finished downloading file [{localFilePath}] from [{remoteFilePath}]");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Failed in downloading file [{localFilePath}] from [{remoteFilePath}]");;
            }
            finally
            {
                client.Disconnect();
            }
        }

        public void DeleteFile(string remoteFilePath)
        {
            using SftpClient client = new(_config.Host, _config.Username, _config.Password);
            try
            {
                client.Connect();
                client.DeleteFile(remoteFilePath);
                Console.WriteLine($"File [{remoteFilePath}] deleted.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Failed in deleting file [{remoteFilePath}]");
            }
            finally
            {
                client.Disconnect();
            }
        }
    }
}