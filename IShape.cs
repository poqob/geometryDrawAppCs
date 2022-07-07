using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paint
{
    interface IShape
    {

        Point centerPoint { get; set; }

        Point endPoint { get; set; }

        PointF[] shapeCornersLocation { get; set; }

        void shapeCornerDedector();

        int totalCornerNum { get; set; }

        int distanceFromCenter();

    }
}
