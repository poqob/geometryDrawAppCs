using System.Drawing;

namespace paint
{
    public interface IShape
    {

        Point centerPoint { get; set; }

        Point endPoint { get; set; }

        PointF[] shapeCornerPoints { get; set; }

        int totalCornerNum { get; set; }

        int distanceFromCenter { get; set; }



        void shapeCornerDedector();

        void drawController();

        void distanceFromCenterCalculator();

    }

    //at the begining of the project i planned to store shapes seperate from each other.I was intend togather all shapes(shape classes) under an interface via IShape.
    //but i wrote Polygon() class which is can store all shapes with more than 2 points.
    // Polygon() class can also generate circle with corners.
    //circle definition: a polygon that becomes with endless corners.
}
