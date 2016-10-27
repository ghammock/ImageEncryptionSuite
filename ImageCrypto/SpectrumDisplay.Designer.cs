namespace ImageCrypto
{
    partial class SpectrumDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
            this.SpectraWindowStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarRightSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.SpectraWorker = new System.ComponentModel.BackgroundWorker();
            this.SpectraTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.InputLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FourierPanel = new System.Windows.Forms.Panel();
            this.FourierLabel = new System.Windows.Forms.Label();
            this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.InputImage = new bambit.forms.controls.PictureBoxExtended();
            this.FourierImage = new bambit.forms.controls.PictureBoxExtended();
            this.SpectraWindowStatusStrip.SuspendLayout();
            this.SpectraTableLayout.SuspendLayout();
            this.InputPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.FourierPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourierImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SpectraWindowStatusStrip
            // 
            this.SpectraWindowStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel,
            this.StatusBarRightSpring,
            this.StatusBarProgressBar});
            this.SpectraWindowStatusStrip.Location = new System.Drawing.Point(0, 405);
            this.SpectraWindowStatusStrip.Name = "SpectraWindowStatusStrip";
            this.SpectraWindowStatusStrip.Size = new System.Drawing.Size(824, 22);
            this.SpectraWindowStatusStrip.TabIndex = 21;
            this.SpectraWindowStatusStrip.Text = "Status Strip";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(87, 17);
            this.ToolStripStatusLabel.Text = "Progress Status";
            this.ToolStripStatusLabel.Visible = false;
            // 
            // StatusBarRightSpring
            // 
            this.StatusBarRightSpring.Name = "StatusBarRightSpring";
            this.StatusBarRightSpring.Size = new System.Drawing.Size(809, 17);
            this.StatusBarRightSpring.Spring = true;
            // 
            // StatusBarProgressBar
            // 
            this.StatusBarProgressBar.Name = "StatusBarProgressBar";
            this.StatusBarProgressBar.Size = new System.Drawing.Size(200, 16);
            this.StatusBarProgressBar.Visible = false;
            // 
            // SpectraWorker
            // 
            this.SpectraWorker.WorkerReportsProgress = true;
            this.SpectraWorker.WorkerSupportsCancellation = true;
            this.SpectraWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SpectraWorker_DoWork);
            this.SpectraWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SpectraWorker_ProgressChanged);
            this.SpectraWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SpectraWorker_RunWorkerCompleted);
            // 
            // SpectraTableLayout
            // 
            this.SpectraTableLayout.ColumnCount = 2;
            this.SpectraTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SpectraTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SpectraTableLayout.Controls.Add(this.InputPanel, 0, 0);
            this.SpectraTableLayout.Controls.Add(this.panel1, 1, 0);
            this.SpectraTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpectraTableLayout.Location = new System.Drawing.Point(0, 0);
            this.SpectraTableLayout.Name = "SpectraTableLayout";
            this.SpectraTableLayout.RowCount = 1;
            this.SpectraTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SpectraTableLayout.Size = new System.Drawing.Size(824, 405);
            this.SpectraTableLayout.TabIndex = 22;
            // 
            // InputPanel
            // 
            this.InputPanel.Controls.Add(this.InputImage);
            this.InputPanel.Controls.Add(this.InputLabel);
            this.InputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputPanel.Location = new System.Drawing.Point(3, 3);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(406, 399);
            this.InputPanel.TabIndex = 21;
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(9, 6);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(63, 13);
            this.InputLabel.TabIndex = 20;
            this.InputLabel.Text = "Input Image";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FourierPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(415, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 399);
            this.panel1.TabIndex = 20;
            // 
            // FourierPanel
            // 
            this.FourierPanel.Controls.Add(this.FourierLabel);
            this.FourierPanel.Controls.Add(this.FourierImage);
            this.FourierPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FourierPanel.Location = new System.Drawing.Point(0, 0);
            this.FourierPanel.Name = "FourierPanel";
            this.FourierPanel.Size = new System.Drawing.Size(406, 399);
            this.FourierPanel.TabIndex = 20;
            // 
            // FourierLabel
            // 
            this.FourierLabel.AutoSize = true;
            this.FourierLabel.Location = new System.Drawing.Point(3, 6);
            this.FourierLabel.Name = "FourierLabel";
            this.FourierLabel.Size = new System.Drawing.Size(79, 13);
            this.FourierLabel.TabIndex = 19;
            this.FourierLabel.Text = "Fourier Spectra";
            // 
            // SaveImageDialog
            // 
            this.SaveImageDialog.DefaultExt = "png";
            this.SaveImageDialog.Filter = "PNG files|*.png";
            this.SaveImageDialog.Title = "Save Image";
            // 
            // InputImage
            // 
            this.InputImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InputImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InputImage.Location = new System.Drawing.Point(9, 22);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(391, 374);
            this.InputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InputImage.TabIndex = 17;
            this.InputImage.TabStop = false;
            this.InputImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // FourierImage
            // 
            this.FourierImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FourierImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FourierImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FourierImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FourierImage.Location = new System.Drawing.Point(3, 22);
            this.FourierImage.Name = "FourierImage";
            this.FourierImage.Size = new System.Drawing.Size(400, 374);
            this.FourierImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FourierImage.TabIndex = 18;
            this.FourierImage.TabStop = false;
            this.FourierImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // SpectrumDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 427);
            this.Controls.Add(this.SpectraTableLayout);
            this.Controls.Add(this.SpectraWindowStatusStrip);
            this.Name = "SpectrumDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Spectra";
            this.SpectraWindowStatusStrip.ResumeLayout(false);
            this.SpectraWindowStatusStrip.PerformLayout();
            this.SpectraTableLayout.ResumeLayout(false);
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.FourierPanel.ResumeLayout(false);
            this.FourierPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourierImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SpectraWindowStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarRightSpring;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgressBar;
        private System.ComponentModel.BackgroundWorker SpectraWorker;
        private System.Windows.Forms.TableLayoutPanel SpectraTableLayout;
        private bambit.forms.controls.PictureBoxExtended InputImage;
        private bambit.forms.controls.PictureBoxExtended FourierImage;
        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel FourierPanel;
        private System.Windows.Forms.Label FourierLabel;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.SaveFileDialog SaveImageDialog;
    }
}