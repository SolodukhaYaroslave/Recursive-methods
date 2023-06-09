using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form : System.Windows.Forms.Form
    {
        public int x, y = 0, R;
        public Pen pen = new Pen(Brushes.Blue, 2);
        public Form()
        {
            InitializeComponent();
        }

        private void MyDraw(Graphics g, int x, int y, int R, int N)
        {
            g.DrawEllipse(pen, this.Width / 2 - R / 2 - x, this.Height / 2 - R / 2 + y, R, R);

            if (N == 0) return;
            N--;
            MyDraw(g, (int)(x - R * 0.5), (int)(y - R * 0.5), R / 2, N);
            MyDraw(g, (int)(x + R * 0.5), (int)(y - R * 0.5), R / 2, N);
            MyDraw(g, (int)(x - R * 0.5), (int)(y + R * 0.5), R/2, N);
            MyDraw(g, (int)(x + R * 0.5), (int)(y + R * 0.5), R/2, N);
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            R = 200;
            int N = 4;
            MyDraw(g, x, y, R, N);
        }
    }
}

