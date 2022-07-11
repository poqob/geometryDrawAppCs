using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections;

namespace paint
{

    public class JsonModalObject
    {
        public Polygon shape { get; set; }
        public Color color { get; set; }
        public JsonModalObject(Polygon shape, Color color)
        {
            this.shape = shape;
            this.color = color;
        }
    }

    public static class PaintManagement
    {



        private static Polygon shape;

        private static Pen pen = new Pen(Color.Black, 2f);

        private static string json;

        private static JsonModalObject jsonModalObject;

        private static ArrayList tempJsonObjects = new ArrayList();

        private static string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string tempLoc = Directory.GetParent(workingDirectory).Parent.FullName;
        private static string paintingsPath = Directory.GetParent(tempLoc).Parent.FullName + @"\paint\paintings\ornek.json";





















        public static void tempJsonCreator()
        {

        }

        public static void jsonWriter(ref Polygon shape, Color color)
        {
            jsonModalObject = new JsonModalObject(shape, color);
            tempJsonObjects.Add(jsonModalObject);
            json = JsonConvert.SerializeObject(tempJsonObjects);
            File.WriteAllText(paintingsPath, json);

        }

        public static void jsonReader(ref Graphics g)
        {
            //open saved json file with open file dialog
            //turn into object that file json text.
            //attempt the object to the  tempJsonObjects
            //paint them to paint area.
        }

        public static void jsonPainter(ref Graphics g)
        {
            ArrayList a = JsonConvert.DeserializeObject<ArrayList>(json);
            MessageBox.Show(tempJsonObjects.Count.ToString());
            for (int i = 0; i < a.Count; i++)
            {
                JsonModalObject b = JsonConvert.DeserializeObject<JsonModalObject>(a[i].ToString());
                pen.Color = b.color;
                g.DrawPolygon(pen, b.shape.shapeCornerPoints);
                g.FillPolygon(pen.Brush, b.shape.shapeCornerPoints);
            }


        }

        public static void jsonCleaner()
        {

        }

        public static void savePaintToFolder()
        {
            //save tempJsonfile to a folder.
        }


        public static void openPaintFromFolder()
        {
        }





    }
}
