using System;
using System.Drawing;

namespace paint
{
    class PolygonDraw : IShape
    {
        public Point centerPoint { get; set; }
        public Point endPoint { get; set; }
        public int totalCornerNum { get; set; }
        public PointF[] shapeCornersLocation { get; set; } //will use



        public PolygonDraw(int totalCornerNum,Point centerPoint, Point endPoint)
        {
            this.centerPoint = centerPoint;
            this.endPoint = endPoint;
            this.totalCornerNum = totalCornerNum;
            shapeCornerDedector();
        }

        public int distanceFromCenter()
        {
            int distance = 0;
            distance = Convert.ToInt32(Math.Sqrt(Math.Pow(centerPoint.X - endPoint.X, 2) + Math.Pow(centerPoint.Y - endPoint.Y, 2)));
            return distance;
        }


        public void shapeCornerDedector()
        {
            //attempting shape corner locations to pointF
            shapeCornersLocation = new PointF[totalCornerNum];
            //Create 4 points
            for (int a = 0; a < totalCornerNum; a++)
            {
                shapeCornersLocation[a] = new PointF(
                     centerPoint.X + distanceFromCenter() * (float)Math.Cos(a * 360/totalCornerNum * Math.PI / 180f),
                     centerPoint.Y + distanceFromCenter() * (float)Math.Sin(a * 360 / totalCornerNum * Math.PI / 180f));
            }
        }
    }


}
