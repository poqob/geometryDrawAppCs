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
        Polygon shape;
        bool isMouseDown;
        Graphics g;
        Graphics l;
        Bitmap bm;

        //constructor for form1.
        public Form1()
        {
            InitializeComponent();
            Consts.choosedShape = Consts.Shapes.noShape;
            Consts.programMod = Consts.ProgramMode.choosing;
            Consts.pen = new Pen(Color.Black, 2f);
            JsonOperations.tempJsonCreator();
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            JsonOperations.jsonCleaner(ref g);
            pictureBox1.Image = bm;
        }

        //destructor for form1.
        ~Form1()
        {
            JsonOperations.jsonExplode();
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


            if (shape != null && Consts.programMod != Consts.ProgramMode.stopDrawing)
            {
                JsonOperations.jsonWriter(ref shape, Consts.pen.Color);
            }
            if (Consts.choosedShape != Consts.Shapes.noShape && Consts.programMod == Consts.ProgramMode.draw)
            {
                shape.endPoint = endLocation;
                shape.drawController();
                g.DrawPolygon(Consts.pen, shape.shapeCornerPoints);
                g.FillPolygon(Consts.pen.Brush, shape.shapeCornerPoints);
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
            if (isMouseDown && Consts.choosedShape != Consts.Shapes.noShape && Consts.programMod == Consts.ProgramMode.draw)
            {
                shape = new Polygon(((int)Consts.choosedShape), startLocation, endLocation, Consts.pen.Color);
            }
        }



        //attemting button's color property to pen's color property.
        private void colorChooseClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Consts.pen.Color = b.BackColor;
            ButtonManager.colorButtonBackround(b, groupBox2);
        }

        //choosing which shape clicked.
        private void shapeButtonsClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string name = b.Name;
            switch (name)
            {
                case "triangle":
                    Consts.choosedShape = Consts.Shapes.triangle;
                    break;
                case "rectangle":
                    Consts.choosedShape = Consts.Shapes.rectangle;
                    break;
                case "pentagon":
                    Consts.choosedShape = Consts.Shapes.pentagon;
                    break;
                case "hexagon":
                    Consts.choosedShape = Consts.Shapes.hexagon;
                    break;
                case "heptagon":
                    Consts.choosedShape = Consts.Shapes.heptagon;
                    break;
                case "circle":
                    Consts.choosedShape = Consts.Shapes.circle;
                    break;
                default:
                    Consts.choosedShape = Consts.Shapes.noShape;
                    break;
            }
            ButtonManager.shapeButtonBackround(b, groupBox1);
        }



        //draw mode controller.
        //throws ui exeptions while program is running. pick shape and pick color.
        private void pencil_Click(object sender, EventArgs e)
        {
            if (Consts.choosedShape == Consts.Shapes.noShape)
            {
                MessageBox.Show("You can't paint without choosing a shape, pick one.", "paint");
            }
            else if (Consts.pen.Color == Color.Black)
            {
                MessageBox.Show("You can't paint without any color, pick one.", "paint");
            }
            else
            {
                Button b = (Button)sender;
                Consts.programMod = Consts.ProgramMode.draw;
                ButtonManager.modeButtonBackround(ref b, ref groupBox4);
            }
            //IShapes-Polygonses controller make them unvisible.
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Visible = false;
            }
        }

        //clears all canvas-painting area.
        private void recyle_Click(object sender, EventArgs e)
        {
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Dispose();
            }
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Dispose();
            }
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Dispose();
            }
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Dispose();
            }

            JsonOperations.jsonCleaner(ref g);
            pictureBox1.Refresh();

        }

        //shifting choose mode
        private void choose_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Consts.programMod = Consts.ProgramMode.choosing;
            ButtonManager.modeButtonBackround(ref b, ref groupBox4);
            //IShapes-Polygonses controller make them visible.
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Visible = true;
            }
        }

        //File operation buttons.
        private void openFileButton(object sender, EventArgs e)
        {
            JsonOperations.openPaintFromFolder(ref g);
        }

        private void saveFileButton(object sender, EventArgs e)
        {
            JsonOperations.savePaintToFolder(ref g);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
        }


        //canvas-paint area paint event function.
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            l = e.Graphics;
            l.SmoothingMode = SmoothingMode.AntiAlias;
            if (isMouseDown && Consts.programMod == Consts.ProgramMode.draw)
            {
                shape.endPoint = endLocation;
                shape.drawController();
                l.DrawPolygon(Consts.pen, shape.shapeCornerPoints);
                l.FillPolygon(Consts.pen.Brush, shape.shapeCornerPoints);
            }
        }
    }
}