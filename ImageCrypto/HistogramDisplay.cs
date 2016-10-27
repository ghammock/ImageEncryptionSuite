using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImageCrypto
{
    public partial class HistogramDisplay : Form
    {
        public HistogramDisplay (Image input)
        {
            InitializeComponent();

            this.input = new Bitmap(input);
            InputImage.Image = input;

            PixelIntensityLabel.Visible = false;

            Cursor.Current = Cursors.WaitCursor;
            GetHistCounts();
            Cursor.Current = Cursors.Default;
        }

        private Bitmap input;
        private int average;
        private int stdDev;
        private double entropy;

        public void GetHistCounts()
        {
            average = 0;
            double variance = 0;

            int[] luminance = GetHistogram(input);
            int numPixels = luminance.Sum();

            for (int i = 0; i < luminance.Length; ++i)
            {
                if (luminance[i] > 0)
                    average += (i * luminance[i]);
            }

            average /= numPixels;

            for (int x = 0; x < input.Width; ++x)
            {
                for (int y = 0; y < input.Height; ++y)
                {
                    int residual = GetLuminance(x, y) - average;
                    variance += Math.Pow((double)residual, 2.0);
                }
            }

            variance /= numPixels;
            stdDev = (int)Math.Round(Math.Sqrt(variance), 0);

            double chiSquared = 0;

            Histogram.Series["Luminance"].Points.DataBindY(luminance);

            entropy = CalculateEntropy(luminance);
            chiSquared = CalculateChiSquared(luminance);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Image Statistics");
            sb.AppendLine("Width: " + input.Width.ToString() + " px");
            sb.AppendLine("Height: " + input.Height.ToString() + " px");
            sb.AppendLine("Total pixels: " + numPixels.ToString());
            sb.AppendLine("Average Luminance: " + average.ToString());
            sb.AppendLine("Standard Deviation: " + stdDev.ToString());
            sb.AppendLine("Entropy: " + entropy.ToString());
            sb.AppendLine("Chi-Squared Value: " + chiSquared.ToString("F2"));

            ImageStats.Text = sb.ToString();
        }

        private double CalculateEntropy(int[] histogram)
        {
            double entropy = 0;
            int total = histogram.Sum();

            // Convert the histogram (i.e. frequency distribution) into
            // a probability distribution function (PDF).
            double[] pdf = new double[256];
            for (int i = 0; i < histogram.Length; ++i)
                pdf[i] = (double)histogram[i] / (double)total;

            for (int i = 0; i < pdf.Length; ++i)
            {
                if (pdf[i] > 0)
                    entropy += pdf[i] * Math.Log(pdf[i], 2.0);
            }

            entropy *= -1;

            return entropy;
        }

        private double CalculateChiSquared(int[] histogram)
        {
            double chiSquared = 0;
            int total = histogram.Sum();

            double udf = (double)total / 256.0;

            for (int i = 0; i < histogram.Length; ++i)
            {
                chiSquared += Math.Pow((double)histogram[i] - udf, 2.0)
                                / udf;
            }

            return chiSquared;
        }

        private int[] GetHistogram(Bitmap image)
        {
            int[] luminance = new int[256];

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                    ++luminance[GetLuminance(x, y)];
            }

            return luminance;
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

        private void OutputHistogramButton_Click(object sender, EventArgs e)
        {
            if (SaveHistogramDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String filename = SaveHistogramDialog.FileName;
                StreamWriter writer = new StreamWriter(filename);


                for (int i = 0; i < 256; ++i)
                {
                    writer.WriteLine(i.ToString() + ","
                        + Histogram.Series["Luminance"].Points[i].YValues[0].ToString());
                }

                writer.Close();
            }
        }
    }
}
