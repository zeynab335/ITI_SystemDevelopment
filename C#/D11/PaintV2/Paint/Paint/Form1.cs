using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        int x = 5;
        int y = 5;     
        Graphics g;
        Pen p;
        bool moving =false;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            p = new Pen(Color.Red, 5);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X; y = e.Y;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (x != -1 && y != -1 && moving)
                {
                    g.DrawLine(p, new Point(x, y), new Point(e.X, e.Y));
                    x = e.X; y = e.Y;

                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                g.DrawRectangle(new Pen(Color.White ,5 ), e.X , e.Y , 50 , 50);
                x = e.X; y = e.Y;

            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            moving = false;
            x = -1;
            y = -1;
        }
    }
}
