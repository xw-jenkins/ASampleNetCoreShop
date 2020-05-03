namespace ASample.NetCore.FileStorage.Api
{
    public class FileDto
    {
        public string Host { get; set; }
        public string Dir { get; set; }
        public string Token { get; set; }
        public string AccessKeyId { get; set; }
        public string Signature { get; set; }

        public string FileFullPath { get; set; }
    }
}
