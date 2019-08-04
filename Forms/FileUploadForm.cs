using ImgurFileUploader.Config;
using ImgurFileUploader.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgurFileUploader.Forms
{
    public partial class FileUploadForm : Form
    {
        public static FileUploadHandler uploadHandler;

        private List<string> _filesToUpload = new List<string>();
        
        public FileUploadForm()
        {
            try
            {
                InitializeComponent();
                MaximizeBox = false;

                reportBox.ReadOnly = true;
                fileUploadDialog.Filter = "Image Files(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png|All files (*.*)|*.*";
                fileUploadDialog.Multiselect = true;
                fileUploadDialog.FileOk += FileUploadDialog_FilesOk;
                uploadWorker.ProgressChanged += UploadWorker_ProgressChanged;
                uploadWorker.RunWorkerCompleted += UploadWorker_Completed;
                uploadHandler = new FileUploadHandler();                
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show($"{ex.StackTrace}.", "Falha ao carregar arquivos de configuracoes");
                System.Environment.Exit(500);
            }
            catch (MissingCredentialsException ex)
            {
                MessageBox.Show($"{ex.Message}", "Falha ao carregar credenciais do Imgur");
                System.Environment.Exit(500);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.StackTrace, "Erro Fatal");
                System.Environment.Exit(500);
            }
        }       

        private void FileUploadButton_Click(object sender, EventArgs e)
        {
            fileUploadDialog.ShowDialog();
        }

        private void FileUploadDialog_FilesOk(object sender, EventArgs e)
        {
            
            try
            {
                _filesToUpload.Clear();
                _filesToUpload = fileUploadDialog.FileNames.ToList();
                if (_filesToUpload.Count < 1)
                {
                    MessageBox.Show("Escolha pelo menos um arquivo para fazer upload.", "Falha ao realizar upload");
                    return;
                }

                FileUploadButton.Enabled = false;
                uploadHandler.Upload(_filesToUpload);
                uploadWorker.RunWorkerAsync();                
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"{ex.Message}", "Falha ao realizar upload");
                FileUploadButton.Enabled = true;
                uploadWorker.CancelAsync();
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show($"{ex.Message}", "Falha ao realizar upload - Arquivo invalido");
                FileUploadButton.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} - {ex.StackTrace}", "Falha ao realizar upload");
                FileUploadButton.Enabled = true;
            }            
        }

        private void UploadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (uploadProgressBar.Value >= 100)
                {
                    uploadWorker.CancelAsync();
                    return;
                }

                if (uploadProgressBar.Value != uploadHandler.UploadProgress)
                {
                    uploadWorker.ReportProgress((int)uploadHandler.UploadProgress);
                }
            }
        }

        private void UploadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uploadProgressBar.Value = e.ProgressPercentage;
        }

        private void UploadWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            uploadHandler.Images.ForEach(x =>
            {
                reportBox.Text += $"{x}\n\n";
            });

            creditsLabel.Text = $"Creditos Restantes: {uploadHandler.CreditsRemaining} / Limite de Credito Por Dia: {uploadHandler.CreditsLimit}";
            numberOfLinksLabel.Text = $"Numero de Imagens/Links abaixo: {_filesToUpload.Count}";
            uploadHandler.UploadProgress = 0;
            uploadProgressBar.Value = 0;
            FileUploadButton.Enabled = true;
            MessageBox.Show($"Upload finalizado. {uploadHandler.Images.Count} de {_filesToUpload.Count} imagens foram enviadas com sucesso.");
        }

        private void ButtonCopyLinks_Click(object sender, EventArgs e)
        {
            if (reportBox.Text.Length > 0)
                Clipboard.SetText(reportBox.Text);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            reportBox.Text = string.Empty;
            numberOfLinksLabel.Text = string.Empty;
            _filesToUpload.Clear();
        }

        private void FileUploadForm_Load(object sender, EventArgs e)
        {
            creditsLabel.Text = string.Empty;
            numberOfLinksLabel.Text = string.Empty;
        }

        private void WrapTagsButton_Click(object sender, EventArgs e)
        {
            if (reportBox.Text.Length > 0)
            {
                reportBox.Text = string.Join("\n", reportBox.Text.Split('\n').Select(line =>
                {
                    if (line.Length > 0)
                    {
                        if (Regex.Match(line, "\\[IMG]|\\[/IMG]").Success)
                        {
                            return Regex.Replace(line, "\\[IMG]|\\[\\/IMG]", string.Empty);
                        }

                        return $"[IMG]{line}[/IMG]";
                    }

                    return line;
                }));
            }
        }
    }
}
