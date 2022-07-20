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
            this.Text = "Paint application";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            Variables.choosedShape = Variables.Shapes.noShape;
            Variables.programMod = Variables.ProgramMode.choosing;
            Variables.pen = new Pen(Color.Black, 2f);
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



            if (Variables.choosedShape != Variables.Shapes.noShape && Variables.programMod == Variables.ProgramMode.draw)
            {
                shape.endPoint = endLocation;
                shape.drawController();
                g.DrawPolygon(Variables.pen, shape.shapeCornerPoints);
                g.FillPolygon(Variables.pen.Brush, shape.shapeCornerPoints);
                shape.selectablePart(pictureBox1, g);
            }
            if (shape != null && Variables.programMod != Variables.ProgramMode.stopDrawing)
            {
                JsonOperations.jsonWriter(ref shape);
            }


        }
        //start painting
        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            startLocation = e.Location;
            Variables.paintAreaBoundPointsDedector(pictureBox1.Size);
            //i only allow you to draw with left mouse button.
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
            }

            if (Variables.programMod == Variables.ProgramMode.stopDrawing)
            {
                Variables.programMod = Variables.ProgramMode.draw;
            }
            if (isMouseDown && Variables.choosedShape != Variables.Shapes.noShape && Variables.programMod == Variables.ProgramMode.draw)
            {
                shape = new Polygon(((int)Variables.choosedShape), startLocation, endLocation, Variables.pen.Color);
            }

        }



        //attemting button's color property to pen's color property.
        private void colorChooseClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Variables.pen.Color = b.BackColor;
            ButtonManager.colorButtonBackround(b, groupBox2);
            Variables.activeColorForColorChanger = b.BackColor;

            JsonOperations.jsonColorChanger(g,pictureBox1);
        }

        //choosing which shape clicked.
        private void shapeButtonsClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string name = b.Name;
            switch (name)
            {
                case "triangle":
                    Variables.choosedShape = Variables.Shapes.triangle;
                    break;
                case "rectangle":
                    Variables.choosedShape = Variables.Shapes.rectangle;
                    break;
                case "pentagon":
                    Variables.choosedShape = Variables.Shapes.pentagon;
                    break;
                case "hexagon":
                    Variables.choosedShape = Variables.Shapes.hexagon;
                    break;
                case "heptagon":
                    Variables.choosedShape = Variables.Shapes.heptagon;
                    break;
                case "circle":
                    Variables.choosedShape = Variables.Shapes.circle;
                    break;
                default:
                    Variables.choosedShape = Variables.Shapes.noShape;
                    break;
            }
            ButtonManager.shapeButtonBackround(b, groupBox1);
        }



        //draw mode controller.
        //throws ui exeptions while program is running. pick shape and pick color.
        private void pencil_Click(object sender, EventArgs e)
        {
            if (Variables.choosedShape == Variables.Shapes.noShape)
            {
                MessageBox.Show("You can't paint without choosing a shape, pick one.", "paint");
            }
            else if (Variables.pen.Color == Color.Black)
            {
                MessageBox.Show("You can't paint without any color, pick one.", "paint");
            }
            else
            {
                Button b = (Button)sender;
                Variables.programMod = Variables.ProgramMode.draw;
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
            do
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
            } while (pictureBox1.Controls.Count != 0);


            JsonOperations.jsonCleaner(ref g);
            pictureBox1.Refresh();

        }

        //shifting choose mode
        private void choose_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Variables.programMod = Variables.ProgramMode.choosing;
            ButtonManager.modeButtonBackround(ref b, ref groupBox4);
            //IShapes-Polygon's controller make them visible.
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Visible = true;
            }
        }

        //eraser button click event
        private void eraseClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Variables.programMod = Variables.ProgramMode.erase;
            ButtonManager.modeButtonBackround(ref b, ref groupBox4);
            //make visible all painted object's label.
            foreach (Label lb in pictureBox1.Controls)
            {
                lb.Visible = true;
            }
        }

        //File operation buttons.
        private void openFileButton(object sender, EventArgs e)
        {
            JsonOperations.openPaintFromFolder(ref g, ref pictureBox1);
            pictureBox1.Refresh();
        }

        private void saveFileButton(object sender, EventArgs e)
        {
            JsonOperations.savePaintToFolder(ref g, ref pictureBox1);
            pictureBox1.Refresh();
        }

        //may V0.4 will be resizable.
        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
        }


        //canvas-paint area paint event function.
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            l = e.Graphics;
            l.SmoothingMode = SmoothingMode.AntiAlias;
            if (isMouseDown && Variables.programMod == Variables.ProgramMode.draw)
            {
                shape.endPoint = endLocation;
                shape.drawController();
                l.DrawPolygon(Variables.pen, shape.shapeCornerPoints);
                l.FillPolygon(Variables.pen.Brush, shape.shapeCornerPoints);
            }
        }


    }
}

//Last problem, erase operation:
//erase operation works even scene hasn't got any shape data -json file and json string-