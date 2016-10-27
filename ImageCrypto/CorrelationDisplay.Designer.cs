namespace ImageCrypto
{
    partial class CorrelationDisplay
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.VerticalCorrelationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.HorizontalCorrelationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CorrelationSampleSizeSlider = new System.Windows.Forms.TrackBar();
            this.CorrelationSampleSizeLabel = new System.Windows.Forms.Label();
            this.CovarianceWorker = new System.ComponentModel.BackgroundWorker();
            this.CorrelationWindowStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusBarRightSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.CorrelationSampleSize = new System.Windows.Forms.NumericUpDown();
            this.CovarianceTimer = new System.Windows.Forms.Timer(this.components);
            this.HorizontalStatsTextBox = new System.Windows.Forms.TextBox();
            this.VerticalStatsTextBox = new System.Windows.Forms.TextBox();
            this.CorrelationTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.InputImage = new bambit.forms.controls.PictureBoxExtended();
            this.SampleSizeControlsPanel = new System.Windows.Forms.Panel();
            this.PixelIntensityLabel = new System.Windows.Forms.Label();
            this.SaveImageDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalCorrelationChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalCorrelationChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CorrelationSampleSizeSlider)).BeginInit();
            this.CorrelationWindowStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CorrelationSampleSize)).BeginInit();
            this.CorrelationTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            this.SampleSizeControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerticalCorrelationChart
            // 
            this.VerticalCorrelationChart.BorderlineColor = System.Drawing.Color.Black;
            this.VerticalCorrelationChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.VerticalCorrelationChart.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.VerticalCorrelationChart.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea1.AxisX.Crossing = 0D;
            chartArea1.AxisX.Interval = 16D;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.Maximum = 256D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Pixel Intensity";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.Interval = 16D;
            chartArea1.AxisY.Maximum = 256D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Intensity of Y-Neighbor";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.VerticalCorrelationChart.ChartAreas.Add(chartArea1);
            this.VerticalCorrelationChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerticalCorrelationChart.Location = new System.Drawing.Point(554, 3);
            this.VerticalCorrelationChart.Name = "VerticalCorrelationChart";
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.Crimson;
            series1.CustomProperties = "DrawSideBySide=True, IsXAxisQuantitative=True, EmptyPointValue=Zero, PointWidth=1" +
    "";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "VerticalCorrelation";
            this.VerticalCorrelationChart.Series.Add(series1);
            this.VerticalCorrelationChart.Size = new System.Drawing.Size(267, 283);
            this.VerticalCorrelationChart.TabIndex = 15;
            this.VerticalCorrelationChart.Text = "Vertical Covariance";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title1.Name = "VerticalPlotTitle";
            title1.Text = "Luminance Correlation of Adjacent Vertical Pixels";
            this.VerticalCorrelationChart.Titles.Add(title1);
            this.VerticalCorrelationChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // HorizontalCorrelationChart
            // 
            this.HorizontalCorrelationChart.BorderlineColor = System.Drawing.Color.Black;
            this.HorizontalCorrelationChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.HorizontalCorrelationChart.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.HorizontalCorrelationChart.BorderSkin.PageColor = System.Drawing.Color.Black;
            chartArea2.AxisX.Crossing = 0D;
            chartArea2.AxisX.Interval = 16D;
            chartArea2.AxisX.LabelStyle.Angle = -90;
            chartArea2.AxisX.Maximum = 256D;
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "Pixel Intensity";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.AxisY.Interval = 16D;
            chartArea2.AxisY.Maximum = 256D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "Intensity of X-Neighbor";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            chartArea2.Name = "ChartArea1";
            this.HorizontalCorrelationChart.ChartAreas.Add(chartArea2);
            this.HorizontalCorrelationChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HorizontalCorrelationChart.Location = new System.Drawing.Point(283, 3);
            this.HorizontalCorrelationChart.Name = "HorizontalCorrelationChart";
            series2.BorderColor = System.Drawing.Color.Black;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Crimson;
            series2.CustomProperties = "DrawSideBySide=True, IsXAxisQuantitative=True, EmptyPointValue=Zero, PointWidth=1" +
    "";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "HorizontalCovariance";
            series2.XValueMember = "xy";
            series2.YValueMembers = "xy_hor";
            this.HorizontalCorrelationChart.Series.Add(series2);
            this.HorizontalCorrelationChart.Size = new System.Drawing.Size(265, 283);
            this.HorizontalCorrelationChart.TabIndex = 14;
            this.HorizontalCorrelationChart.Text = "Horizontal Correlation";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title2.Name = "HorizontalPlotTitle";
            title2.Text = "Luminance Correlation of Adjacent Horizontal Pixels";
            this.HorizontalCorrelationChart.Titles.Add(title2);
            this.HorizontalCorrelationChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            // 
            // CorrelationSampleSizeSlider
            // 
            this.CorrelationSampleSizeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CorrelationSampleSizeSlider.Location = new System.Drawing.Point(3, 38);
            this.CorrelationSampleSizeSlider.Name = "CorrelationSampleSizeSlider";
            this.CorrelationSampleSizeSlider.Size = new System.Drawing.Size(268, 45);
            this.CorrelationSampleSizeSlider.TabIndex = 17;
            this.CorrelationSampleSizeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.CorrelationSampleSizeSlider.Scroll += new System.EventHandler(this.CovarianceSampleSizeSlider_Scroll);
            // 
            // CorrelationSampleSizeLabel
            // 
            this.CorrelationSampleSizeLabel.AutoSize = true;
            this.CorrelationSampleSizeLabel.Location = new System.Drawing.Point(9, 7);
            this.CorrelationSampleSizeLabel.Name = "CorrelationSampleSizeLabel";
            this.CorrelationSampleSizeLabel.Size = new System.Drawing.Size(92, 26);
            this.CorrelationSampleSizeLabel.TabIndex = 19;
            this.CorrelationSampleSizeLabel.Text = "Sample Size\r\n(Number of Pixels)";
            this.CorrelationSampleSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CovarianceWorker
            // 
            this.CovarianceWorker.WorkerReportsProgress = true;
            this.CovarianceWorker.WorkerSupportsCancellation = true;
            this.CovarianceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CovarianceWorker_DoWork);
            this.CovarianceWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CovarianceWorker_ProgressChanged);
            this.CovarianceWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CovarianceWorker_RunWorkerCompleted);
            // 
            // CorrelationWindowStatusStrip
            // 
            this.CorrelationWindowStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarRightSpring,
            this.StatusBarProgressBar});
            this.CorrelationWindowStatusStrip.Location = new System.Drawing.Point(0, 405);
            this.CorrelationWindowStatusStrip.Name = "CorrelationWindowStatusStrip";
            this.CorrelationWindowStatusStrip.Size = new System.Drawing.Size(824, 22);
            this.CorrelationWindowStatusStrip.TabIndex = 20;
            this.CorrelationWindowStatusStrip.Text = "Status Strip";
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
            // CorrelationSampleSize
            // 
            this.CorrelationSampleSize.Location = new System.Drawing.Point(107, 12);
            this.CorrelationSampleSize.Name = "CorrelationSampleSize";
            this.CorrelationSampleSize.Size = new System.Drawing.Size(92, 20);
            this.CorrelationSampleSize.TabIndex = 21;
            this.CorrelationSampleSize.ValueChanged += new System.EventHandler(this.CovarianceSampleSize_ValueChanged);
            // 
            // CovarianceTimer
            // 
            this.CovarianceTimer.Enabled = true;
            this.CovarianceTimer.Interval = 500;
            this.CovarianceTimer.Tick += new System.EventHandler(this.CovarianceTimer_Tick);
            // 
            // HorizontalStatsTextBox
            // 
            this.HorizontalStatsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HorizontalStatsTextBox.Location = new System.Drawing.Point(283, 292);
            this.HorizontalStatsTextBox.Multiline = true;
            this.HorizontalStatsTextBox.Name = "HorizontalStatsTextBox";
            this.HorizontalStatsTextBox.ReadOnly = true;
            this.HorizontalStatsTextBox.Size = new System.Drawing.Size(265, 110);
            this.HorizontalStatsTextBox.TabIndex = 22;
            // 
            // VerticalStatsTextBox
            // 
            this.VerticalStatsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerticalStatsTextBox.Location = new System.Drawing.Point(554, 292);
            this.VerticalStatsTextBox.Multiline = true;
            this.VerticalStatsTextBox.Name = "VerticalStatsTextBox";
            this.VerticalStatsTextBox.ReadOnly = true;
            this.VerticalStatsTextBox.Size = new System.Drawing.Size(267, 110);
            this.VerticalStatsTextBox.TabIndex = 23;
            // 
            // CorrelationTableLayout
            // 
            this.CorrelationTableLayout.ColumnCount = 3;
            this.CorrelationTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.CorrelationTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.CorrelationTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.CorrelationTableLayout.Controls.Add(this.InputImage, 0, 0);
            this.CorrelationTableLayout.Controls.Add(this.VerticalStatsTextBox, 2, 1);
            this.CorrelationTableLayout.Controls.Add(this.HorizontalCorrelationChart, 1, 0);
            this.CorrelationTableLayout.Controls.Add(this.HorizontalStatsTextBox, 1, 1);
            this.CorrelationTableLayout.Controls.Add(this.VerticalCorrelationChart, 2, 0);
            this.CorrelationTableLayout.Controls.Add(this.SampleSizeControlsPanel, 0, 1);
            this.CorrelationTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CorrelationTableLayout.Location = new System.Drawing.Point(0, 0);
            this.CorrelationTableLayout.MinimumSize = new System.Drawing.Size(824, 405);
            this.CorrelationTableLayout.Name = "CorrelationTableLayout";
            this.CorrelationTableLayout.RowCount = 1;
            this.CorrelationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.CorrelationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.CorrelationTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CorrelationTableLayout.Size = new System.Drawing.Size(824, 405);
            this.CorrelationTableLayout.TabIndex = 24;
            // 
            // InputImage
            // 
            this.InputImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InputImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.InputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputImage.Location = new System.Drawing.Point(3, 3);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(274, 283);
            this.InputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InputImage.TabIndex = 16;
            this.InputImage.TabStop = false;
            this.InputImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RightClickSaveImage);
            this.InputImage.MouseLeave += new System.EventHandler(this.InputImage_MouseLeave);
            this.InputImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InputImage_MouseMove);
            // 
            // SampleSizeControlsPanel
            // 
            this.SampleSizeControlsPanel.Controls.Add(this.CorrelationSampleSizeSlider);
            this.SampleSizeControlsPanel.Controls.Add(this.CorrelationSampleSizeLabel);
            this.SampleSizeControlsPanel.Controls.Add(this.CorrelationSampleSize);
            this.SampleSizeControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SampleSizeControlsPanel.Location = new System.Drawing.Point(3, 292);
            this.SampleSizeControlsPanel.Name = "SampleSizeControlsPanel";
            this.SampleSizeControlsPanel.Size = new System.Drawing.Size(274, 110);
            this.SampleSizeControlsPanel.TabIndex = 25;
            // 
            // PixelIntensityLabel
            // 
            this.PixelIntensityLabel.AutoSize = true;
            this.PixelIntensityLabel.BackColor = System.Drawing.SystemColors.Info;
            this.PixelIntensityLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PixelIntensityLabel.Location = new System.Drawing.Point(360, 206);
            this.PixelIntensityLabel.Name = "PixelIntensityLabel";
            this.PixelIntensityLabel.Size = new System.Drawing.Size(105, 15);
            this.PixelIntensityLabel.TabIndex = 25;
            this.PixelIntensityLabel.Text = "x = 0, y = 0, Lum = 0";
            // 
            // SaveImageDialog
            // 
            this.SaveImageDialog.DefaultExt = "png";
            this.SaveImageDialog.Filter = "PNG files|*.png";
            this.SaveImageDialog.Title = "Save Image";
            // 
            // CorrelationDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 427);
            this.Controls.Add(this.PixelIntensityLabel);
            this.Controls.Add(this.CorrelationTableLayout);
            this.Controls.Add(this.CorrelationWindowStatusStrip);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(840, 465);
            this.Name = "CorrelationDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pixel Correlation and Covariance";
            ((System.ComponentModel.ISupportInitialize)(this.VerticalCorrelationChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorizontalCorrelationChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CorrelationSampleSizeSlider)).EndInit();
            this.CorrelationWindowStatusStrip.ResumeLayout(false);
            this.CorrelationWindowStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CorrelationSampleSize)).EndInit();
            this.CorrelationTableLayout.ResumeLayout(false);
            this.CorrelationTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            this.SampleSizeControlsPanel.ResumeLayout(false);
            this.SampleSizeControlsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart VerticalCorrelationChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart HorizontalCorrelationChart;
        private bambit.forms.controls.PictureBoxExtended InputImage;
        private System.Windows.Forms.TrackBar CorrelationSampleSizeSlider;
        private System.Windows.Forms.Label CorrelationSampleSizeLabel;
        private System.ComponentModel.BackgroundWorker CovarianceWorker;
        private System.Windows.Forms.StatusStrip CorrelationWindowStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarRightSpring;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgressBar;
        private System.Windows.Forms.NumericUpDown CorrelationSampleSize;
        private System.Windows.Forms.Timer CovarianceTimer;
        private System.Windows.Forms.TextBox HorizontalStatsTextBox;
        private System.Windows.Forms.TextBox VerticalStatsTextBox;
        private System.Windows.Forms.TableLayoutPanel CorrelationTableLayout;
        private System.Windows.Forms.Panel SampleSizeControlsPanel;
        private System.Windows.Forms.Label PixelIntensityLabel;
        private System.Windows.Forms.SaveFileDialog SaveImageDialog;
    }
}