using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections;
namespace paint
{

    class JsonOperations
    {
        //variables

        private static Pen pen = new Pen(Color.Black, 2f);

        private static FileStream fs;

        private static string json;

        private static Polygon polygon;

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
        public static void jsonWriter(ref Polygon shape)
        {
            tempJsonCreator(); //controlls if the temp.json file is exist.
            polygon = new Polygon(shape.totalCornerNum, shape.centerPoint, shape.endPoint, shape.color);
            tempJsonObjects.Add(polygon);
            json = JsonConvert.SerializeObject(tempJsonObjects);
            File.WriteAllText(tempJsonFilePath, json);
        }

        //this function creates objects from json file and paint them into the canvas-paint area.
        public static void jsonPainter(ref Graphics g, ref PictureBox pb)
        {
            ArrayList jArray = JsonConvert.DeserializeObject<ArrayList>(json);
            if (jArray != null)
            {
                jsonCleaner(ref g);

                for (int i = 0; i < jArray.Count; i++)
                {
                    //making json string to objects
                    Polygon jObject = JsonConvert.DeserializeObject<Polygon>(jArray[i].ToString());
                    pen.Color = jObject.color;

                    //painting 
                    g.DrawPolygon(pen, jObject.shapeCornerPoints);
                    g.FillPolygon(pen.Brush, jObject.shapeCornerPoints);
                    jObject.selectablePart(ref pb);
                    //adding new shapes to our tempArrayList-tempJsonObjects
                    tempJsonObjects.Add(jObject);
                }

            }
        }

        //this function clears paint area's labels which hasn't got any parent painting.
        private static void labelCleaner(ref PictureBox pb)
        {
            do
            {
                foreach (Label lb in pb.Controls)
                {
                    lb.Dispose();
                }
                foreach (Label lb in pb.Controls)
                {
                    lb.Dispose();
                }
                foreach (Label lb in pb.Controls)
                {
                    lb.Dispose();
                }
                foreach (Label lb in pb.Controls)
                {
                    lb.Dispose();
                }
                foreach (Label lb in pb.Controls)
                {
                    lb.Dispose();
                }
            } while (pb.Controls.Count != 0);
        }

        //imports a painting from local folder.
        public static void openPaintFromFolder(ref Graphics g, ref PictureBox pb)
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
                labelCleaner(ref pb);
                //to obtain new shapes.
                File.WriteAllText(tempJsonFilePath, File.ReadAllText(dialog.FileName));
                json = File.ReadAllText(dialog.FileName);
                //painting new shapes.
                jsonPainter(ref g, ref pb);
            }

        }

        //saves the current painting to choosed local folder.
        public static void savePaintToFolder(ref Graphics g, ref PictureBox pb)
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
                labelCleaner(ref pb);
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