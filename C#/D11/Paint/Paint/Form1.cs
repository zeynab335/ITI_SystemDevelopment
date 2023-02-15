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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Gray, 50, 50,100,100);
            e.Graphics.FillRectangle(Brushes.Gray, 50, 50, 100, 100);

            base.OnPaint(e);
        }

        private void MouselickHandler(object sender, MouseEventArgs e)
        {
            Graphics grfs = this.CreateGraphics();
            
            if(e.Button == MouseButtons.Left)
            {
                grfs.DrawRectangle(Pens.Gray, e.X-50, e.Y-50, 100, 100);
                grfs.FillRectangle(Brushes.Gray, e.X - 50, e.Y-50, 100, 100);

            }

            if (e.Button == MouseButtons.Right)
            {
                grfs.FillRectangle(Brushes.White, e.X - 50, e.Y - 50, 110, 110);

            }
        }
    }
}
