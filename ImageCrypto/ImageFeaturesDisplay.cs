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
    public partial class ImageFeaturesDisplay : Form
    {
        public ImageFeaturesDisplay (Image input)
        {
            InitializeComponent();

            this.input = new Bitmap (input);
            InputImage.Image = input;

            featuresWorker.RunWorkerAsync();
            StatusBarProgressBar.Visible = true;
            ToolStripStatusLabel.Visible = true;
        }

        private Bitmap input;
        private Bitmap sobel;
        private Bitmap canny;

        private void featuresWorker_DoWork (object sender, DoWorkEventArgs e)
        {
            // The AForge algoritms require an 8 bits per pixel input format.
            Bitmap gray_8bpp
                = AForge.Imaging.Filters.Grayscale.CommonAlgorithms.Y.Apply(input);

            featuresWorker.ReportProgress(0, "Detecting Edges (Sobel)");
            AForge.Imaging.Filters.SobelEdgeDetector sed
                = new AForge.Imaging.Filters.SobelEdgeDetector();
            sobel = sed.Apply(gray_8bpp);

            featuresWorker.ReportProgress(50, "Detecting Edges (Canny)");
            AForge.Imaging.Filters.CannyEdgeDetector ced
                = new AForge.Imaging.Filters.CannyEdgeDetector();
            canny = ced.Apply(gray_8bpp);
        }

        private void featuresWorker_ProgressChanged (object sender, ProgressChangedEventArgs e)
        {
            StatusBarProgressBar.Value = e.ProgressPercentage;
            ToolStripStatusLabel.Text = e.UserState as String;
        }

        private void featuresWorker_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
        {
            SobelEdgesImage.Image = sobel;
            CannyEdgesImage.Image = canny;
            ToolStripStatusLabel.Text = "Done";
            StatusBarProgressBar.Visible = false;
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
