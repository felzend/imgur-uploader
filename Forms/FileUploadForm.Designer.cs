namespace ImgurFileUploader.Forms
{
    partial class FileUploadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileUploadForm));
            this.fileUploadDialog = new System.Windows.Forms.OpenFileDialog();
            this.FileUploadButton = new System.Windows.Forms.Button();
            this.uploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.reportBox = new System.Windows.Forms.RichTextBox();
            this.uploadWorker = new System.ComponentModel.BackgroundWorker();
            this.creditsLabel = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCopyLinks = new System.Windows.Forms.Button();
            this.numberOfLinksLabel = new System.Windows.Forms.Label();
            this.wrapTagsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileUploadDialog
            // 
            this.fileUploadDialog.FileName = "openFileDialog1";
            // 
            // FileUploadButton
            // 
            this.FileUploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileUploadButton.Location = new System.Drawing.Point(40, 73);
            this.FileUploadButton.Name = "FileUploadButton";
            this.FileUploadButton.Size = new System.Drawing.Size(394, 33);
            this.FileUploadButton.TabIndex = 0;
            this.FileUploadButton.Text = "Escolher Arquivos";
            this.FileUploadButton.UseVisualStyleBackColor = true;
            this.FileUploadButton.Click += new System.EventHandler(this.FileUploadButton_Click);
            // 
            // uploadProgressBar
            // 
            this.uploadProgressBar.Location = new System.Drawing.Point(40, 402);
            this.uploadProgressBar.Name = "uploadProgressBar";
            this.uploadProgressBar.Size = new System.Drawing.Size(394, 23);
            this.uploadProgressBar.TabIndex = 1;
            // 
            // reportBox
            // 
            this.reportBox.Location = new System.Drawing.Point(40, 209);
            this.reportBox.Name = "reportBox";
            this.reportBox.Size = new System.Drawing.Size(394, 168);
            this.reportBox.TabIndex = 2;
            this.reportBox.Text = "";
            // 
            // uploadWorker
            // 
            this.uploadWorker.WorkerReportsProgress = true;
            this.uploadWorker.WorkerSupportsCancellation = true;
            this.uploadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UploadWorker_DoWork);
            // 
            // creditsLabel
            // 
            this.creditsLabel.AutoSize = true;
            this.creditsLabel.Enabled = false;
            this.creditsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsLabel.Location = new System.Drawing.Point(40, 32);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(348, 16);
            this.creditsLabel.TabIndex = 3;
            this.creditsLabel.Text = "Creditos Restantes: 1000 / Limite de Credito Por Dia: 1250";
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(316, 123);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(118, 29);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Limpar";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // buttonCopyLinks
            // 
            this.buttonCopyLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopyLinks.Location = new System.Drawing.Point(40, 123);
            this.buttonCopyLinks.Name = "buttonCopyLinks";
            this.buttonCopyLinks.Size = new System.Drawing.Size(123, 29);
            this.buttonCopyLinks.TabIndex = 5;
            this.buttonCopyLinks.Text = "Copiar Links";
            this.buttonCopyLinks.UseVisualStyleBackColor = true;
            this.buttonCopyLinks.Click += new System.EventHandler(this.ButtonCopyLinks_Click);
            // 
            // numberOfLinksLabel
            // 
            this.numberOfLinksLabel.AutoSize = true;
            this.numberOfLinksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfLinksLabel.Location = new System.Drawing.Point(40, 181);
            this.numberOfLinksLabel.Name = "numberOfLinksLabel";
            this.numberOfLinksLabel.Size = new System.Drawing.Size(243, 16);
            this.numberOfLinksLabel.TabIndex = 6;
            this.numberOfLinksLabel.Text = "Numero de Imagens/Links abaixo: 1000";
            // 
            // wrapTagsButton
            // 
            this.wrapTagsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wrapTagsButton.Location = new System.Drawing.Point(178, 123);
            this.wrapTagsButton.Name = "wrapTagsButton";
            this.wrapTagsButton.Size = new System.Drawing.Size(123, 29);
            this.wrapTagsButton.TabIndex = 7;
            this.wrapTagsButton.Text = "[IMG] [/IMG]";
            this.wrapTagsButton.UseVisualStyleBackColor = true;
            this.wrapTagsButton.Click += new System.EventHandler(this.WrapTagsButton_Click);
            // 
            // FileUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 437);
            this.Controls.Add(this.wrapTagsButton);
            this.Controls.Add(this.numberOfLinksLabel);
            this.Controls.Add(this.buttonCopyLinks);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.creditsLabel);
            this.Controls.Add(this.reportBox);
            this.Controls.Add(this.uploadProgressBar);
            this.Controls.Add(this.FileUploadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileUploadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uploader de Imagens - Imgur";
            this.Load += new System.EventHandler(this.FileUploadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileUploadDialog;
        private System.Windows.Forms.Button FileUploadButton;
        private System.Windows.Forms.ProgressBar uploadProgressBar;
        private System.Windows.Forms.RichTextBox reportBox;
        private System.ComponentModel.BackgroundWorker uploadWorker;
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCopyLinks;
        private System.Windows.Forms.Label numberOfLinksLabel;
        private System.Windows.Forms.Button wrapTagsButton;
    }
}

