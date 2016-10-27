namespace ImageCrypto
{
    partial class SecretImageSelection
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
            this.OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.SecretImageBox = new System.Windows.Forms.PictureBox();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.RandomImageButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.EntropyLabel = new System.Windows.Forms.Label();
            this.ChiSquaredLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SecretImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenImageDialog
            // 
            this.OpenImageDialog.DefaultExt = "png";
            this.OpenImageDialog.Filter = "PNG files|*.png|BMP files|*.bmp|JPEG files|*.jpg";
            this.OpenImageDialog.Title = "Open Image File...";
            // 
            // SecretImageBox
            // 
            this.SecretImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SecretImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SecretImageBox.Location = new System.Drawing.Point(12, 12);
            this.SecretImageBox.Name = "SecretImageBox";
            this.SecretImageBox.Size = new System.Drawing.Size(256, 256);
            this.SecretImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SecretImageBox.TabIndex = 1;
            this.SecretImageBox.TabStop = false;
            this.SecretImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(290, 32);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(159, 23);
            this.LoadImageButton.TabIndex = 17;
            this.LoadImageButton.Text = "Load Existing Image";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // RandomImageButton
            // 
            this.RandomImageButton.Location = new System.Drawing.Point(290, 61);
            this.RandomImageButton.Name = "RandomImageButton";
            this.RandomImageButton.Size = new System.Drawing.Size(159, 23);
            this.RandomImageButton.TabIndex = 18;
            this.RandomImageButton.Text = "Generate Random Image";
            this.RandomImageButton.UseVisualStyleBackColor = true;
            this.RandomImageButton.Click += new System.EventHandler(this.RandomImageButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(290, 245);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(159, 23);
            this.ConfirmButton.TabIndex = 19;
            this.ConfirmButton.Text = "Done";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // SaveImageDialog
            // 
            this.SaveImageDialog.DefaultExt = "png";
            this.SaveImageDialog.Filter = "PNG files|*.png";
            this.SaveImageDialog.Title = "Save Image";
            // 
            // EntropyLabel
            // 
            this.EntropyLabel.AutoSize = true;
            this.EntropyLabel.Location = new System.Drawing.Point(290, 123);
            this.EntropyLabel.Name = "EntropyLabel";
            this.EntropyLabel.Size = new System.Drawing.Size(101, 13);
            this.EntropyLabel.TabIndex = 20;
            this.EntropyLabel.Text = "Entropy: 0.0000 bits";
            // 
            // ChiSquaredLabel
            // 
            this.ChiSquaredLabel.AutoSize = true;
            this.ChiSquaredLabel.Location = new System.Drawing.Point(290, 136);
            this.ChiSquaredLabel.Name = "ChiSquaredLabel";
            this.ChiSquaredLabel.Size = new System.Drawing.Size(104, 13);
            this.ChiSquaredLabel.TabIndex = 21;
            this.ChiSquaredLabel.Text = "Chi-Squared: 0.0000";
            // 
            // SecretImageSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 286);
            this.Controls.Add(this.ChiSquaredLabel);
            this.Controls.Add(this.EntropyLabel);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.RandomImageButton);
            this.Controls.Add(this.LoadImageButton);
            this.Controls.Add(this.SecretImageBox);
            this.Name = "SecretImageSelection";
            this.Text = "Select Secret Image";
            ((System.ComponentModel.ISupportInitialize)(this.SecretImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenImageDialog;
        private System.Windows.Forms.PictureBox SecretImageBox;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.Button RandomImageButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.SaveFileDialog SaveImageDialog;
        private System.Windows.Forms.Label EntropyLabel;
        private System.Windows.Forms.Label ChiSquaredLabel;
    }
}