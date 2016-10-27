/// <summary>
/// This file contains the implementation of the ChartProperties class.
/// The class is used to parse store, assign, and clone properties of
/// Windows.Forms.DataVisualization.Charting.Chart objects.
/// <para>
/// Created By: Gary Hammock, PE
/// </para>
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageCrypto
{
    /// <summary>
    /// This class implements the ChartProperties class which is used
    /// to parse store, assign, and clone properties of
    /// Windows.Forms.DataVisualization.Charting.Chart objects.
    /// </summary>
    class ChartProperties
    {
        /// <summary>
        /// Empty constructor; instantiates a new ChartProperties object.
        /// </summary>
        public ChartProperties()
        {
            Font defaultFont = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Regular);
            Font boldFont = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold);

            fontSet.Add("titleFont", boldFont);
            fontSet.Add("axisFont", boldFont);
            fontSet.Add("labelFont", boldFont);
            fontSet.Add("valueFont", defaultFont);
            fontSet.Add("legendFont", defaultFont);

            LineWeight = 1;
            MarkerSize = 5;

            resolution.Add("width", 640);
            resolution.Add("height", 480);

            dock = System.Windows.Forms.DockStyle.None;
        }

        /// <summary>
        /// Copy constructor; instantiates a new ChartProperties object
        /// whose values are copied from an existing ChartProperties object.
        /// </summary>
        /// <param name="copy">
        /// The <c>ChartProperties</c> object whose values are to be copied.
        /// </param>
        public ChartProperties(ChartProperties copy)
        {
            fontSet.Add("titleFont", copy.fontSet["titleFont"]);
            fontSet.Add("axisFont", copy.fontSet["axisFont"]);
            fontSet.Add("labelFont", copy.fontSet["labelFont"]);
            fontSet.Add("valueFont", copy.fontSet["valueFont"]);
            fontSet.Add("legendFont", copy.fontSet["legendFont"]);

            LineWeight = copy.LineWeight;
            MarkerSize = copy.MarkerSize;

            dock = copy.dock;

            resolution.Add("width", copy.resolution["width"]);
            resolution.Add("height", copy.resolution["height"]);
        }

        /// <summary>
        /// Retrieve the relevant properties from a given Chart object and store the
        /// </summary>
        /// <param name="chartToClone"></param>
        public void StoreProperties (Chart chartToClone)
        {
            fontSet["titleFont"] = chartToClone.Titles[0].Font;
            fontSet["axisFont"] = chartToClone.ChartAreas[0].AxisX.TitleFont;
            fontSet["labelFont"] = chartToClone.ChartAreas[0].AxisX.LabelStyle.Font;
            fontSet["valueFont"] = chartToClone.Series[0].Font;
            if (chartToClone.Legends.Count > 0)
                fontSet["legendFont"] = chartToClone.Legends[0].Font;

            LineWeight = chartToClone.Series[0].BorderWidth;
            MarkerSize = chartToClone.Series[0].MarkerSize;

            dock = chartToClone.Dock;

            resolution["width"] = chartToClone.Width;
            resolution["height"] = chartToClone.Height;

        }  // End method StoreProperties().

        public void RestoreProperties(ref Chart chart)
        {
            chart.Titles[0].Font = fontSet["titleFont"];
            chart.ChartAreas[0].AxisX.TitleFont = fontSet["axisFont"];
            chart.ChartAreas[0].AxisY.TitleFont = fontSet["axisFont"];
            chart.ChartAreas[0].AxisX.LabelStyle.Font = fontSet["labelFont"];
            chart.ChartAreas[0].AxisY.LabelStyle.Font = fontSet["labelFont"];

            if (chart.Legends.Count > 0)
                chart.Legends[0].Font = fontSet["legendFont"];

            for (int i = 0; i < chart.Series.Count; ++i)
            {
                chart.Series[i].Font = fontSet["valueFont"];
                chart.Series[i].BorderWidth = LineWeight;
                chart.Series[i].MarkerSize = MarkerSize;
            }

            chart.Dock = dock;

            chart.Width = (int)resolution["width"];
            chart.Height = (int)resolution["height"];

        }  // End method RestoreProperties().

        public void Modify(Font titleFont, Font axisFont,
                           Font labelFont,Font valueFont,
                           Font legendFont, int lineWeight,
                           int markerSize,
                           int width, int height,
                           System.Windows.Forms.DockStyle dockstyle)
        {
            fontSet["titleFont"] = titleFont;
            fontSet["axisFont"] = axisFont;
            fontSet["labelFont"] = labelFont;
            fontSet["valueFont"] = valueFont;
            fontSet["legendFont"] = legendFont;

            LineWeight = lineWeight;
            MarkerSize = markerSize;

            dock = dockstyle;

            resolution["width"] = width;
            resolution["height"] = height;

        }  // End method Modify().

        /// <summary>
        /// Clone an existing ChartProperties object to a new assignment.
        /// </summary>
        /// <returns>
        /// A new ChartProperties object whose values are identical
        /// to the calling object.
        /// </returns>
        public ChartProperties Clone()
        {
            return new ChartProperties(this);
        }

        private Chart Clone(Chart chartToClone)
        {
            System.IO.MemoryStream memstream = new System.IO.MemoryStream();
            Chart output = new Chart();
            chartToClone.Serializer.Save(memstream);
            output.Serializer.Load(memstream);

            return output;
        }

        public void ExportChartAsPNG(
            Chart input, string path,
            int imageWidth, int imageHeight)
        {
            // The size of font elements.
            // Assumes 150 dpi, 72 dpi font specification,
            // and arbitrary font scaling ratio (s)
            // [e.g. titles larger than lables].
            //
            // font_size = [72/150] * s * imageHeight
            //    s = (1/20) => 0.024
            //    s = (1/24) => 0.02
            float titlePt = (float)Math.Floor(0.024 * (double)imageHeight);
            float axisPt = (float)Math.Floor(0.02 * (double)imageHeight);
            float valuePt = (float)Math.Floor(0.02 * (double)imageHeight);
            float labelPt = (float)Math.Floor(0.02 * (double)imageHeight);
            float legendPt = (float)Math.Floor(0.02 * (double)imageHeight);

            if ((int)titlePt % 2 != 0) titlePt += 1.0F;
            if ((int)axisPt % 2 != 0) axisPt += 1.0F;
            if ((int)valuePt % 2 != 0) valuePt += 1.0F;
            if ((int)labelPt % 2 != 0) labelPt += 1.0F;
            if ((int)legendPt % 2 != 0) legendPt += 1.0F;

            // Line weights correspond to:
            //    lineWeight = 2 @ imageHeight = 480px
            //    lineWeight = 5 @ imageHeight = 1080px
            int lineWeight
                = (int)(((1.0 / 200.0) * (double)imageHeight) - 0.4);
            if (lineWeight < 1) lineWeight = 1;

            int markerSize
                = (int)Math.Round((((1.0 / 200.0) * (double)imageHeight) + 3.6));
            if (markerSize < 5) markerSize = 5;
            
            // Create scaled fonts for the output image plot.
            Font valueFont;
            Font legendFont;

            Font titleFont = new Font(input.Titles[0].Font.Name,
                titlePt, FontStyle.Bold);

            Font axisFont
                = new Font(input.ChartAreas[0].Axes[0].TitleFont.Name,
                    axisPt, FontStyle.Regular);
         
            Font labelFont
                = new Font(input.ChartAreas[0].Axes[0].
                    LabelStyle.Font.Name, labelPt, FontStyle.Regular);

            if (input.Series.Count > 0)
            {
                valueFont = new Font(input.Series[0].Font.Name,
                    valuePt, FontStyle.Regular);
            }
            else
            {
                valueFont = new Font(FontFamily.GenericSansSerif,
                    valuePt, FontStyle.Regular);
            }

            if (input.Legends.Count > 0)
            {
                legendFont = new Font(input.Legends[0].Font.Name,
                    legendPt, FontStyle.Regular);
            }
            else
            {
                legendFont = new Font(FontFamily.GenericSansSerif,
                    legendPt, FontStyle.Regular);
            }

            ChartProperties imageProps = new ChartProperties();
            imageProps.Modify(titleFont,
                              axisFont,
                              labelFont,
                              valueFont,
                              legendFont,
                              lineWeight,
                              markerSize,
                              imageWidth,
                              imageHeight,
                              System.Windows.Forms.DockStyle.None);

            Chart temp = imageProps.Clone(input);
            imageProps.RestoreProperties(ref temp);
            temp.SaveImage(path, ChartImageFormat.Png);
        }

        /// <summary>
        /// Maps the System.Drawing.Font values to specific types.
        /// </summary>
        private Dictionary<String, Font> fontSet
            = new Dictionary<String, Font>();

        /// <summary>
        /// Stores the line weight for each line in the chart series.
        /// </summary>
        private int LineWeight;

        private int MarkerSize;

        /// <summary>
        /// Stores the width and height of the chart image.
        /// </summary>
        private Dictionary<String, int> resolution
            = new Dictionary<String, int>();

        private System.Windows.Forms.DockStyle dock;

    }  // End class ChartProperties.
}  // End namespace ImageCrypto.
