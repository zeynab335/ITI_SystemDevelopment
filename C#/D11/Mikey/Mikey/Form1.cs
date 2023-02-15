using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikey
{
    public partial class Form1 : Form
    {
        int locX = 0;
        int locY = 0;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle= FormBorderStyle.None;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        GraphicsPath graphicsPath= new GraphicsPath();
        protected override void OnPaint(PaintEventArgs e)
        {
            
            graphicsPath.AddEllipse(100 ,100,this.ClientSize.Width - 200,this.ClientSize.Height -200 );
            
            graphicsPath.AddEllipse(0, 100, 150, 150);
            e.Graphics.FillEllipse(Brushes.Black ,50 ,150, 50, 50);


            graphicsPath.AddEllipse(this.ClientSize.Width-150, 100, 150, 150);

            e.Graphics.FillEllipse(Brushes.Black, this.ClientSize.Width - 100, 150, 50, 50);


            e.Graphics.FillEllipse(Brushes.Black, 200, 180, 80, 150);

            e.Graphics.FillEllipse(Brushes.Black, 300, 180, 80, 150);

            e.Graphics.FillEllipse(Brushes.Black, 270, 350, 50, 50);

            PointF[] points = {
                new Point(100, 350),
                new Point(220, 450),
                new Point(400, 450),
                new Point(520, 300)
            };
            e.Graphics.DrawCurve(Pens.Red, points);


            graphicsPath.FillMode = FillMode.Winding;
            this.Region = new Region(graphicsPath);
            base.OnPaint(e);
        }


        

        private void exist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            locX += 50;
            locY += 50;

            if(locY > (1080 - 800)) { locY = 50; }
            if (locX > (1920 - 800)) { locX = 50; }


            this.Location = new Point() { X= locX, Y = locY };
        }
    }
}
