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
}
