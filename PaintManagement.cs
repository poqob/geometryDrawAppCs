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


    //Modal class
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



        //variables
        private static Pen pen = new Pen(Color.Black, 2f);

        private static string json;

        private static JsonModalObject jsonModalObject;

        private static ArrayList tempJsonObjects = new ArrayList();

        private static string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static string tempLoc = Directory.GetParent(workingDirectory).Parent.FullName;
        private static string paintingsPath = Directory.GetParent(tempLoc).Parent.FullName + @"\paint\paintings\temp.json";


        //controls if temp.json was created or not.
        public static void tempJsonCreator()
        {
            if (!File.Exists(paintingsPath))
            {
                File.Create(paintingsPath);
            }
        }

        //converts the graphical object input to json output.
        public static void jsonWriter(ref Polygon shape, Color color)
        {
            tempJsonCreator(); //controlls if the temp.json file is exist.
            jsonModalObject = new JsonModalObject(shape, color);
            tempJsonObjects.Add(jsonModalObject);
            json = JsonConvert.SerializeObject(tempJsonObjects);
            File.WriteAllText(paintingsPath, json);
        }

        //paint function works for json style datas.
        public static void jsonPainter(ref Graphics g)
        {
            ArrayList a = JsonConvert.DeserializeObject<ArrayList>(json);
            for (int i = 0; i < a.Count; i++)
            {
                tempJsonObjects.Clear();
                JsonModalObject b = JsonConvert.DeserializeObject<JsonModalObject>(a[i].ToString());
                pen.Color = b.color;
                g.DrawPolygon(pen, b.shape.shapeCornerPoints);
                g.FillPolygon(pen.Brush, b.shape.shapeCornerPoints);
                tempJsonObjects.Add(b);
            }
        }

        //clear the shape array and .jason file content which is temp file.
        public static void jsonCleaner()
        {
            tempJsonObjects.Clear();
            File.WriteAllText(paintingsPath, "");
        }


        public static void openPaintFromFolder(ref Graphics g)
        {
            //open saved json file with open file dialog
            //turn into object that file json text.
            //attempt the object to the  tempJsonObjects
            //paint them to paint area.
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Title = "Browse foe Json Files";
            dialog.DefaultExt = "json";
            dialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            DialogResult r = dialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                json = File.ReadAllText(dialog.FileName);
                jsonPainter(ref g);
            }

        }


        public static void savePaintToFolder()
        {
            //save tempJsonfile to a folder.
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Title = "Browse for Json Files";
            dialog.DefaultExt = "json";
            dialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            DialogResult r = dialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, File.ReadAllText(paintingsPath));
            }
        }






        //Notes myself
        //TODO: test the system with more shapes
        //TODO: choosed button shadow will be added.
        //TODO: look for program mode switch while painting without choosing draw mode.

    }
}
