namespace ImageCrypto
{
    partial class MainWindow
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
            this.PlaintextImageGroupbox = new System.Windows.Forms.GroupBox();
            this.FDEncryptButton = new System.Windows.Forms.Button();
            this.CAEncryptButton = new System.Windows.Forms.Button();
            this.BioEncryptButton = new System.Windows.Forms.Button();
            this.PlaintextFeaturesButton = new System.Windows.Forms.Button();
            this.PlaintextSpectraButton = new System.Windows.Forms.Button();
            this.PlaintextHistogramButton = new System.Windows.Forms.Button();
            this.PlaintextCorrelationButton = new System.Windows.Forms.Button();
            this.PlainText_Image = new System.Windows.Forms.PictureBox();
            this.OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.CiphertextImageGroupbox = new System.Windows.Forms.GroupBox();
            this.EncryptionTimeLabel = new System.Windows.Forms.Label();
            this.CiphertextFeaturesButton = new System.Windows.Forms.Button();
            this.CiphertextSpectraButton = new System.Windows.Forms.Button();
            this.CiphertextHistogramButton = new System.Windows.Forms.Button();
            this.CiphertextCorrelationButton = new System.Windows.Forms.Button();
            this.Ciphertext_Image = new System.Windows.Forms.PictureBox();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.MemoryUsageLabel = new System.Windows.Forms.Label();
            this.PlaintextImageGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlainText_Image)).BeginInit();
            this.CiphertextImageGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ciphertext_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // PlaintextImageGroupbox
            // 
            this.PlaintextImageGroupbox.Controls.Add(this.FDEncryptButton);
            this.PlaintextImageGroupbox.Controls.Add(this.CAEncryptButton);
            this.PlaintextImageGroupbox.Controls.Add(this.BioEncryptButton);
            this.PlaintextImageGroupbox.Controls.Add(this.PlaintextFeaturesButton);
            this.PlaintextImageGroupbox.Controls.Add(this.PlaintextSpectraButton);
            this.PlaintextImageGroupbox.Controls.Add(this.PlaintextHistogramButton);
            this.PlaintextImageGroupbox.Controls.Add(this.PlaintextCorrelationButton);
            this.PlaintextImageGroupbox.Controls.Add(this.PlainText_Image);
            this.PlaintextImageGroupbox.Location = new System.Drawing.Point(12, 37);
            this.PlaintextImageGroupbox.Name = "PlaintextImageGroupbox";
            this.PlaintextImageGroupbox.Size = new System.Drawing.Size(499, 297);
            this.PlaintextImageGroupbox.TabIndex = 14;
            this.PlaintextImageGroupbox.TabStop = false;
            this.PlaintextImageGroupbox.Text = "Plaintext Image";
            // 
            // FDEncryptButton
            // 
            this.FDEncryptButton.Enabled = false;
            this.FDEncryptButton.Location = new System.Drawing.Point(296, 244);
            this.FDEncryptButton.Name = "FDEncryptButton";
            this.FDEncryptButton.Size = new System.Drawing.Size(177, 23);
            this.FDEncryptButton.TabIndex = 11;
            this.FDEncryptButton.Text = "Fluid Dynamics Encryption";
            this.FDEncryptButton.UseVisualStyleBackColor = true;
            this.FDEncryptButton.Click += new System.EventHandler(this.FDEncryptButton_Click);
            // 
            // CAEncryptButton
            // 
            this.CAEncryptButton.Enabled = false;
            this.CAEncryptButton.Location = new System.Drawing.Point(296, 215);
            this.CAEncryptButton.Name = "CAEncryptButton";
            this.CAEncryptButton.Size = new System.Drawing.Size(177, 23);
            this.CAEncryptButton.TabIndex = 10;
            this.CAEncryptButton.Text = "Cellular Automata Encryption";
            this.CAEncryptButton.UseVisualStyleBackColor = true;
            this.CAEncryptButton.Click += new System.EventHandler(this.CAEncryptButton_Click);
            // 
            // BioEncryptButton
            // 
            this.BioEncryptButton.Enabled = false;
            this.BioEncryptButton.Location = new System.Drawing.Point(296, 186);
            this.BioEncryptButton.Name = "BioEncryptButton";
            this.BioEncryptButton.Size = new System.Drawing.Size(177, 23);
            this.BioEncryptButton.TabIndex = 9;
            this.BioEncryptButton.Text = "Bio-Inspired Encryption";
            this.BioEncryptButton.UseVisualStyleBackColor = true;
            this.BioEncryptButton.Click += new System.EventHandler(this.BioEncryptButton_Click);
            // 
            // PlaintextFeaturesButton
            // 
            this.PlaintextFeaturesButton.Enabled = false;
            this.PlaintextFeaturesButton.Location = new System.Drawing.Point(296, 117);
            this.PlaintextFeaturesButton.Name = "PlaintextFeaturesButton";
            this.PlaintextFeaturesButton.Size = new System.Drawing.Size(177, 23);
            this.PlaintextFeaturesButton.TabIndex = 8;
            this.PlaintextFeaturesButton.Text = "View Image Features";
            this.PlaintextFeaturesButton.UseVisualStyleBackColor = true;
            this.PlaintextFeaturesButton.Click += new System.EventHandler(this.PlaintextFeaturesButton_Click);
            // 
            // PlaintextSpectraButton
            // 
            this.PlaintextSpectraButton.Enabled = false;
            this.PlaintextSpectraButton.Location = new System.Drawing.Point(296, 88);
            this.PlaintextSpectraButton.Name = "PlaintextSpectraButton";
            this.PlaintextSpectraButton.Size = new System.Drawing.Size(177, 23);
            this.PlaintextSpectraButton.TabIndex = 7;
            this.PlaintextSpectraButton.Text = "View Spectra";
            this.PlaintextSpectraButton.UseVisualStyleBackColor = true;
            this.PlaintextSpectraButton.Click += new System.EventHandler(this.PlaintextSpectraButton_Click);
            // 
            // PlaintextHistogramButton
            // 
            this.PlaintextHistogramButton.Enabled = false;
            this.PlaintextHistogramButton.Location = new System.Drawing.Point(296, 59);
            this.PlaintextHistogramButton.Name = "PlaintextHistogramButton";
            this.PlaintextHistogramButton.Size = new System.Drawing.Size(177, 23);
            this.PlaintextHistogramButton.TabIndex = 6;
            this.PlaintextHistogramButton.Text = "View Histogram";
            this.PlaintextHistogramButton.UseVisualStyleBackColor = true;
            this.PlaintextHistogramButton.Click += new System.EventHandler(this.PlaintextHistogramButton_Click);
            // 
            // PlaintextCorrelationButton
            // 
            this.PlaintextCorrelationButton.Enabled = false;
            this.PlaintextCorrelationButton.Location = new System.Drawing.Point(296, 30);
            this.PlaintextCorrelationButton.Name = "PlaintextCorrelationButton";
            this.PlaintextCorrelationButton.Size = new System.Drawing.Size(177, 23);
            this.PlaintextCorrelationButton.TabIndex = 5;
            this.PlaintextCorrelationButton.Text = "View Pixel Correlations";
            this.PlaintextCorrelationButton.UseVisualStyleBackColor = true;
            this.PlaintextCorrelationButton.Click += new System.EventHandler(this.PlaintextCorrelationButton_Click);
            // 
            // PlainText_Image
            // 
            this.PlainText_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlainText_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PlainText_Image.Location = new System.Drawing.Point(18, 19);
            this.PlainText_Image.Name = "PlainText_Image";
            this.PlainText_Image.Size = new System.Drawing.Size(256, 256);
            this.PlainText_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PlainText_Image.TabIndex = 0;
            this.PlainText_Image.TabStop = false;
            this.PlainText_Image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // OpenImageDialog
            // 
            this.OpenImageDialog.DefaultExt = "png";
            this.OpenImageDialog.Filter = "PNG files|*.png|BMP files|*.bmp|JPEG files|*.jpg";
            this.OpenImageDialog.Title = "Open Image File...";
            // 
            // CiphertextImageGroupbox
            // 
            this.CiphertextImageGroupbox.Controls.Add(this.MemoryUsageLabel);
            this.CiphertextImageGroupbox.Controls.Add(this.EncryptionTimeLabel);
            this.CiphertextImageGroupbox.Controls.Add(this.CiphertextFeaturesButton);
            this.CiphertextImageGroupbox.Controls.Add(this.CiphertextSpectraButton);
            this.CiphertextImageGroupbox.Controls.Add(this.CiphertextHistogramButton);
            this.CiphertextImageGroupbox.Controls.Add(this.CiphertextCorrelationButton);
            this.CiphertextImageGroupbox.Controls.Add(this.Ciphertext_Image);
            this.CiphertextImageGroupbox.Location = new System.Drawing.Point(12, 352);
            this.CiphertextImageGroupbox.Name = "CiphertextImageGroupbox";
            this.CiphertextImageGroupbox.Size = new System.Drawing.Size(499, 297);
            this.CiphertextImageGroupbox.TabIndex = 15;
            this.CiphertextImageGroupbox.TabStop = false;
            this.CiphertextImageGroupbox.Text = "Ciphertext Image";
            // 
            // EncryptionTimeLabel
            // 
            this.EncryptionTimeLabel.AutoSize = true;
            this.EncryptionTimeLabel.Location = new System.Drawing.Point(370, 281);
            this.EncryptionTimeLabel.Name = "EncryptionTimeLabel";
            this.EncryptionTimeLabel.Size = new System.Drawing.Size(123, 13);
            this.EncryptionTimeLabel.TabIndex = 9;
            this.EncryptionTimeLabel.Text = "Encryption Time: 000 ms";
            this.EncryptionTimeLabel.Visible = false;
            // 
            // CiphertextFeaturesButton
            // 
            this.CiphertextFeaturesButton.Enabled = false;
            this.CiphertextFeaturesButton.Location = new System.Drawing.Point(296, 117);
            this.CiphertextFeaturesButton.Name = "CiphertextFeaturesButton";
            this.CiphertextFeaturesButton.Size = new System.Drawing.Size(177, 23);
            this.CiphertextFeaturesButton.TabIndex = 8;
            this.CiphertextFeaturesButton.Text = "View Image Features";
            this.CiphertextFeaturesButton.UseVisualStyleBackColor = true;
            this.CiphertextFeaturesButton.Click += new System.EventHandler(this.CiphertextFeaturesButton_Click);
            // 
            // CiphertextSpectraButton
            // 
            this.CiphertextSpectraButton.Enabled = false;
            this.CiphertextSpectraButton.Location = new System.Drawing.Point(296, 88);
            this.CiphertextSpectraButton.Name = "CiphertextSpectraButton";
            this.CiphertextSpectraButton.Size = new System.Drawing.Size(177, 23);
            this.CiphertextSpectraButton.TabIndex = 7;
            this.CiphertextSpectraButton.Text = "View Spectra";
            this.CiphertextSpectraButton.UseVisualStyleBackColor = true;
            this.CiphertextSpectraButton.Click += new System.EventHandler(this.CiphertextSpectraButton_Click);
            // 
            // CiphertextHistogramButton
            // 
            this.CiphertextHistogramButton.Enabled = false;
            this.CiphertextHistogramButton.Location = new System.Drawing.Point(296, 59);
            this.CiphertextHistogramButton.Name = "CiphertextHistogramButton";
            this.CiphertextHistogramButton.Size = new System.Drawing.Size(177, 23);
            this.CiphertextHistogramButton.TabIndex = 6;
            this.CiphertextHistogramButton.Text = "View Histogram";
            this.CiphertextHistogramButton.UseVisualStyleBackColor = true;
            this.CiphertextHistogramButton.Click += new System.EventHandler(this.CiphertextHistogramButton_Click);
            // 
            // CiphertextCorrelationButton
            // 
            this.CiphertextCorrelationButton.Enabled = false;
            this.CiphertextCorrelationButton.Location = new System.Drawing.Point(296, 30);
            this.CiphertextCorrelationButton.Name = "CiphertextCorrelationButton";
            this.CiphertextCorrelationButton.Size = new System.Drawing.Size(177, 23);
            this.CiphertextCorrelationButton.TabIndex = 5;
            this.CiphertextCorrelationButton.Text = "View Pixel Correlations";
            this.CiphertextCorrelationButton.UseVisualStyleBackColor = true;
            this.CiphertextCorrelationButton.Click += new System.EventHandler(this.CiphertextCorrelationButton_Click);
            // 
            // Ciphertext_Image
            // 
            this.Ciphertext_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Ciphertext_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Ciphertext_Image.Location = new System.Drawing.Point(18, 19);
            this.Ciphertext_Image.Name = "Ciphertext_Image";
            this.Ciphertext_Image.Size = new System.Drawing.Size(256, 256);
            this.Ciphertext_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Ciphertext_Image.TabIndex = 0;
            this.Ciphertext_Image.TabStop = false;
            this.Ciphertext_Image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(12, 8);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(75, 23);
            this.LoadImageButton.TabIndex = 16;
            this.LoadImageButton.Text = "Load Image";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.openImageButton_Click);
            // 
            // SaveImageDialog
            // 
            this.SaveImageDialog.DefaultExt = "png";
            this.SaveImageDialog.Filter = "PNG files|*.png";
            this.SaveImageDialog.Title = "Save Image";
            // 
            // MemoryUsageLabel
            // 
            this.MemoryUsageLabel.AutoSize = true;
            this.MemoryUsageLabel.Location = new System.Drawing.Point(370, 262);
            this.MemoryUsageLabel.Name = "MemoryUsageLabel";
            this.MemoryUsageLabel.Size = new System.Drawing.Size(121, 13);
            this.MemoryUsageLabel.TabIndex = 10;
            this.MemoryUsageLabel.Text = "Memory Usage: 000 MB";
            this.MemoryUsageLabel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 682);
            this.Controls.Add(this.LoadImageButton);
            this.Controls.Add(this.CiphertextImageGroupbox);
            this.Controls.Add(this.PlaintextImageGroupbox);
            this.Name = "MainWindow";
            this.Text = "Image Crypto";
            this.PlaintextImageGroupbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlainText_Image)).EndInit();
            this.CiphertextImageGroupbox.ResumeLayout(false);
            this.CiphertextImageGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ciphertext_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PlainText_Image;
        private System.Windows.Forms.GroupBox PlaintextImageGroupbox;
        private System.Windows.Forms.Button PlaintextHistogramButton;
        private System.Windows.Forms.Button PlaintextCorrelationButton;
        private System.Windows.Forms.OpenFileDialog OpenImageDialog;
        private System.Windows.Forms.Button PlaintextSpectraButton;
        private System.Windows.Forms.Button PlaintextFeaturesButton;
        private System.Windows.Forms.GroupBox CiphertextImageGroupbox;
        private System.Windows.Forms.Button CiphertextFeaturesButton;
        private System.Windows.Forms.Button CiphertextSpectraButton;
        private System.Windows.Forms.Button CiphertextHistogramButton;
        private System.Windows.Forms.Button CiphertextCorrelationButton;
        private System.Windows.Forms.PictureBox Ciphertext_Image;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.Button FDEncryptButton;
        private System.Windows.Forms.Button CAEncryptButton;
        private System.Windows.Forms.Button BioEncryptButton;
        private System.Windows.Forms.Label EncryptionTimeLabel;
        private System.Windows.Forms.SaveFileDialog SaveImageDialog;
        private System.Windows.Forms.Label MemoryUsageLabel;
    }
}

