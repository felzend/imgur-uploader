using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ImgurFileUploader.Config
{
    public class FileUploadHandler
    {
        private ConfigurationHandler _configHandler;
        private List<string> _imageURLs = new List<string>();
        private string _clientId;
        private string _clientSecret;
        private string _postURL = "https://api.imgur.com/3/image";
        private double _uploadProgress = 0;
        private int _creditsRemaining = 0;
        private int _creditsLimit = 0;

        public List<string> Images
        {
            get => _imageURLs;
        }

        public double UploadProgress
        {
            set => _uploadProgress = 0;
            get => _uploadProgress;
        }

        public int CreditsRemaining
        {
            get => _creditsRemaining;
        }

        public int CreditsLimit
        {
            get => _creditsLimit;
        }

        public FileUploadHandler()
        {
            _configHandler = new ConfigurationHandler();
            _clientId = _configHandler.Settings["client_id"];
            _clientSecret = _configHandler.Settings["client_secret"];
        }

        private StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
        {
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "uploadfile",
                FileName = fileName
            };
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return fileContent;
        }


        public async void Upload(List<string> filePaths)
        {
            _imageURLs.Clear();

            for (int a = 0; a < filePaths.Count; a++)
            {
                var path = filePaths[a];

                using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", $"{_clientId}");
                    MultipartFormDataContent formData = new MultipartFormDataContent();

                    formData.Add(new StreamContent(fileStream, (int)fileStream.Length), "image", path.Split('\\').LastOrDefault() ?? $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}{Path.GetExtension(path)}");

                    var response = await client.PostAsync(_postURL, formData);
                    _creditsRemaining = int.Parse(response.Headers.GetValues("X-Post-Rate-Limit-Remaining").FirstOrDefault() ?? "0");
                    _creditsLimit = int.Parse(response.Headers.GetValues("X-Post-Rate-Limit-Limit").FirstOrDefault() ?? "0");

                    response.EnsureSuccessStatusCode();

                    string body = await response.Content.ReadAsStringAsync();
                    var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<ImgurResponse>(body);
                    _imageURLs.Add(responseData.Data.Link);

                    _uploadProgress = Math.Round((double)(a + 1) / (double)filePaths.Count * 100, 2);
                }

            }
        }
    }
}
