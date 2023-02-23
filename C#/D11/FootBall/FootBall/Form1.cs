using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootBall
{
    public partial class Form1 : Form
    {
        PictureBox ball = new PictureBox();
        int ballPosX = 250;
        int ballPosY = 420;
        Timer MyTimer = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyTimer.Interval = 200; // 45 mins
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PictureBox image1 = new PictureBox();
            image1.Image = new Bitmap("1.png");
            image1.Location = new Point(-50, 210);

            image1.Width = 300;
            image1.Height = 900;
            this.panel1.Controls.Add(image1);


            // image2
            PictureBox image2 = new PictureBox();
            image2.Image = new Bitmap("2.jpg");
            image2.Location = new Point(750, 210);
            image2.Width = 300;
            image2.Height = 900;
            this.panel1.Controls.Add(image2);


            // ball image
            ball.Image = new Bitmap("ball.jfif");
            ball.Location = new Point(ballPosX, ballPosY);

            ball.Width = 100;
            ball.Height = 100;

            this.panel1.Controls.Add(ball);
        }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        int flag = 0;
        private void MyTimer_Tick(object sender, EventArgs e)
        {

            if (ballPosX >= 660)
            {
                flag = 1;
            }
            else if (ballPosX < 300)
                flag = 0;

            if(flag == 1) 
                ballPosX -= 10;
            else 
                ballPosX += 10;

            

            Invalidate();
            
        }
    }
}
