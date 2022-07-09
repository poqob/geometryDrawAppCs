using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        Consts.Shapes choosedShape;
        Consts.ProgramMode programMod;

        //pen stores color attribute it also has brush property.
        Pen pen;
        Graphics g;


        public Form1()
        {
            InitializeComponent();
            choosedShape = Consts.Shapes.noShape;
            programMod = Consts.ProgramMode.choosing;
            endLocation.X = -1;
            endLocation.Y = -1;
            pen = new Pen(Color.Black, 2f);
            g = pictureBox1.CreateGraphics();
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Consts.paintAreaBoundPointsDedector(pictureBox1.Size);
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && endLocation.X != -1 && endLocation.Y != -1 && choosedShape != Consts.Shapes.noShape && programMod == Consts.ProgramMode.draw)
            {
                endLocation = e.Location;
                shape = new Polygon(((int)choosedShape), startLocation, endLocation);
                g.DrawPolygon(pen, shape.shapeCornerPoints);
                g.FillPolygon(pen.Brush, shape.shapeCornerPoints);
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
            endLocation = e.Location;
            //we only allow to draw with left mouse button.
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
            }



        }




        //hexagon button
        private void button3_Click(object sender, EventArgs e)
        {
            choosedShape = Consts.Shapes.altıgen;
        }
        //triangle button
        private void button1_Click(object sender, EventArgs e)
        {
            choosedShape = Consts.Shapes.ucgen;
        }
        //rectangle button
        private void button2_Click(object sender, EventArgs e)
        {
            choosedShape = Consts.Shapes.dortgen;
        }
        //pentagon button
        private void button4_Click(object sender, EventArgs e)
        {
            choosedShape = Consts.Shapes.besgen;
        }

        private void heptagon_Click(object sender, EventArgs e)
        {
            choosedShape = Consts.Shapes.yedigen;
        }

        private void circle_Click(object sender, EventArgs e)
        {
            choosedShape = Consts.Shapes.daire;
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

        private void pencil_Click(object sender, EventArgs e)
        {
            programMod = Consts.ProgramMode.draw;
        }

        private void recyle_Click(object sender, EventArgs e)
        {
            programMod = Consts.ProgramMode.clear;
            g.Clear(Color.OldLace);
            //will do something TODO:
        }

        private void choose_Click(object sender, EventArgs e)
        {
            programMod = Consts.ProgramMode.choosing;
        }

    }
}


/*
 TODO:

-will set the paint area bounds
-create save system
-make menu choosable PrograMode.choosing
-make delete object from paint area or delete everything in paint area PrograMode.recyle

 */