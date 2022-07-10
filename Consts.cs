using System.Drawing;


namespace paint
{
    static class Consts
    {
        public  enum Shapes { noShape = 0, ucgen = 3, dortgen = 4, besgen = 5, altıgen = 6, yedigen = 7, daire = 40 };

        public enum ProgramMode { choosing = 0, stopDrawing = 1, draw = 2 };

        public static Point[] boundPoints;

        public static ProgramMode programMod;

        


        //TODO: all edges will be pointed we only have 2 edges just now. L,R,T,Bottom++
        //dedecting paint area bounds point by point.
        //paintAreaSize stores width and height values of paint area.
        //purpose of paintAreaBoundPointsDedector() is to dedect paint area bound point by point and attempt that points to boundPoints(Point[]) variable.
        public static void paintAreaBoundPointsDedector(Size paintAreaSize)
        {
            boundPoints = new Point[(paintAreaSize.Width + paintAreaSize.Height)*2];
            //top edge points.
            for (int i = 0; i < paintAreaSize.Width; i++)
            {
                boundPoints[i] = new Point(i, 0);
            }

            //left edge points.
            for (int i = 0; i < paintAreaSize.Height; i++)
            {
                boundPoints[paintAreaSize.Width + i] = new Point(0, i);
            }

            //right edge points.
            for (int i=0;i<paintAreaSize.Height;i++)
            {
                boundPoints[paintAreaSize.Width + paintAreaSize.Height + i] = new Point(paintAreaSize.Width,i);
            }

            //bottom edge points.
            for(int i=0;i<paintAreaSize.Width;i++)
            {
                boundPoints[paintAreaSize.Width + paintAreaSize.Height + paintAreaSize.Height + i] = new Point(i,paintAreaSize.Height);
            }
        }
    }
}
