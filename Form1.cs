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
        Consts.Shapes choosedShape;
        Pen pen;
        Graphics g;


        public Form1()
        {
            InitializeComponent();
            choosedShape = Consts.Shapes.noShape;
            Consts.programMod = Consts.ProgramMode.choosing;
            endLocation.X = -1;
            endLocation.Y = -1;
            pen = new Pen(Color.Black, 2f);
            g = pictureBox1.CreateGraphics();
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Consts.paintAreaBoundPointsDedector(pictureBox1.Size);
            PaintManagement.tempJsonCreator();
            PaintManagement.jsonCleaner(ref g);
        }



        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && endLocation.X != -1 && endLocation.Y != -1 && choosedShape != Consts.Shapes.noShape && Consts.programMod == Consts.ProgramMode.draw)
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
            if (Consts.programMod == Consts.ProgramMode.stopDrawing)
            {
                Consts.programMod = Consts.ProgramMode.draw;
            }
            if (shape!=null){ 
                PaintManagement.jsonWriter(ref shape, pen.Color);
            }
            
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

            if (Consts.programMod == Consts.ProgramMode.stopDrawing)
            {
                Consts.programMod = Consts.ProgramMode.draw;
            }
        }




        private void colorChooseClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            pen.Color = b.BackColor;
        }

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
        }



        //draw mode controller.
        //throws exeptions while program is running. pick shape and pick color.
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
                Consts.programMod = Consts.ProgramMode.draw;
            }
        }

        private void recyle_Click(object sender, EventArgs e)
        {
            PaintManagement.jsonCleaner(ref g);
        }

        private void choose_Click(object sender, EventArgs e)
        {
            Consts.programMod = Consts.ProgramMode.choosing;

        }

        private void openFileButton(object sender, EventArgs e)
        {
            PaintManagement.openPaintFromFolder(ref g);
        }

        private void saveFileButton(object sender, EventArgs e)
        {
            PaintManagement.savePaintToFolder(ref g);
        }
    }
}


/*
 TODOs:

-will set the paint area bounds++
-create save system++
-make menu choosable PrograMode.choosing??--
-make delete object from paint area or delete everything in paint area PrograMode.recyle++
-panelBehaviour(), hand sign button task is uncertain.??-- i gonna make it back button or i leave it taskless.??
-throw exeptions like color is not choosed via message boxes.++
-panel1 buttons: show, which button choosed lastly for every groupBoxes.

 */