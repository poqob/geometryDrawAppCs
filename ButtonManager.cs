using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections;


namespace paint
{
    class ButtonManager
    {

        static Label choosedShapeButtonBackround = new Label();
        static Label choosedColorButtonBackround = new Label();
        static Label choosedModeButtonBackround = new Label();
        private static Color color = Color.SeaGreen;

        public static void modeButtonBackround(ref Button b, ref GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);

            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedModeButtonBackround.Location = p;
            choosedModeButtonBackround.Size = new Size(33, 38);
            choosedModeButtonBackround.BackColor = color;
            box.Controls.Add(choosedModeButtonBackround);
            choosedModeButtonBackround.BringToFront();
            b.BringToFront();

        }
        public static void colorButtonBackround(Button b, GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);
            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedColorButtonBackround.Location = p;
            choosedColorButtonBackround.Size = new Size(33, 38);
            choosedColorButtonBackround.BackColor = color;
            box.Controls.Add(choosedColorButtonBackround);
            choosedColorButtonBackround.BringToFront();
            b.BringToFront();
            setActiveButton(ref b);

        }

        public static void shapeButtonBackround(Button b, GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);
            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedShapeButtonBackround.Location = p;
            choosedShapeButtonBackround.Size = new Size(44, 48);
            choosedShapeButtonBackround.BackColor = color;
            box.Controls.Add(choosedShapeButtonBackround);
            choosedShapeButtonBackround.BringToFront();
            b.BringToFront();
            setActiveButton(ref b);
        }

        public static void shapeButtonBackroundFromChooseOperation(string shape)
        {
            Control[] boxT = Form1.ActiveForm.Controls.Find("groupBox1", true);
            GroupBox box = (GroupBox)boxT[0];
            //button
            Control[] buttonT = box.Controls.Find(shape, true);
            Button button = (Button)buttonT[0];
            shapeButtonBackround(button, box);

        }

        public static void colorButtonBackroundFromChooseOperation(Color color)
        {
            Control[] boxT = Form1.ActiveForm.Controls.Find("groupBox2", true);
            GroupBox box = (GroupBox)boxT[0];
            //button
            Control[] buttonT = box.Controls.Find(color.Name, true);
            Button button = (Button)buttonT[0];
            colorButtonBackround(button, box);
        }

        
        private static void setActiveButton(ref Button b)
        {
            switch (b.Name)
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
                    Consts.pen.Color = b.BackColor;
                    break;
            }


        }
    }
}

