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

    //PaintManagement calss works for json style datas.
    public static class PaintManagement
    {

        //variables

        static Label choosedShapeButtonBackround = new Label();
        static Label choosedColorButtonBackround = new Label();
        static Label choosedModeButtonBackround = new Label();

        private static Pen pen = new Pen(Color.Black, 2f);

        private static string json;

        private static JsonModalObject jsonModalObject;

        private static ArrayList tempJsonObjects = new ArrayList();


        private static string tempJsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "temp.json";


        //controls if temp.json was created or not.
        public static void tempJsonCreator()
        {
            if (!File.Exists(tempJsonFilePath))
            {
                FileStream fs = File.Create(tempJsonFilePath);
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
            //TODO: done
            //open saved json file with open file dialog++
            //turn into object that file json text.++
            //attempt the object to the  tempJsonObjects++
            //paint them to paint area.++
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

        public static void jsonExplode()
        {
            File.Delete(tempJsonFilePath);
        }
        //button backround paint functions. --aceleye geldi :D daha temiz yapardım.
        public static void colorButtonBackround(Button b, GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);

            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedColorButtonBackround.Location = p;
            choosedColorButtonBackround.Size = new Size(33, 38);
            choosedColorButtonBackround.BackColor = Color.DarkGray;


            box.Controls.Add(choosedColorButtonBackround);
            choosedColorButtonBackround.BringToFront();
            b.BringToFront();

        }

        public static void shapeButtonBackround(Button b, GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);

            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedShapeButtonBackround.Location = p;
            choosedShapeButtonBackround.Size = new Size(44, 48);
            choosedShapeButtonBackround.BackColor = Color.DarkGray;


            box.Controls.Add(choosedShapeButtonBackround);
            choosedShapeButtonBackround.BringToFront();
            b.BringToFront();

        }



        public static void modeButtonBackround(ref Button b, ref GroupBox box)
        {
            Control[] a = box.Controls.Find(b.Name, true);
            Point p = new Point(-3, -3);

            p.X += a[0].Location.X;
            p.Y += a[0].Location.Y;
            choosedModeButtonBackround.Location = p;
            choosedModeButtonBackround.Size = new Size(33, 38);
            choosedModeButtonBackround.BackColor = Color.DarkGray;

            box.Controls.Add(choosedModeButtonBackround);
            choosedModeButtonBackround.BringToFront();
            b.BringToFront();

        }
        public static void shapeButtonBackroundFromChooseOperation(string shape)
        {
            Control[] boxT = Form1.ActiveForm.Controls.Find("groupBox1", true);
            GroupBox box = (GroupBox)boxT[0];
            //button
            Control[] buttonT = box.Controls.Find(shape, true);
            Button button = (Button)buttonT[0];

            PaintManagement.shapeButtonBackround(button, box);

        }
        public static void colorButtonBackroundFromChooseOperation(Color color)
        {
            Control[] boxT = Form1.ActiveForm.Controls.Find("groupBox2", true);
            GroupBox box = (GroupBox)boxT[0];
            //button
            Control[] buttonT = box.Controls.Find(color.Name, true);
            Button button = (Button)buttonT[0];

            PaintManagement.colorButtonBackround(button, box);
        }
    }
}


//TODO:
//arange page layout according to imported paint.
//optimise bound dedector alghorithm.
