using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drag_Drop_Rectangle
{
    public partial class Form1 : Form
    {
        Rectangle Rec = new Rectangle(0, 0, 100, 100);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Graphics grfs = this.CreateGraphics();
            e.Graphics.FillRectangle(Brushes.SteelBlue, Rec);

            base.OnPaint(e);

        }

       
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rec.X = e.X ;
                Rec.Y = e.Y ;
                Invalidate();

            }

        }

       
    }
}
