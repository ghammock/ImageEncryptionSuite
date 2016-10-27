namespace ImageCrypto
{
    partial class ImageFeaturesDisplay
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
            this.FeaturesWindowStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarRightSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.FeaturesTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SobelEdgePanel = new System.Windows.Forms.Panel();
            this.SobelEdgesLabel = new System.Windows.Forms.Label();
            this.SobelEdgesImage = new bambit.forms.controls.PictureBoxExtended();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.InputImage = new bambit.forms.controls.PictureBoxExtended();
            this.InputLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CannyEdgePanel = new System.Windows.Forms.Panel();
            this.CannyEdgesLabel = new System.Windows.Forms.Label();
            this.CannyEdgesImage = new bambit.forms.controls.PictureBoxExtended();
            this.featuresWorker = new System.ComponentModel.BackgroundWorker();
            this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.FeaturesWindowStatusStrip.SuspendLayout();
            this.FeaturesTableLayout.SuspendLayout();
            this.SobelEdgePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SobelEdgesImage)).BeginInit();
            this.InputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.CannyEdgePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CannyEdgesImage)).BeginInit();
            this.SuspendLayout();
            // 
            // FeaturesWindowStatusStrip
            // 
            this.FeaturesWindowStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel,
            this.StatusBarRightSpring,
            this.StatusBarProgressBar});
            this.FeaturesWindowStatusStrip.Location = new System.Drawing.Point(0, 405);
            this.FeaturesWindowStatusStrip.Name = "FeaturesWindowStatusStrip";
            this.FeaturesWindowStatusStrip.Size = new System.Drawing.Size(824, 22);
            this.FeaturesWindowStatusStrip.TabIndex = 22;
            this.FeaturesWindowStatusStrip.Text = "Status Strip";
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
            // FeaturesTableLayout
            // 
            this.FeaturesTableLayout.ColumnCount = 3;
            this.FeaturesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FeaturesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FeaturesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.FeaturesTableLayout.Controls.Add(this.SobelEdgePanel, 0, 0);
            this.FeaturesTableLayout.Controls.Add(this.InputPanel, 0, 0);
            this.FeaturesTableLayout.Controls.Add(this.panel1, 1, 0);
            this.FeaturesTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FeaturesTableLayout.Location = new System.Drawing.Point(0, 0);
            this.FeaturesTableLayout.Name = "FeaturesTableLayout";
            this.FeaturesTableLayout.RowCount = 1;
            this.FeaturesTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FeaturesTableLayout.Size = new System.Drawing.Size(824, 405);
            this.FeaturesTableLayout.TabIndex = 23;
            // 
            // SobelEdgePanel
            // 
            this.SobelEdgePanel.Controls.Add(this.SobelEdgesLabel);
            this.SobelEdgePanel.Controls.Add(this.SobelEdgesImage);
            this.SobelEdgePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SobelEdgePanel.Location = new System.Drawing.Point(277, 3);
            this.SobelEdgePanel.Name = "SobelEdgePanel";
            this.SobelEdgePanel.Size = new System.Drawing.Size(268, 399);
            this.SobelEdgePanel.TabIndex = 22;
            // 
            // SobelEdgesLabel
            // 
            this.SobelEdgesLabel.AutoSize = true;
            this.SobelEdgesLabel.Location = new System.Drawing.Point(3, 6);
            this.SobelEdgesLabel.Name = "SobelEdgesLabel";
            this.SobelEdgesLabel.Size = new System.Drawing.Size(120, 13);
            this.SobelEdgesLabel.TabIndex = 19;
            this.SobelEdgesLabel.Text = "Detected Edges (Sobel)";
            // 
            // SobelEdgesImage
            // 
            this.SobelEdgesImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SobelEdgesImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SobelEdgesImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SobelEdgesImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.SobelEdgesImage.Location = new System.Drawing.Point(3, 22);
            this.SobelEdgesImage.Name = "SobelEdgesImage";
            this.SobelEdgesImage.Size = new System.Drawing.Size(262, 374);
            this.SobelEdgesImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SobelEdgesImage.TabIndex = 18;
            this.SobelEdgesImage.TabStop = false;
            this.SobelEdgesImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // InputPanel
            // 
            this.InputPanel.Controls.Add(this.InputImage);
            this.InputPanel.Controls.Add(this.InputLabel);
            this.InputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputPanel.Location = new System.Drawing.Point(3, 3);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(268, 399);
            this.InputPanel.TabIndex = 21;
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
            this.InputImage.Size = new System.Drawing.Size(253, 374);
            this.InputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InputImage.TabIndex = 17;
            this.InputImage.TabStop = false;
            this.InputImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
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
            this.panel1.Controls.Add(this.CannyEdgePanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(551, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 399);
            this.panel1.TabIndex = 20;
            // 
            // CannyEdgePanel
            // 
            this.CannyEdgePanel.Controls.Add(this.CannyEdgesLabel);
            this.CannyEdgePanel.Controls.Add(this.CannyEdgesImage);
            this.CannyEdgePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CannyEdgePanel.Location = new System.Drawing.Point(0, 0);
            this.CannyEdgePanel.Name = "CannyEdgePanel";
            this.CannyEdgePanel.Size = new System.Drawing.Size(270, 399);
            this.CannyEdgePanel.TabIndex = 20;
            // 
            // CannyEdgesLabel
            // 
            this.CannyEdgesLabel.AutoSize = true;
            this.CannyEdgesLabel.Location = new System.Drawing.Point(3, 6);
            this.CannyEdgesLabel.Name = "CannyEdgesLabel";
            this.CannyEdgesLabel.Size = new System.Drawing.Size(123, 13);
            this.CannyEdgesLabel.TabIndex = 19;
            this.CannyEdgesLabel.Text = "Detected Edges (Canny)";
            // 
            // CannyEdgesImage
            // 
            this.CannyEdgesImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CannyEdgesImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CannyEdgesImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CannyEdgesImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CannyEdgesImage.Location = new System.Drawing.Point(3, 22);
            this.CannyEdgesImage.Name = "CannyEdgesImage";
            this.CannyEdgesImage.Size = new System.Drawing.Size(264, 374);
            this.CannyEdgesImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CannyEdgesImage.TabIndex = 18;
            this.CannyEdgesImage.TabStop = false;
            this.CannyEdgesImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // featuresWorker
            // 
            this.featuresWorker.WorkerReportsProgress = true;
            this.featuresWorker.WorkerSupportsCancellation = true;
            this.featuresWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.featuresWorker_DoWork);
            this.featuresWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.featuresWorker_ProgressChanged);
            this.featuresWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.featuresWorker_RunWorkerCompleted);
            // 
            // SaveImageDialog
            // 
            this.SaveImageDialog.DefaultExt = "png";
            this.SaveImageDialog.Filter = "PNG files|*.png";
            this.SaveImageDialog.Title = "Save Image";
            // 
            // ImageFeaturesDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 427);
            this.Controls.Add(this.FeaturesTableLayout);
            this.Controls.Add(this.FeaturesWindowStatusStrip);
            this.Name = "ImageFeaturesDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image Features";
            this.FeaturesWindowStatusStrip.ResumeLayout(false);
            this.FeaturesWindowStatusStrip.PerformLayout();
            this.FeaturesTableLayout.ResumeLayout(false);
            this.SobelEdgePanel.ResumeLayout(false);
            this.SobelEdgePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SobelEdgesImage)).EndInit();
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.CannyEdgePanel.ResumeLayout(false);
            this.CannyEdgePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CannyEdgesImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip FeaturesWindowStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarRightSpring;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgressBar;
        private System.Windows.Forms.TableLayoutPanel FeaturesTableLayout;
        private System.Windows.Forms.Panel InputPanel;
        private bambit.forms.controls.PictureBoxExtended InputImage;
        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel CannyEdgePanel;
        private System.Windows.Forms.Label CannyEdgesLabel;
        private bambit.forms.controls.PictureBoxExtended CannyEdgesImage;
        private System.ComponentModel.BackgroundWorker featuresWorker;
        private System.Windows.Forms.Panel SobelEdgePanel;
        private System.Windows.Forms.Label SobelEdgesLabel;
        private bambit.forms.controls.PictureBoxExtended SobelEdgesImage;
        private System.Windows.Forms.SaveFileDialog SaveImageDialog;
    }
}