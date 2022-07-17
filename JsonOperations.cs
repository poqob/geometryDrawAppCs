using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
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

    class JsonOperations
    {


        //variables



        private static Pen pen = new Pen(Color.Black, 2f);

        private static FileStream fs;

        private static string json;

        private static JsonModalObject jsonModalObject;

        private static ArrayList tempJsonObjects = new ArrayList();


        private static string tempJsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "temp.json";


        //controls if temp.json was created or not.
        public static void tempJsonCreator()
        {
            if (!File.Exists(tempJsonFilePath))
            {
                fs = File.Create(tempJsonFilePath);
                fs.Close();
            }
        }

        //converts the graphical object input into the json output.
        public static void jsonWriter(ref Polygon shape, Color color)
        {
            tempJsonCreator(); //controlls if the temp.json file is exist.
            jsonModalObject = new JsonModalObject(shape, color);
            tempJsonObjects.Add(jsonModalObject);
            json = JsonConvert.SerializeObject(tempJsonObjects);
            File.WriteAllText(tempJsonFilePath, json);
        }

        //this function creates objects from json file and paint them into the canvas-paint area.
        public static void jsonPainter(ref Graphics g)
        {
            ArrayList jArray = JsonConvert.DeserializeObject<ArrayList>(json);
            if (jArray != null)
            {
                jsonCleaner(ref g);

                for (int i = 0; i < jArray.Count; i++)
                {
                    //making json string to objects
                    JsonModalObject jObject = JsonConvert.DeserializeObject<JsonModalObject>(jArray[i].ToString());
                    pen.Color = jObject.color;
                    //painting 
                    g.DrawPolygon(pen, jObject.shape.shapeCornerPoints);
                    g.FillPolygon(pen.Brush, jObject.shape.shapeCornerPoints);
                    //adding new shapes to our tempArrayList-tempJsonObjects
                    tempJsonObjects.Add(jObject);
                }
            }

        }

        //imports a painting from local folder.
        public static void openPaintFromFolder(ref Graphics g)
        {
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
                jsonCleaner(ref g);
                //to obtain new shapes.
                File.WriteAllText(tempJsonFilePath, File.ReadAllText(dialog.FileName));
                json = File.ReadAllText(dialog.FileName);
                //painting new shapes.
                jsonPainter(ref g);
            }

        }

        //saves the current painting to choosed local folder.
        public static void savePaintToFolder(ref Graphics g)
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
                File.WriteAllText(dialog.FileName, File.ReadAllText(tempJsonFilePath));
                json = File.ReadAllText(dialog.FileName);
                File.WriteAllText(tempJsonFilePath, json);
                tempJsonObjects.Clear();
                jsonCleaner(ref g);
            }
        }


        //clear the shape array and .jason file content's which is temp file.
        public static void jsonCleaner(ref Graphics g)
        {
            tempJsonObjects.Clear();
            File.WriteAllText(tempJsonFilePath, "");
            g.Clear(Color.OldLace);

        }
        //Destructor for json file.
        public static void jsonExplode()
        {
            fs.Dispose();
            File.Delete(tempJsonFilePath);
        }

    }
}

//todo:
//write label objects as well.
//rearange label objects location.++