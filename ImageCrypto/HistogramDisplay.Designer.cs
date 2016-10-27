namespace ImageCrypto
{
    partial class HistogramDisplay
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.HistogramTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.Histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.InputImage = new bambit.forms.controls.PictureBoxExtended();
            this.ImageStats = new System.Windows.Forms.TextBox();
            this.PixelIntensityLabel = new System.Windows.Forms.Label();
            this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
            this.OutputHistogramButton = new System.Windows.Forms.Button();
            this.SaveHistogramDialog = new System.Windows.Forms.SaveFileDialog();
            this.HistogramTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // HistogramTableLayout
            // 
            this.HistogramTableLayout.ColumnCount = 2;
            this.HistogramTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.71359F));
            this.HistogramTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.28641F));
            this.HistogramTableLayout.Controls.Add(this.Histogram, 0, 0);
            this.HistogramTableLayout.Controls.Add(this.InputImage, 0, 0);
            this.HistogramTableLayout.Controls.Add(this.ImageStats, 0, 1);
            this.HistogramTableLayout.Controls.Add(this.OutputHistogramButton, 1, 2);
            this.HistogramTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistogramTableLayout.Location = new System.Drawing.Point(0, 0);
            this.HistogramTableLayout.Name = "HistogramTableLayout";
            this.HistogramTableLayout.RowCount = 3;
            this.HistogramTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.HistogramTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.HistogramTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HistogramTableLayout.Size = new System.Drawing.Size(824, 427);
            this.HistogramTableLayout.TabIndex = 0;
            // 
            // Histogram
            // 
            this.Histogram.BorderlineColor = System.Drawing.Color.Black;
            this.Histogram.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.Histogram.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.Histogram.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea1.AxisX.Crossing = 0D;
            chartArea1.AxisX.Interval = 16D;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.Maximum = 256D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Luminance Value";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Counts";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.Histogram.ChartAreas.Add(chartArea1);
            this.Histogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Histogram.Location = new System.Drawing.Point(321, 3);
            this.Histogram.Name = "Histogram";
            this.HistogramTableLayout.SetRowSpan(this.Histogram, 2);
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.DimGray;
            series1.CustomProperties = "DrawSideBySide=False, EmptyPointValue=Zero, PointWidth=1";
            series1.MarkerSize = 10;
            series1.Name = "Luminance";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.Histogram.Series.Add(series1);
            this.Histogram.Size = new System.Drawing.Size(500, 391);
            this.Histogram.TabIndex = 18;
            this.Histogram.Text = "Pixel Histogram";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title1.Name = "HistogramTitle";
            title1.Text = "Luminance Histogram";
            this.Histogram.Titles.Add(title1);
            this.Histogram.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // InputImage
            // 
            this.InputImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InputImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputImage.Location = new System.Drawing.Point(3, 3);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(312, 278);
            this.InputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InputImage.TabIndex = 17;
            this.InputImage.TabStop = false;
            this.InputImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            this.InputImage.MouseLeave += new System.EventHandler(this.InputImage_MouseLeave);
            this.InputImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseMove);
            // 
            // ImageStats
            // 
            this.ImageStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageStats.Location = new System.Drawing.Point(3, 287);
            this.ImageStats.Multiline = true;
            this.ImageStats.Name = "ImageStats";
            this.ImageStats.ReadOnly = true;
            this.HistogramTableLayout.SetRowSpan(this.ImageStats, 2);
            this.ImageStats.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ImageStats.Size = new System.Drawing.Size(312, 137);
            this.ImageStats.TabIndex = 19;
            // 
            // PixelIntensityLabel
            // 
            this.PixelIntensityLabel.AutoSize = true;
            this.PixelIntensityLabel.BackColor = System.Drawing.SystemColors.Info;
            this.PixelIntensityLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PixelIntensityLabel.Location = new System.Drawing.Point(150, 0);
            this.PixelIntensityLabel.Name = "PixelIntensityLabel";
            this.PixelIntensityLabel.Size = new System.Drawing.Size(105, 15);
            this.PixelIntensityLabel.TabIndex = 1;
            this.PixelIntensityLabel.Text = "x = 0, y = 0, Lum = 0";
            // 
            // SaveImageDialog
            // 
            this.SaveImageDialog.DefaultExt = "png";
            this.SaveImageDialog.Filter = "PNG files|*.png";
            this.SaveImageDialog.Title = "Save Image";
            // 
            // OutputHistogramButton
            // 
            this.OutputHistogramButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputHistogramButton.Location = new System.Drawing.Point(689, 401);
            this.OutputHistogramButton.Name = "OutputHistogramButton";
            this.OutputHistogramButton.Size = new System.Drawing.Size(132, 23);
            this.OutputHistogramButton.TabIndex = 20;
            this.OutputHistogramButton.Text = "Output Histogram";
            this.OutputHistogramButton.UseVisualStyleBackColor = true;
            this.OutputHistogramButton.Click += new System.EventHandler(this.OutputHistogramButton_Click);
            // 
            // SaveHistogramDialog
            // 
            this.SaveHistogramDialog.DefaultExt = "csv";
            this.SaveHistogramDialog.Filter = "CSV Files|*.csv";
            this.SaveHistogramDialog.Title = "Save Histogram";
            // 
            // HistogramDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 427);
            this.Controls.Add(this.PixelIntensityLabel);
            this.Controls.Add(this.HistogramTableLayout);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(840, 465);
            this.Name = "HistogramDisplay";
            this.Text = "Image Histogram";
            this.HistogramTableLayout.ResumeLayout(false);
            this.HistogramTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel HistogramTableLayout;
        private bambit.forms.controls.PictureBoxExtended InputImage;
        private System.Windows.Forms.DataVisualization.Charting.Chart Histogram;
        private System.Windows.Forms.Label PixelIntensityLabel;
        private System.Windows.Forms.TextBox ImageStats;
        private System.Windows.Forms.SaveFileDialog SaveImageDialog;
        private System.Windows.Forms.Button OutputHistogramButton;
        private System.Windows.Forms.SaveFileDialog SaveHistogramDialog;
    }
}