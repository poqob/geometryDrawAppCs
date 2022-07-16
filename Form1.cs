using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;

namespace paint
{
    public partial class Form1 : Form
    {
        //variables
        Point startLocation;
        Point endLocation;
        Polygon shape;
        bool isMouseDown;
        Consts.Shapes choosedShape;
        Pen pen;
        Graphics g;
        Graphics l;
        Bitmap bm;

        //constructor for form1.
        public Form1()
        {
            InitializeComponent();
            choosedShape = Consts.Shapes.noShape;
            Consts.programMod = Consts.ProgramMode.choosing;
            pen = new Pen(Color.Black, 2f);
            PaintManagement.tempJsonCreator();
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);
            PaintManagement.jsonCleaner(ref g);
            pictureBox1.Image = bm;
        }

        //destructor for form1.
        ~Form1()
        {
            PaintManagement.jsonExplode();
        }


        //painting
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            endLocation = e.Location;
            pictureBox1.Refresh();
        }
        //stop painting
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            endLocation = e.Location;
            isMouseDown = false;
            /*if (Consts.programMod == Consts.ProgramMode.stopDrawing)
            {
                Consts.programMod = Consts.ProgramMode.draw;
            }*/

            if (shape != null)
            {
                PaintManagement.jsonWriter(ref shape, pen.Color);
            }
            if (choosedShape != Consts.Shapes.noShape && Consts.programMod == Consts.ProgramMode.draw)
            {
                shape.endPoint = endLocation;
                shape.drawController();
                g.DrawPolygon(pen, shape.shapeCornerPoints);
                g.FillPolygon(pen.Brush, shape.shapeCornerPoints);
                shape.selectablePart(ref pictureBox1);
            }


        }
        //start painting
        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            startLocation = e.Location;
            Consts.paintAreaBoundPointsDedector(pictureBox1.Size);
            //i only allow you to draw with left mouse button.
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
            }

            if (Consts.programMod == Consts.ProgramMode.stopDrawing)
            {
                Consts.programMod = Consts.ProgramMode.draw;
            }
            if (isMouseDown && choosedShape != Consts.Shapes.noShape && Consts.programMod == Consts.ProgramMode.draw)
            {
                shape = new Polygon(((int)choosedShape), startLocation, endLocation);
            }
        }



        //attemting button's color property to pen's color property.
        private void colorChooseClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            pen.Color = b.BackColor;
            PaintManagement.colorButtonBackround(ref b, ref groupBox2);
        }

        //choosing which shape clicked.
        private void shapeButtonsClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string name = b.Name;
            switch (name)
            {
                case "triangle":
                    choosedShape = Consts.Shapes.triangle;
                    break;
                case "rectangle":
                    choosedShape = Consts.Shapes.rectangle;
                    break;
                case "pentagon":
                    choosedShape = Consts.Shapes.pentagon;
                    break;
                case "hexagon":
                    choosedShape = Consts.Shapes.hexagon;
                    break;
                case "heptagon":
                    choosedShape = Consts.Shapes.heptagon;
                    break;
                case "circle":
                    choosedShape = Consts.Shapes.circle;
                    break;
                default:
                    choosedShape = Consts.Shapes.noShape;
                    break;
            }
            PaintManagement.shapeButtonBackround(ref b, ref groupBox1);
        }



        //draw mode controller.
        //throws ui exeptions while program is running. pick shape and pick color.
        private void pencil_Click(object sender, EventArgs e)
        {
            if (choosedShape == Consts.Shapes.noShape)
            {
                MessageBox.Show("You can't paint without choosing a shape, pick one.", "paint");
            }
            else if (pen.Color == Color.Black)
            {
                MessageBox.Show("You can't paint without any color, pick one.", "paint");
            }
            else
            {
                Button b = (Button)sender;
                Consts.programMod = Consts.ProgramMode.draw;
                PaintManagement.modeButtonBackround(ref b, ref groupBox4);
            }
            //IShapes-Polygonses controller make them unvisible.
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Visible = false;
            }
        }

        private void recyle_Click(object sender, EventArgs e)
        {
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Dispose();
            }
            PaintManagement.jsonCleaner(ref g);
            pictureBox1.Refresh();

        }

        private void choose_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Consts.programMod = Consts.ProgramMode.choosing;
            PaintManagement.modeButtonBackround(ref b, ref groupBox4);
            //IShapes-Polygonses controller make them visible.
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Visible = true;
            }

            //shape.selectablePart(ref this.pictureBox1);

        }

        private void openFileButton(object sender, EventArgs e)
        {
            PaintManagement.openPaintFromFolder(ref g);
        }

        private void saveFileButton(object sender, EventArgs e)
        {
            PaintManagement.savePaintToFolder(ref g);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            l = e.Graphics;
            if (isMouseDown && Consts.programMod == Consts.ProgramMode.draw)
            {
                shape.endPoint = endLocation;
                shape.drawController();
                l.DrawPolygon(pen, shape.shapeCornerPoints);
                l.FillPolygon(pen.Brush, shape.shapeCornerPoints);
            }
        }
    }
}


// TODO:
//create selectable IShapes.







//STATUS:
//working on bitmaps, may i found a way to save a selectable shape in it.
//**may i use label as container because it has click property.++


