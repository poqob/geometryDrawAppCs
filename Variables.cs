using System.Drawing;


namespace paint
{
    //variables are stored here.
    public static class Variables
    {
        //shapes.
        public enum Shapes { noShape = 0, triangle = 3, rectangle = 4, pentagon = 5, hexagon = 6, heptagon = 7, circle = 50 };
        //program mode.
        public enum ProgramMode { choosing = 0, stopDrawing = 1, draw = 2 ,erase=3};
        //canvas-painting area's bound points.
        public static Point[] boundPoints;
        //current program mode.
        public static ProgramMode programMod;
        public static Shapes choosedShape;
        //pen variable for drawing operation.
        public static Pen pen;
        //Button menu, selected button background color.
        public static Color buttonBackColor = Color.SeaGreen;
        //lastly selected color from color button menu.
        public static Color activeColorForColorChanger;
        //lastly selected shape's index from canvas-paint area.
        public static int activeShapeIndex;
        //static variable for Polgon.counter() function.
        public static int count=0;


        //purpose of paintAreaBoundPointsDedector() is to dedect paint area bound point by point and attempt that points to boundPoints(Point[]) variable.
        public static void paintAreaBoundPointsDedector(Size paintAreaSize)
        {
            boundPoints = new Point[(paintAreaSize.Width + paintAreaSize.Height) * 2];
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
            for (int i = 0; i < paintAreaSize.Height; i++)
            {
                boundPoints[paintAreaSize.Width + paintAreaSize.Height + i] = new Point(paintAreaSize.Width, i);
            }

            //bottom edge points.
            for (int i = 0; i < paintAreaSize.Width; i++)
            {
                boundPoints[paintAreaSize.Width + paintAreaSize.Height + paintAreaSize.Height + i] = new Point(i, paintAreaSize.Height);
            }
        }
    }
}
