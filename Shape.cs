using System;
using System.Drawing;
using System.Windows.Forms;
namespace paint
{
    //Polygon() class which is can store all 2D shapes with more than 2 points.
    //i added 6 shapes as built-in.
    //Polygon() class can also generate circle with corners.
    //the Circle definition: a polygon that becomes with endless corners.
    public class Polygon
    {
        public Point centerPoint { get; set; }
        public Point endPoint { get; set; }
        public int totalCornerNum { get; set; }
        public PointF[] shapeCornerPoints { get; set; }
        public int distanceFromCenter { get; set; }
        private Label selectableArea;
        public Color color;

        //Constructer
        public Polygon(int totalCornerNum, Point centerPoint, Point endPoint, Color color)
        {
            this.centerPoint = centerPoint;
            this.endPoint = endPoint;
            this.totalCornerNum = totalCornerNum;
            this.color = color;
            drawController();
        }


        public void distanceFromCenterCalculator()
        {
            distanceFromCenter = Convert.ToInt32(Math.Sqrt(Math.Pow(centerPoint.X - endPoint.X, 2) + Math.Pow(centerPoint.Y - endPoint.Y, 2)));
        }

        //creates corners according to shape input.
        public void shapeCornerDedector()
        {
            //attempting shape corner locations to pointF.
            shapeCornerPoints = new PointF[totalCornerNum];
            //Creating corner points according to totalCornerNum.
            for (int a = 0; a < totalCornerNum; a++)
            {
                shapeCornerPoints[a] = new PointF(
                     centerPoint.X + distanceFromCenter * (float)Math.Cos(a * 360 / totalCornerNum * Math.PI / 180f),
                     centerPoint.Y + distanceFromCenter * (float)Math.Sin(a * 360 / totalCornerNum * Math.PI / 180f));
            }
        }

        public void drawController()
        {
            distanceFromCenterCalculator();

            shapeCornerDedector();


            for (int i = 0; i < Consts.boundPoints.Length; i++)
            {
                for (int j = 0; j < shapeCornerPoints.Length; j++)
                {
                    if (Convert.ToInt32(Math.Sqrt(Math.Pow(Consts.boundPoints[i].X - shapeCornerPoints[j].X, 2) + Math.Pow(Consts.boundPoints[i].Y - shapeCornerPoints[j].Y, 2))) < 2)
                    {
                        Consts.programMod = Consts.ProgramMode.stopDrawing;

                    }
                }
            }
        }

        //label creator
        public void selectablePart(ref PictureBox c)
        {
            selectableArea = new Label();
            selectableArea.BackColor = Color.FromArgb(100, Color.Gray);
            selectableArea.Click += delegate (object sender, EventArgs e)
            {
                //choose color button 
                ButtonManager.colorButtonBackroundFromChooseOperation(color);
                //choose shape button 
                string shape;
                if (true)
                {
                    switch (totalCornerNum)
                    {
                        case 3:
                            shape = "triangle";
                            break;
                        case 4:
                            shape = "rectangle";
                            break;
                        case 5:
                            shape = "pentagon";
                            break;
                        case 6:
                            shape = "hexagon";
                            break;
                        case 7:
                            shape = "heptagon";
                            break;
                        default:
                            shape = "circle";
                            break;
                    }
                }
                ButtonManager.shapeButtonBackroundFromChooseOperation(shape);
            };
            Point p = new Point(centerPoint.X - distanceFromCenter / 2, centerPoint.Y - distanceFromCenter / 2);

            selectableArea.Location = p;
            selectableArea.Width = (int)(distanceFromCenter * 1.2);
            selectableArea.Height = (int)(distanceFromCenter * 1.2);
                
            selectableArea.Visible = false;
            c.Controls.Add(selectableArea);
            selectableArea.BringToFront();
        }
    }
}

