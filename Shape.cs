using System;
using System.Drawing;
using System.Windows.Forms;
namespace paint
{
    class Polygon : IShape
    {
        public Point centerPoint { get; set; }
        public Point endPoint { get; set; }
        public int totalCornerNum { get; set; }
        public PointF[] shapeCornerPoints { get; set; }
        public int distanceFromCenter { get; set; }



        public Polygon(int totalCornerNum, Point centerPoint, Point endPoint)
        {
            this.centerPoint = centerPoint;
            this.endPoint = endPoint;
            this.totalCornerNum = totalCornerNum;
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
                        //send shape data to json file for drawing process and dispose current shape from the paint are. <--TODO 
                    }
                }
            }
        }
    }
}
