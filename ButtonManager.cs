﻿using System.Drawing;
using System.Windows.Forms;

namespace paint
{
    class ButtonManager
    {

        static Label choosedShapeButtonBackround = new Label();
        static Label choosedColorButtonBackround = new Label();
        static Label choosedModeButtonBackround = new Label();

        //which mode button's backround will be painted, determines when button pressed.
        public static void modeButtonBackround(ref Button b, ref GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);

            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedModeButtonBackround.Location = p;
            choosedModeButtonBackround.Size = new Size(33, 38);
            choosedModeButtonBackround.BackColor = Consts.buttonBackColor;
            box.Controls.Add(choosedModeButtonBackround);
            choosedModeButtonBackround.BringToFront();
            b.BringToFront();

        }

        //which color button's backround will be painted, determines when button pressed.
        public static void colorButtonBackround(Button b, GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);
            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedColorButtonBackround.Location = p;
            choosedColorButtonBackround.Size = new Size(33, 38);
            choosedColorButtonBackround.BackColor = Consts.buttonBackColor;
            box.Controls.Add(choosedColorButtonBackround);
            choosedColorButtonBackround.BringToFront();
            b.BringToFront();
            setActiveButton(ref b);

        }

        //which shape button's backround will be painted, determines when button pressed.
        public static void shapeButtonBackround(Button b, GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);
            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedShapeButtonBackround.Location = p;
            choosedShapeButtonBackround.Size = new Size(44, 48);
            choosedShapeButtonBackround.BackColor = Consts.buttonBackColor;
            box.Controls.Add(choosedShapeButtonBackround);
            choosedShapeButtonBackround.BringToFront();
            b.BringToFront();
            setActiveButton(ref b);
        }

        //which shape button's backround will be painted, determines in choose mode.
        public static void shapeButtonBackroundFromChooseOperation(string shape)
        {
            Control[] boxT = Form1.ActiveForm.Controls.Find("groupBox1", true);
            GroupBox box = (GroupBox)boxT[0];
            //button
            Control[] buttonT = box.Controls.Find(shape, true);
            Button button = (Button)buttonT[0];
            shapeButtonBackround(button, box);

        }

        //which color button's backround will be painted, determines in choose mode.
        public static void colorButtonBackroundFromChooseOperation(Color color)
        {
            Control[] boxT = Form1.ActiveForm.Controls.Find("groupBox2", true);
            GroupBox box = (GroupBox)boxT[0];
            //button
            Control[] buttonT = box.Controls.Find(color.Name, true);
            Button button = (Button)buttonT[0];
            colorButtonBackround(button, box);
        }

        //set active button after selecting any shape in canvas-paint area when in choose mode.
        private static void setActiveButton(ref Button b)
        {
            switch (b.Name)
            {
                //cases for shape buttons
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
                //default for color buttons
                default:
                    Consts.pen.Color = b.BackColor;
                    break;
            }
        }
    }
}

