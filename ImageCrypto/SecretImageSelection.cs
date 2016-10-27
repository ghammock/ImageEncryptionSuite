using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCrypto
{
    public partial class SecretImageSelection : Form
    {
        public SecretImageSelection(Bitmap PlaintextImage)
        {
            InitializeComponent();
            plaintextSize = PlaintextImage.Size;

            ConfirmButton.Enabled = false;
            EntropyLabel.Visible = false;
            ChiSquaredLabel.Visible = false;
        }

        public Bitmap SecretImage{ get { return secretImage; } }

        private Bitmap secretImage;
        private Size plaintextSize;

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            if (OpenImageDialog.ShowDialog() == DialogResult.OK)
            {
                Image selectedImage = Image.FromFile(OpenImageDialog.FileName);

                secretImage = new Bitmap(selectedImage, plaintextSize);
                SecretImageBox.Image = secretImage as Image;

                CalculateAndShowStats();
            }
        }

        private void RandomImageButton_Click(object sender, EventArgs e)
        {
            secretImage = ImageEncryption.ImageEncryption.GenerateSecretImage(plaintextSize);
            SecretImageBox.Image = secretImage as Image;

            CalculateAndShowStats();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
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

        private void CalculateAndShowStats()
        {
            ConfirmButton.Enabled = true;

            int[] histogram = GetHistogram(secretImage);
            double entropy = CalculateEntropy(histogram);
            double chiSquared = CalculateChiSquared(histogram);

            EntropyLabel.Text = "Entropy: " + entropy.ToString("F3") + " bits";
            EntropyLabel.Visible = true;

            ChiSquaredLabel.Text = "Chi-Squared: " + chiSquared.ToString("F3");
            ChiSquaredLabel.Visible = true;
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

        private int GetLuminance(int x, int y)
        {
            return (int)Math.Round(
                255 * secretImage.GetPixel(x, y).GetBrightness(),
                0);
        }
    }
}
