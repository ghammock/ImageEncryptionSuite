using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Imaging;

namespace ImageCrypto
{
    public partial class SpectrumDisplay : Form
    {
        public SpectrumDisplay (System.Drawing.Image input)
        {
            InitializeComponent();

            this.input = new Bitmap (input);
            InputImage.Image = input;

            Cursor.Current = Cursors.WaitCursor;
            ToolStripStatusLabel.Visible = true;
            StatusBarProgressBar.Visible = true;
            SpectraWorker.RunWorkerAsync();
        }

        private Bitmap input;
        private Bitmap fourier;

        private void SpectraWorker_ProgressChanged (object sender, ProgressChangedEventArgs e)
        {
            StatusBarProgressBar.Value = e.ProgressPercentage;
            ToolStripStatusLabel.Text = e.UserState as String;
        }

        private void SpectraWorker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
        {
            FourierImage.Image = fourier;
            Cursor.Current = Cursors.Default;
            ToolStripStatusLabel.Text = "Done";
            StatusBarProgressBar.Visible = false;
        }

        private void SpectraWorker_DoWork (object sender, DoWorkEventArgs e)
        {
            if (input.Width != input.Height)
            {
                throw new System.ApplicationException(
                    "The image height and width must be the same.");
            }

            SpectraWorker.ReportProgress(0, "Computing spectra");

            // The AForge FFT requires an 8 bits per pixel input format.
            Bitmap gray_8bpp
                = AForge.Imaging.Filters.Grayscale.CommonAlgorithms.Y.Apply(input);

            AForge.Imaging.ComplexImage fft
                = ComplexImage.FromBitmap(gray_8bpp);
            fft.ForwardFourierTransform();

            SpectraWorker.ReportProgress(100, "Fourier Spectra Calculated.");
            fourier = fft.ToBitmap();
        }

        private void RightClickSaveImage(object sender, MouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Right)
              && (sender != null))
            {
                if (SaveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    PictureBox pb = sender as PictureBox;
                    Bitmap output = new Bitmap(pb.Image);
                    output.Save(SaveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
    }
}
