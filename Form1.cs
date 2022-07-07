using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        //variables
        Point startLocation;
        Point endLocation;
        IShape shape;
        bool isMouseDown;
        enum shapes { ucgen = 3, dortgen = 4, besgen = 5, altıgen = 6, yedigen = 7, daire = 40 };
        int shapeNumber = 0;
        Pen pen = new Pen(Color.Black, 2f);



        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // e.Graphics.DrawRectangle(pen, Math.Min(startLocation.X, endLocation.X), Math.Min(startLocation.Y, endLocation.Y), Math.Abs(endLocation.X - startLocation.X), Math.Abs(endLocation.Y - startLocation.Y));
            //e.Graphics.DrawPolygon(pen, new PolygonDrawer(3, startLocation, endLocation).shapeCornersLocation);


            if (shapeNumber != 0)
            {
                e.Graphics.DrawPolygon(pen, shape.shapeCornersLocation);
                e.Graphics.FillPolygon(pen.Brush, shape.shapeCornersLocation);
            }
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                endLocation = e.Location;
                shape = new PolygonDraw(shapeNumber, startLocation, endLocation);
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            endLocation = e.Location;
            isMouseDown = false;
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            startLocation = e.Location;
            isMouseDown = true;
        }




        //hexagon button
        private void button3_Click(object sender, EventArgs e)
        {
            shapeNumber = ((int)shapes.altıgen);
        }
        //triangle button
        private void button1_Click(object sender, EventArgs e)
        {
            shapeNumber = ((int)shapes.ucgen);
        }
        //rectangle button
        private void button2_Click(object sender, EventArgs e)
        {
            shapeNumber = ((int)shapes.dortgen);
        }
        //pentagon button
        private void button4_Click(object sender, EventArgs e)
        {
            shapeNumber = ((int)shapes.besgen);
        }

        private void heptagon_Click(object sender, EventArgs e)
        {
            shapeNumber = ((int)shapes.yedigen);
        }

        private void circle_Click(object sender, EventArgs e)
        {
            shapeNumber = ((int)shapes.daire);
        }


        private void royaleBlue_Click(object sender, EventArgs e)
        {
            pen.Color = Color.RoyalBlue;
        }

        private void seaGreen_Click(object sender, EventArgs e)
        {
            pen.Color = Color.SeaGreen;

        }

        private void khaki_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Khaki;
        }

        private void red_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red;
        }

        private void darkOrange_Click(object sender, EventArgs e)
        {
            pen.Color = Color.DarkOrange;
        }

        private void darkOrchid_Click(object sender, EventArgs e)
        {
            pen.Color = Color.DarkOrchid;
        }

        private void cyan_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Cyan;
        }

        private void darkCyan_Click(object sender, EventArgs e)
        {
            pen.Color = Color.DarkCyan;
        }

        private void lightSeaGreen_Click(object sender, EventArgs e)
        {
            pen.Color = Color.LightSeaGreen;
        }
    }

}


/*
 saklanan veriler

hangi şekil ve denklemleri

renk

başlangıç noktası, son nokta


 */
/*
 jsonda tutulacak veriler..
    
    renk,konum bilgileri,şekil numarası
 */


/*
 metotlar
draw line
    
 */