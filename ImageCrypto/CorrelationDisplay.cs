using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImageCrypto
{
    public partial class CorrelationDisplay : Form
    {
        public CorrelationDisplay (Image input)
        {
            InitializeComponent();

            this.input = new Bitmap(input);
            InputImage.Image = input;

            int pixelCount = input.Width * input.Height;

            sampleSize = Math.Max(100, (int)Math.Sqrt(pixelCount));
            dataIsInvalid = false;
            initialLoad = true;

            PixelIntensityLabel.Visible = false;

            CorrelationSampleSizeSlider.Maximum
                = Math.Min(Math.Max(100, pixelCount / 64), pixelCount);
            CorrelationSampleSizeSlider.Minimum = Math.Min(100, pixelCount);
            CorrelationSampleSizeSlider.Value = sampleSize;
            CorrelationSampleSizeSlider.TickFrequency = sampleSize / 10;
            CorrelationSampleSizeSlider.LargeChange = sampleSize / 20;

            CorrelationSampleSize.Maximum
                = Math.Min(Math.Max(100, pixelCount / 64), pixelCount);
            CorrelationSampleSize.Minimum = Math.Min(100, pixelCount);
            CorrelationSampleSize.Value = sampleSize;

            initialLoad = false;
            CalculateCorrelations();
        }

        Bitmap input;
        bool initialLoad;

        int [] x;
        int [] y;

        int [] xy;
        int [] xy_hor;
        int [] xy_ver;

        int sampleSize;
        double expectedValueXY,
               expectedValueXYHor,
               expectedValueXYVer;

        double varianceXY,
               varianceXYHor,
               varianceXYVer;

        double covarianceXYHor,
               covarianceXYVer;

        double correlationCoeffHor,
               correlationCoeffVer;

        bool dataIsInvalid;

        private void CalculateCorrelations()
        {
            StatusBarProgressBar.Visible = true;

            if(!CovarianceWorker.IsBusy)
                CovarianceWorker.RunWorkerAsync();

            Cursor.Current = Cursors.WaitCursor;
        }

        private void CovarianceWorker_DoWork (object sender, DoWorkEventArgs e)
        {
            int progress = 0;
            int maxSteps = 3 * sampleSize;
            int step;

            x = new int [sampleSize];
            y = new int [sampleSize];

            xy = new int [sampleSize];
            xy_hor = new int [sampleSize];
            xy_ver = new int [sampleSize];

            Random rand = new Random();

            step = 1;
            for (int i = 0; i < sampleSize && !e.Cancel; ++i)
            {
                x[i] = rand.Next(0, input.Width - 1);
                y[i] = rand.Next(0, input.Height - 1);

                xy[i] = ArgbToY(input.GetPixel(x[i], y[i]));

                if (x[i] > 0)
                    xy_hor[i] = ArgbToY(input.GetPixel(x[i] - 1, y[i]));
                else
                    xy_hor[i] = ArgbToY(input.GetPixel(x[i] + 1, y[i]));

                if (y[i] > 0)
                    xy_ver[i] = ArgbToY(input.GetPixel(x[i], y[i] - 1));
                else
                    xy_ver[i] = ArgbToY(input.GetPixel(x[i], y[i] + 1));

                if (i % 10 == 0)
                {
                    progress = (i * step * 100) / maxSteps;
                    CovarianceWorker.ReportProgress(progress);
                }
            }

            if (e.Cancel) return;

            step = 2;
            expectedValueXY = 0;
            expectedValueXYHor = 0;
            expectedValueXYVer = 0;
            for (int i = 0; i < sampleSize && !e.Cancel; ++i)
            {
                expectedValueXY += (double)xy[i];
                expectedValueXYHor += (double)xy_hor[i];
                expectedValueXYVer += (double)xy_ver[i];

                if (i % 10 == 0)
                {
                    progress = (i * step * 100) / maxSteps;
                    CovarianceWorker.ReportProgress(progress);
                }
            }

            if (e.Cancel) return;

            expectedValueXY /= (double)sampleSize;
            expectedValueXYHor /= (double)sampleSize;
            expectedValueXYVer /= (double)sampleSize;

            step = 3;
            varianceXY = 0;
            varianceXYHor = 0;
            varianceXYVer = 0;
            covarianceXYHor = 0;
            covarianceXYVer = 0;
            for (int i = 0; i < sampleSize && !e.Cancel; ++i)
            {
                double residual = (double)xy[i] - expectedValueXY;
                double residualHor = (double)xy_hor[i] - expectedValueXY;
                double residualVer = (double)xy_ver[i] - expectedValueXY;

                varianceXY += Math.Pow(residual, 2.0);
                varianceXYHor += Math.Pow(residualHor, 2.0);
                varianceXYVer += Math.Pow(residualVer, 2.0);

                covarianceXYHor += (residual * residualHor);
                covarianceXYVer += (residual * residualVer);

                if (i % 10 == 0)
                {
                    progress = (i * step * 100) / maxSteps;
                    CovarianceWorker.ReportProgress(progress);
                }
            }

            if (e.Cancel) return;

            varianceXY /= (double)sampleSize;
            varianceXYHor /= (double)sampleSize;
            varianceXYVer /= (double)sampleSize;
            covarianceXYHor /= (double)sampleSize;
            covarianceXYVer /= (double)sampleSize;

            correlationCoeffHor = covarianceXYHor
                / (Math.Sqrt(varianceXY) * Math.Sqrt(varianceXYHor));
            correlationCoeffVer = covarianceXYVer
                / (Math.Sqrt(varianceXY) * Math.Sqrt(varianceXYVer));

        }  // End method CovarianceWorker_DoWork().

        private void CovarianceWorker_ProgressChanged (object sender, ProgressChangedEventArgs e)
        {
            StatusBarProgressBar.Value = e.ProgressPercentage;
        }

        private void CovarianceSampleSizeSlider_Scroll (object sender, EventArgs e)
        {
            CorrelationSampleSize.Value = CorrelationSampleSizeSlider.Value;
        }

        private void CovarianceSampleSize_ValueChanged (object sender, EventArgs e)
        {
            CorrelationSampleSizeSlider.Value = (int)CorrelationSampleSize.Value;

            if (!initialLoad)
                dataIsInvalid = true;
        }

        private int ArgbToY (Color input)
        {
            if (input.R != input.G && input.G != input.B)
            {
                double luminance =   (0.299 * input.R)
                                   + (0.587 * input.G)
                                   + (0.114 * input.B);

                return (int)luminance;
            }
            else
                return input.ToArgb() & 0x000000ff;
        }

        private void CovarianceWorker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
        {
            StatusBarProgressBar.Visible = false;
            HorizontalCorrelationChart.Series[0].Points.DataBindXY(xy, xy_hor);
            VerticalCorrelationChart.Series[0].Points.DataBindXY(xy, xy_ver);

            StringBuilder sb = new StringBuilder();
            sb.Append("Expected Value, μ(x): ");
            sb.AppendLine(expectedValueXYHor.ToString("G3"));
            sb.Append("Variance, V(x): ");
            sb.AppendLine(varianceXYHor.ToString("G3"));
            sb.Append("Standard Deviation, σ(x): ");
            sb.AppendLine(Math.Sqrt(varianceXYHor).ToString("G3"));
            sb.Append("Covariance, C(x, y): ");
            sb.AppendLine(covarianceXYHor.ToString("G3"));
            sb.Append("Correlation Coefficient, r(x, y): ");
            sb.AppendLine(correlationCoeffHor.ToString("G5"));

            HorizontalStatsTextBox.Text = sb.ToString();

            sb.Clear();
            sb.Append("Expected Value, μ(x): ");
            sb.AppendLine(expectedValueXYVer.ToString("G3"));
            sb.Append("Variance, V(x): ");
            sb.AppendLine(varianceXYVer.ToString("G3"));
            sb.Append("Standard Deviation, σ(x):");
            sb.AppendLine(Math.Sqrt(varianceXYVer).ToString("G3"));
            sb.Append("Covariance, C(x, y): ");
            sb.AppendLine(covarianceXYVer.ToString("G3"));
            sb.Append("Correlation Coefficient, r(x, y): ");
            sb.AppendLine(correlationCoeffVer.ToString("G5"));

            VerticalStatsTextBox.Text = sb.ToString();

            Cursor.Current = Cursors.Default;
        }

        private void CovarianceTimer_Tick (object sender, EventArgs e)
        {
            if (dataIsInvalid)
            {
                if (CovarianceWorker.IsBusy)
                    CovarianceWorker.CancelAsync();

                sampleSize = (int)CorrelationSampleSize.Value;
                CalculateCorrelations();

                dataIsInvalid = false;
            }
        }

        private int GetLuminance (int x, int y)
        {
            return (int)Math.Round(
                255 * input.GetPixel(x, y).GetBrightness(),
                0);
        }

        private void InputImage_MouseMove (object sender, MouseEventArgs e)
        {
            Point imagePoint = InputImage.TranslatePointToImageCoordinates(e.Location);

            if ((imagePoint.X >= 0) && (imagePoint.X < InputImage.Image.Width)
             && (imagePoint.Y >= 0) && (imagePoint.Y < InputImage.Image.Height))
            {
                PixelIntensityLabel.Visible = true;
                PixelIntensityLabel.Location = new Point(e.X + 10, e.Y + 10);
                PixelIntensityLabel.Text = "(" + imagePoint.X.ToString()
                                          + ", " + imagePoint.Y.ToString()
                                          + ") Lum = "
                                          + GetLuminance(imagePoint.X, imagePoint.Y).ToString();
            }
            else
                PixelIntensityLabel.Visible = false;
        }

        private void InputImage_MouseLeave (object sender, EventArgs e)
        {
            PixelIntensityLabel.Visible = false;
        }

        private void RightClickSaveImage(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right)
              && (sender != null))
            {
                if (SaveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    if (sender is PictureBox)
                    {
                        PictureBox pb = sender as PictureBox;
                        Bitmap output = new Bitmap(pb.Image);
                        output.Save(SaveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    else if (sender is System.Windows.Forms.DataVisualization.Charting.Chart)
                    {
                        System.Windows.Forms.DataVisualization.Charting.Chart chart
                           = sender as System.Windows.Forms.DataVisualization.Charting.Chart;
                        ChartProperties chartprops = new ChartProperties();
                        chartprops.ExportChartAsPNG(chart, SaveImageDialog.FileName, 800, 800);
                    }
                }
            }
        }
    }
}
