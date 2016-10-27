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
using System.Diagnostics;

using ImageEncryption.BioInspired;
using ImageEncryption.CellularAutomata;
using ImageEncryption.FluidDynamicsInspired;

namespace ImageCrypto
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            plaintextHist = new int[256];
            ciphertextHist = new int[256];

            proc = Process.GetCurrentProcess();
        }

        private BioInspiredEncryptor bio;
        private CellularAutomataEncryptor ca;
        private FluidDynamicsEncryptor fd;

        private int[] plaintextHist;
        private int[] ciphertextHist;
        Process proc;

        private void PlaintextCorrelationButton_Click (object sender, EventArgs e)
        {
            CorrelationDisplay cd = new CorrelationDisplay(PlainText_Image.Image);
            cd.Show();
        }

        private void CiphertextCorrelationButton_Click (object sender, EventArgs e)
        {
            CorrelationDisplay cd = new CorrelationDisplay(Ciphertext_Image.Image);
            cd.Show();
        }

        private void PlaintextHistogramButton_Click (object sender, EventArgs e)
        {
            HistogramDisplay hd = new HistogramDisplay(PlainText_Image.Image);
            hd.Show();
        }

        private void CiphertextHistogramButton_Click (object sender, EventArgs e)
        {
            HistogramDisplay hd = new HistogramDisplay(Ciphertext_Image.Image);
            hd.Show();
        }

        private void PlaintextSpectraButton_Click (object sender, EventArgs e)
        {
            SpectrumDisplay sd = new SpectrumDisplay(PlainText_Image.Image);
            sd.Show();
        }

        private void CiphertextSpectraButton_Click (object sender, EventArgs e)
        {
            SpectrumDisplay sd = new SpectrumDisplay(Ciphertext_Image.Image);
            sd.Show();
        }

        private void PlaintextFeaturesButton_Click (object sender, EventArgs e)
        {
            ImageFeaturesDisplay ifd = new ImageFeaturesDisplay(PlainText_Image.Image);
            ifd.Show();
        }

        private void CiphertextFeaturesButton_Click (object sender, EventArgs e)
        {
            ImageFeaturesDisplay ifd = new ImageFeaturesDisplay(Ciphertext_Image.Image);
            ifd.Show();
        }

        private void openImageButton_Click (object sender, EventArgs e)
        {
            OpenImage();
        }

        private void OpenImage()
        {
            if (OpenImageDialog.ShowDialog() == DialogResult.OK)
            {
                String path = OpenImageDialog.FileName;
                Image inputImage = Image.FromFile(path);
                PlainText_Image.Image = inputImage;

                if (inputImage != null)
                {
                    PlainText_Image.Image = inputImage;

                    PlaintextCorrelationButton.Enabled = true;
                    PlaintextHistogramButton.Enabled = true;
                    PlaintextSpectraButton.Enabled = true;
                    PlaintextFeaturesButton.Enabled = true;

                    BioEncryptButton.Enabled = true;
                    CAEncryptButton.Enabled = true;
                    FDEncryptButton.Enabled = true;
                }
            }
        }

        private void BioEncryptButton_Click (object sender, EventArgs e)
        {
            MicroLibrary.MicroStopwatch utimer = new MicroLibrary.MicroStopwatch();

            Image inputImage = PlainText_Image.Image;
            String path = OpenImageDialog.FileName;

            //Bitmap secretImage = ImageEncryption.
            //    ImageEncryption.GenerateSecretImage(inputImage.Size);

            SecretImageSelection sis = new SecretImageSelection(inputImage as Bitmap);
            sis.ShowDialog();

            if (sis.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            Bitmap secretImage = sis.SecretImage;

            // Key from the paper.
            BioInspiredKey bioKey = new BioInspiredKey(
                3.7158, 0.11, 3.89858, 0.25,
                3.76158, 0.35, 3.8458, 0.552,
                secretImage);

            bio = new BioInspiredEncryptor((Bitmap)inputImage, bioKey);
            bio.Filename = path.Substring(path.LastIndexOf('\\') + 1);

            utimer.Start();
            bio.Encrypt();
            utimer.Stop();

            long mem = proc.PrivateMemorySize64;
            EncryptionFinishedActions(bio.CiphertextImage, utimer.ElapsedMicroseconds, mem);
        }

        private void CAEncryptButton_Click (object sender, EventArgs e)
        {
            MicroLibrary.MicroStopwatch utimer = new MicroLibrary.MicroStopwatch();

            Image inputImage = PlainText_Image.Image;
            String path = OpenImageDialog.FileName;

            CellularAutomataKey caKey = new CellularAutomataKey(42, 53, 15);
            ca = new CellularAutomataEncryptor((Bitmap)inputImage, caKey);
            ca.Filename = path.Substring(path.LastIndexOf('\\') + 1);

            utimer.Start();
            ca.Encrypt();
            utimer.Stop();

            long mem = proc.PrivateMemorySize64;
            EncryptionFinishedActions(ca.CiphertextImage, utimer.ElapsedMicroseconds, mem);
        }

        private void FDEncryptButton_Click (object sender, EventArgs e)
        {
            MicroLibrary.MicroStopwatch utimer = new MicroLibrary.MicroStopwatch();

            Image inputImage = PlainText_Image.Image;
            String path = OpenImageDialog.FileName;
            //Bitmap secretImage = ImageEncryption.ImageEncryption.GenerateSecretImage(inputImage.Size);

            SecretImageSelection sis = new SecretImageSelection(inputImage as Bitmap);
            sis.ShowDialog();

            if (sis.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            Bitmap secretImage = sis.SecretImage;

            FluidDynamicsKey fdKey = new FluidDynamicsKey(3.717, 0.55, 3.8222, 0.18, 199, 17, 32, secretImage);
            fd = new FluidDynamicsEncryptor((Bitmap)inputImage, fdKey);
            fd.Filename = path.Substring(path.LastIndexOf('\\') + 1);

            utimer.Start();
            fd.Encrypt();
            utimer.Stop();

            long mem = proc.PrivateMemorySize64;
            EncryptionFinishedActions(fd.CiphertextImage, utimer.ElapsedMicroseconds, mem);
        }

        void EncryptionFinishedActions(Bitmap toLoad, long stopwatchTime, long memory)
        {
            Ciphertext_Image.Image = toLoad;

            CiphertextCorrelationButton.Enabled = true;
            CiphertextHistogramButton.Enabled = true;
            CiphertextSpectraButton.Enabled = true;
            CiphertextFeaturesButton.Enabled = true;

            Decimal elapsed = stopwatchTime;
            String unit = "µs";

            Decimal memUsed = memory;
            String memUnit = "B";

            if (stopwatchTime > 1000000)
            {
                elapsed = (Decimal)((double)stopwatchTime / 1000000.0);
                elapsed = Math.Round(elapsed, 2);
                unit = "s";
            }
            else if (stopwatchTime > 1000)
            {
                elapsed = stopwatchTime / 1000;
                unit = "ms";
            }

            if (memory > Math.Pow(2, 30))
            {
                memUsed = (Decimal)(memory / Math.Pow(2, 30));
                memUnit = "GB";
            }
            else if (memory > Math.Pow(2, 20))
            {
                memUsed = (Decimal)(memory / Math.Pow(2, 20));
                memUnit = "MB";
            }
            else if (memory > Math.Pow(2, 10))
            {
                memUsed = (Decimal)(memory / Math.Pow(2, 10));
                memUnit = "KB";
            }

            MemoryUsageLabel.Visible = true;
            MemoryUsageLabel.Text = "Memory Used: " + memUsed.ToString("F1") + " " + memUnit;

            EncryptionTimeLabel.Visible = true;
            EncryptionTimeLabel.Text = "Encryption Time: " + elapsed.ToString() + " " + unit;

            Bitmap pimg = PlainText_Image.Image as Bitmap;
            Bitmap cimg = Ciphertext_Image.Image as Bitmap;

            for (int x = 0; x < pimg.Width; ++x)
            {
                for (int y = 0; y < pimg.Height; ++y)
                {
                    int lum = (int)Math.Round(255 * pimg.GetPixel(x, y).GetBrightness(), 0);
                    ++plaintextHist[lum];
                }
            }

            for (int x = 0; x < cimg.Width; ++x)
            {
                for (int y = 0; y < cimg.Height; ++y)
                {
                    int lum = (int)Math.Round(255 * cimg.GetPixel(x, y).GetBrightness(), 0);
                    ++ciphertextHist[lum];
                }
            }
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
    }  // End class MainWindow.
}
