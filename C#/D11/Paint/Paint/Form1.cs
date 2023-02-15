using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Media;

namespace Paint
{
    public partial class Form1 : Form
    {
        Color BrushColor { set; get; } = Color.White;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
      
        private void MouselickHandler(object sender, MouseEventArgs e)
        {
            Graphics grfs = this.CreateGraphics();
            SolidBrush brush = new SolidBrush(BrushColor); 
            var pen = new Pen(BrushColor);

            if (e.Button == MouseButtons.Left)
            {
                grfs.DrawRectangle(pen, e.X - 50, e.Y - 50, 100, 100);
                grfs.FillRectangle(brush, e.X - 50, e.Y - 50, 100, 100);

            }

            if (e.Button == MouseButtons.Right)
            {
                grfs.DrawRectangle(Pens.SteelBlue, e.X - 50, e.Y - 50, 100, 100);
                grfs.FillRectangle(Brushes.SteelBlue, e.X - 50, e.Y - 50, 100, 100);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                BrushColor = colorDialog1.Color;
            }
        }
    }
}
