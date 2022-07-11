using System.Drawing;


namespace paint
{
    static class Consts
    {

        //shapes.
        public  enum Shapes { noShape = 0, triangle = 3, rectangle = 4, pentagon = 5, hexagon = 6, heptagon = 7, circle = 40 };
        //program mode.
        public enum ProgramMode { choosing = 0, stopDrawing = 1, draw = 2 };

        //canvas/painting area's bound points.
        public static Point[] boundPoints;
        //program mode.
        public static ProgramMode programMod;

        


        //TODO: all edges will be pointed we only have 2 edges just now. L,R,T,Bottom++
        //dedecting paint area bounds point by point.++
        //paintAreaSize stores width and height values of paint area/canvas.++

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
