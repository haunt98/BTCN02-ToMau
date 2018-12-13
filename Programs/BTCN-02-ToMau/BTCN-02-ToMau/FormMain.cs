using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BTCN_02_ToMau
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        Bitmap bitmapPrimary;
        Bitmap bitmapTemp;

        int mode;
        const int MODE_FILL = 0;
        const int MODE_NOFILL = 1;

        int selectShape;

        List<ShapeObj> shapeObjs = new List<ShapeObj>();

        private void FormMain_Load(object sender, EventArgs e)
        {
            // use bitmap to display image in picture box
            bitmapPrimary = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            clearPictureBoxMain();
            bitmapTemp = null;

            // add info to combo box fill algo
            comboBoxFillAlgo.Items.Add("Scan line");
            comboBoxFillAlgo.Items.Add("Boundary fill");
            comboBoxFillAlgo.Items.Add("Boundary fill without recursive");
            comboBoxFillAlgo.SelectedIndex = 0;

            // add shape type to combo box
            comboBoxShapeType.Items.Add("Polygon");
            comboBoxShapeType.Items.Add("Ellipse");
            comboBoxShapeType.SelectedIndex = 0;

            // set up color
            colorDialogFill.Color = Color.Black;
            buttonDisplayColor.BackColor = colorDialogFill.Color;

            // set mode default
            mode = MODE_NOFILL;

            // set shape index default
            selectShape = -1;
        }

        private void clearPictureBoxMain()
        {
            using (Graphics graphics = Graphics.FromImage(bitmapPrimary))
            {
                graphics.Clear(Color.White);

                // reset to bitmap primary
                pictureBoxMain.Image = bitmapPrimary;
                pictureBoxMain.Invalidate();
            }
        }

        // choose color to fill
        private void buttonDisplayColor_Click(object sender, EventArgs e)
        {
            colorDialogFill.ShowDialog();
            buttonDisplayColor.BackColor = colorDialogFill.Color;
        }

        // switch to fill
        private void buttonFill_Click(object sender, EventArgs e)
        {
            mode = MODE_FILL;
        }

        // switch to no fill
        private void buttonCancelFill_Click(object sender, EventArgs e)
        {
            mode = MODE_NOFILL;

            if (selectShape == -1)
            {
                return;
            }

            if (bitmapTemp != null)
            {
                bitmapTemp.Dispose();
            }
            bitmapTemp = (Bitmap)bitmapPrimary.Clone();

            shapeObjs[selectShape].fillScanLine(bitmapTemp, Color.White);
            shapeObjs[selectShape].draw(bitmapTemp);

            if (bitmapPrimary != null)
            {
                bitmapPrimary.Dispose();
            }
            bitmapPrimary = bitmapTemp;
            bitmapTemp = null;
            pictureBoxMain.Image = bitmapPrimary;
            pictureBoxMain.Invalidate();
        }

        private void buttonRandShape_Click(object sender, EventArgs e)
        {
            clearPictureBoxMain();

            int numShapeRand = Convert.ToInt32(numericUpDownNumShape.Value);

            // use bitmap temp
            if (bitmapTemp != null)
            {
                bitmapTemp.Dispose();
            }
            bitmapTemp = (Bitmap)bitmapPrimary.Clone();

            // reset pre-random shape
            shapeObjs.Clear();

            // seed 
            Random random = new Random();

            if (comboBoxShapeType.SelectedItem.ToString().Equals("Polygon"))
            {
                for (int i = 0; i < numShapeRand; ++i)
                {
                    PolygonObj polygonObj = ShapeBuilder.randPoly(
                        random,
                        pictureBoxMain.Width,
                        pictureBoxMain.Height);
                    shapeObjs.Add(polygonObj);
                    polygonObj.draw(bitmapTemp);
                }
            }
            else
            {
                for (int i = 0; i < numShapeRand; ++i)
                {
                    EllipseObj ellipseObj = ShapeBuilder.randElli(
                        random,
                        pictureBoxMain.Width,
                        pictureBoxMain.Height);
                    shapeObjs.Add(ellipseObj);
                    ellipseObj.draw(bitmapTemp);
                }
            }

            // bitmap primary copy from bitmap temp
            if (bitmapPrimary != null)
            {
                bitmapPrimary.Dispose();
            }
            bitmapPrimary = bitmapTemp;
            bitmapTemp = null;
            pictureBoxMain.Image = bitmapPrimary;
            pictureBoxMain.Invalidate();
        }

        // clear picture box to white
        private void buttonReset_Click(object sender, EventArgs e)
        {
            clearPictureBoxMain();
            bitmapTemp = null;
            shapeObjs.Clear();
        }

        // actually fill on shape
        private void onMouseClickFill(object sender, MouseEventArgs e)
        {
            if (mode != MODE_FILL)
            {
                return;
            }

            for (selectShape = shapeObjs.Count - 1; selectShape >= 0; --selectShape)
            {
                if (shapeObjs[selectShape].isApproxPointInside(new Point(e.X, e.Y)))
                {
                    break;
                }
            }

            // dont fill background for now
            if (selectShape == -1)
            {
                return;
            }

            if (bitmapTemp != null)
            {
                bitmapTemp.Dispose();
            }
            bitmapTemp = (Bitmap)bitmapPrimary.Clone();

            // fill timer
            Stopwatch stopwatch = Stopwatch.StartNew();

            if (comboBoxFillAlgo.SelectedItem.ToString().Equals("Scan line"))
            {
                stopwatch.Restart();
                shapeObjs[selectShape].fillScanLine(bitmapTemp, colorDialogFill.Color);
                stopwatch.Stop();
                shapeObjs[selectShape].draw(bitmapTemp);
            }
            else if (comboBoxFillAlgo.SelectedItem.ToString().Equals("Boundary fill"))
            {
                stopwatch.Restart();
                shapeObjs[selectShape].fillBoundary(bitmapTemp, colorDialogFill.Color, Color.Black);
                stopwatch.Stop();
                shapeObjs[selectShape].draw(bitmapTemp);
            }
            else if (comboBoxFillAlgo.SelectedItem.ToString().Equals("Boundary fill without recursive"))
            {
                stopwatch.Restart();
                shapeObjs[selectShape].fillBoundaryNoRecursive(bitmapTemp, colorDialogFill.Color, Color.Black);
                stopwatch.Stop();
                shapeObjs[selectShape].draw(bitmapTemp);
            }

            textBoxFillTimer.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";

            if (bitmapPrimary != null)
            {
                bitmapPrimary.Dispose();
            }
            bitmapPrimary = bitmapTemp;
            bitmapTemp = null;
            pictureBoxMain.Image = bitmapPrimary;
            pictureBoxMain.Invalidate();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Choose fill algorithm then choose shape type"
                + Environment.NewLine
                + "Type number of shape you want to fill, then press button Random Shape,"
                + "shapes will appear in windows."
                + Environment.NewLine
                + Environment.NewLine
                + "Choose color by pressing the button which its color is black."
                + Environment.NewLine
                + "Press button Fill then click on shape you want to fill."
                + Environment.NewLine
                + "Press button Cancel Fill if you want un-fill the shape you've just filled."
                + Environment.NewLine
                + Environment.NewLine
                + "After filling, timer will show how long the computer takes to fill the select shape.",
                "Help");
        }
    }
}
