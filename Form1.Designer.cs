
using System;
using System.Windows.Forms;

namespace paint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.eraser = new System.Windows.Forms.Button();
            this.recyle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.choose = new System.Windows.Forms.Button();
            this.pencil = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.darkOrange = new System.Windows.Forms.Button();
            this.red = new System.Windows.Forms.Button();
            this.seaGreen = new System.Windows.Forms.Button();
            this.RoyalBlue = new System.Windows.Forms.Button();
            this.khaki = new System.Windows.Forms.Button();
            this.darkOrchid = new System.Windows.Forms.Button();
            this.cyan = new System.Windows.Forms.Button();
            this.lightSeaGreen = new System.Windows.Forms.Button();
            this.darkCyan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heptagon = new System.Windows.Forms.Button();
            this.rectangle = new System.Windows.Forms.Button();
            this.circle = new System.Windows.Forms.Button();
            this.triangle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pentagon = new System.Windows.Forms.Button();
            this.hexagon = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(709, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 618);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.eraser);
            this.groupBox4.Controls.Add(this.recyle);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.choose);
            this.groupBox4.Controls.Add(this.pencil);
            this.groupBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox4.Location = new System.Drawing.Point(5, 364);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(141, 117);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            // 
            // eraser
            // 
            this.eraser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eraser.BackgroundImage")));
            this.eraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eraser.Location = new System.Drawing.Point(8, 66);
            this.eraser.Name = "eraser";
            this.eraser.Size = new System.Drawing.Size(36, 39);
            this.eraser.TabIndex = 19;
            this.eraser.UseVisualStyleBackColor = true;
            this.eraser.Click += new System.EventHandler(this.eraseClick);
            // 
            // recyle
            // 
            this.recyle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("recyle.BackgroundImage")));
            this.recyle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recyle.Location = new System.Drawing.Point(50, 21);
            this.recyle.Name = "recyle";
            this.recyle.Size = new System.Drawing.Size(36, 39);
            this.recyle.TabIndex = 18;
            this.recyle.UseVisualStyleBackColor = true;
            this.recyle.Click += new System.EventHandler(this.recyle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "shape operations";
            // 
            // choose
            // 
            this.choose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("choose.BackgroundImage")));
            this.choose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.choose.Location = new System.Drawing.Point(8, 21);
            this.choose.Name = "choose";
            this.choose.Size = new System.Drawing.Size(36, 39);
            this.choose.TabIndex = 16;
            this.choose.UseVisualStyleBackColor = true;
            this.choose.Click += new System.EventHandler(this.choose_Click);
            // 
            // pencil
            // 
            this.pencil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pencil.BackgroundImage")));
            this.pencil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pencil.Location = new System.Drawing.Point(92, 21);
            this.pencil.Name = "pencil";
            this.pencil.Size = new System.Drawing.Size(36, 39);
            this.pencil.TabIndex = 17;
            this.pencil.UseVisualStyleBackColor = true;
            this.pencil.Click += new System.EventHandler(this.pencil_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.save);
            this.groupBox3.Controls.Add(this.open);
            this.groupBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox3.Location = new System.Drawing.Point(3, 487);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 83);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "file operations";
            // 
            // save
            // 
            this.save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("save.BackgroundImage")));
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.save.Location = new System.Drawing.Point(75, 32);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(36, 39);
            this.save.TabIndex = 22;
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.saveFileButton);
            // 
            // open
            // 
            this.open.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("open.BackgroundImage")));
            this.open.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.open.Location = new System.Drawing.Point(26, 32);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(36, 39);
            this.open.TabIndex = 20;
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.openFileButton);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.darkOrange);
            this.groupBox2.Controls.Add(this.red);
            this.groupBox2.Controls.Add(this.seaGreen);
            this.groupBox2.Controls.Add(this.RoyalBlue);
            this.groupBox2.Controls.Add(this.khaki);
            this.groupBox2.Controls.Add(this.darkOrchid);
            this.groupBox2.Controls.Add(this.cyan);
            this.groupBox2.Controls.Add(this.lightSeaGreen);
            this.groupBox2.Controls.Add(this.darkCyan);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox2.Location = new System.Drawing.Point(5, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 163);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // darkOrange
            // 
            this.darkOrange.BackColor = System.Drawing.Color.DarkOrange;
            this.darkOrange.Location = new System.Drawing.Point(52, 66);
            this.darkOrange.Name = "darkOrange";
            this.darkOrange.Size = new System.Drawing.Size(36, 39);
            this.darkOrange.TabIndex = 11;
            this.darkOrange.UseVisualStyleBackColor = false;
            this.darkOrange.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // red
            // 
            this.red.BackColor = System.Drawing.Color.Red;
            this.red.Location = new System.Drawing.Point(10, 21);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(36, 39);
            this.red.TabIndex = 6;
            this.red.UseVisualStyleBackColor = false;
            this.red.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // seaGreen
            // 
            this.seaGreen.BackColor = System.Drawing.Color.SeaGreen;
            this.seaGreen.Location = new System.Drawing.Point(94, 21);
            this.seaGreen.Name = "seaGreen";
            this.seaGreen.Size = new System.Drawing.Size(36, 39);
            this.seaGreen.TabIndex = 7;
            this.seaGreen.UseVisualStyleBackColor = false;
            this.seaGreen.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // RoyalBlue
            // 
            this.RoyalBlue.BackColor = System.Drawing.Color.RoyalBlue;
            this.RoyalBlue.Location = new System.Drawing.Point(52, 21);
            this.RoyalBlue.Name = "RoyalBlue";
            this.RoyalBlue.Size = new System.Drawing.Size(36, 39);
            this.RoyalBlue.TabIndex = 8;
            this.RoyalBlue.UseVisualStyleBackColor = false;
            this.RoyalBlue.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // khaki
            // 
            this.khaki.BackColor = System.Drawing.Color.Khaki;
            this.khaki.Location = new System.Drawing.Point(10, 66);
            this.khaki.Name = "khaki";
            this.khaki.Size = new System.Drawing.Size(36, 39);
            this.khaki.TabIndex = 9;
            this.khaki.UseVisualStyleBackColor = false;
            this.khaki.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // darkOrchid
            // 
            this.darkOrchid.BackColor = System.Drawing.Color.DarkOrchid;
            this.darkOrchid.Location = new System.Drawing.Point(94, 66);
            this.darkOrchid.Name = "darkOrchid";
            this.darkOrchid.Size = new System.Drawing.Size(36, 39);
            this.darkOrchid.TabIndex = 10;
            this.darkOrchid.UseVisualStyleBackColor = false;
            this.darkOrchid.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // cyan
            // 
            this.cyan.BackColor = System.Drawing.Color.Cyan;
            this.cyan.Location = new System.Drawing.Point(10, 111);
            this.cyan.Name = "cyan";
            this.cyan.Size = new System.Drawing.Size(36, 39);
            this.cyan.TabIndex = 12;
            this.cyan.UseVisualStyleBackColor = false;
            this.cyan.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // lightSeaGreen
            // 
            this.lightSeaGreen.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lightSeaGreen.Location = new System.Drawing.Point(94, 111);
            this.lightSeaGreen.Name = "lightSeaGreen";
            this.lightSeaGreen.Size = new System.Drawing.Size(36, 39);
            this.lightSeaGreen.TabIndex = 13;
            this.lightSeaGreen.UseVisualStyleBackColor = false;
            this.lightSeaGreen.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // darkCyan
            // 
            this.darkCyan.BackColor = System.Drawing.Color.DarkCyan;
            this.darkCyan.Location = new System.Drawing.Point(52, 111);
            this.darkCyan.Name = "darkCyan";
            this.darkCyan.Size = new System.Drawing.Size(36, 39);
            this.darkCyan.TabIndex = 14;
            this.darkCyan.UseVisualStyleBackColor = false;
            this.darkCyan.Click += new System.EventHandler(this.colorChooseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "colors";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heptagon);
            this.groupBox1.Controls.Add(this.rectangle);
            this.groupBox1.Controls.Add(this.circle);
            this.groupBox1.Controls.Add(this.triangle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pentagon);
            this.groupBox1.Controls.Add(this.hexagon);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 202);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // heptagon
            // 
            this.heptagon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("heptagon.BackgroundImage")));
            this.heptagon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.heptagon.Location = new System.Drawing.Point(8, 146);
            this.heptagon.Name = "heptagon";
            this.heptagon.Size = new System.Drawing.Size(50, 52);
            this.heptagon.TabIndex = 5;
            this.heptagon.UseVisualStyleBackColor = true;
            this.heptagon.Click += new System.EventHandler(this.shapeButtonsClick);
            // 
            // rectangle
            // 
            this.rectangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rectangle.BackgroundImage")));
            this.rectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rectangle.Location = new System.Drawing.Point(77, 30);
            this.rectangle.Name = "rectangle";
            this.rectangle.Size = new System.Drawing.Size(50, 52);
            this.rectangle.TabIndex = 2;
            this.rectangle.UseVisualStyleBackColor = true;
            this.rectangle.Click += new System.EventHandler(this.shapeButtonsClick);
            // 
            // circle
            // 
            this.circle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circle.BackgroundImage")));
            this.circle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.circle.Location = new System.Drawing.Point(77, 146);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(50, 52);
            this.circle.TabIndex = 6;
            this.circle.UseVisualStyleBackColor = true;
            this.circle.Click += new System.EventHandler(this.shapeButtonsClick);
            // 
            // triangle
            // 
            this.triangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("triangle.BackgroundImage")));
            this.triangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.triangle.Location = new System.Drawing.Point(8, 30);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(50, 52);
            this.triangle.TabIndex = 1;
            this.triangle.UseVisualStyleBackColor = true;
            this.triangle.Click += new System.EventHandler(this.shapeButtonsClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "shapes";
            // 
            // pentagon
            // 
            this.pentagon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pentagon.BackgroundImage")));
            this.pentagon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pentagon.Location = new System.Drawing.Point(8, 88);
            this.pentagon.Name = "pentagon";
            this.pentagon.Size = new System.Drawing.Size(50, 52);
            this.pentagon.TabIndex = 3;
            this.pentagon.UseVisualStyleBackColor = true;
            this.pentagon.Click += new System.EventHandler(this.shapeButtonsClick);
            // 
            // hexagon
            // 
            this.hexagon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hexagon.BackgroundImage")));
            this.hexagon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hexagon.Location = new System.Drawing.Point(77, 88);
            this.hexagon.Name = "hexagon";
            this.hexagon.Size = new System.Drawing.Size(50, 52);
            this.hexagon.TabIndex = 4;
            this.hexagon.UseVisualStyleBackColor = true;
            this.hexagon.Click += new System.EventHandler(this.shapeButtonsClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.OldLace;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(708, 618);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown_1);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 618);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button triangle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rectangle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hexagon;
        private System.Windows.Forms.Button pentagon;
        private System.Windows.Forms.Button darkCyan;
        private System.Windows.Forms.Button lightSeaGreen;
        private System.Windows.Forms.Button cyan;
        private System.Windows.Forms.Button darkOrange;
        private System.Windows.Forms.Button darkOrchid;
        private System.Windows.Forms.Button khaki;
        private System.Windows.Forms.Button RoyalBlue;
        private System.Windows.Forms.Button seaGreen;
        private System.Windows.Forms.Button red;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button recyle;
        private System.Windows.Forms.Button pencil;
        private System.Windows.Forms.Button choose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button heptagon;
        private System.Windows.Forms.Button circle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button eraser;
    }
}
