using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgurFileUploader.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace ImgurFileUploader.Config
{
    public class ConfigurationHandler
    {
        private IConfigurationRoot _configuration;
        private List<string> credentialsField = new List<string> { "client_id", "client_secret" };
        private string settingsFile = "Config/appsettings.json";

        public ConfigurationHandler()
        {
            try
            {
                var builder = new ConfigurationBuilder().AddJsonFile(settingsFile);
                var configuration = builder.Build();
                _configuration = configuration;

                if (credentialsField.Any(x => string.IsNullOrEmpty(configuration[x])))
                    throw new MissingCredentialsException($"Falha ao carregar credenciais de acesso ao Imgur. Preencha os seguintes campos no arquivo de configuracoes {settingsFile}: \n\n{string.Join(", ", credentialsField.ToArray())}");
            }
            catch(FileNotFoundException ex)
            {
                throw new System.IO.FileNotFoundException($"Falha ao carregar arquivo de configuracoes {settingsFile}. Verifique se o arquivo existe.");
            }
            catch(MissingCredentialsException ex)
            {
                throw new MissingCredentialsException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IConfigurationRoot Settings
        {
            get => _configuration;
        }
    }
}
