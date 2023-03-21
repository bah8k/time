using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void drawLine(Point p1, Point p2, Bitmap bitmap, bool colorIsGreen = true)
        {
            int x = p1.X;
            int y = p1.Y;
            int deltaX = Math.Abs(p2.X - p1.X);
            int deltaY = Math.Abs(p2.Y - p1.Y);
            int signX = Math.Sign(p2.X - p1.X);
            int signY = Math.Sign(p2.Y - p1.Y);
            int interchange = 0, e, a, b, t;

            if (deltaY > deltaX)
            {
                t = deltaX;
                deltaX = deltaY;
                deltaY = t;
                interchange = 1;
            }


            e = 2 * deltaY - deltaX;
            a = 2 * deltaY;
            b = 2 * deltaY - 2 * deltaX;
            try
            {
                bitmap.SetPixel((int)x, (int)y, colorIsGreen ? Color.Green : Color.White);
            }
            catch (Exception exx) { 
            }

            for (int i = 1; i <= deltaX; i++)
            {
                if (e < 0)
                {
                    if (interchange == 1)
                    {
                        y = y + signY;
                    }
                    else
                    {
                        x = x + signX;
                    }
                    e = e + a;
                }
                else
                {
                    y = y + signY;
                    x = x + signX;
                    e = e + b;
                }
                    
                    try
                    {
                        bitmap.SetPixel((int)x, (int)y, colorIsGreen ? Color.Green : Color.White);
                        bitmap.SetPixel((int)x + 1, (int)y, colorIsGreen ? Color.Green : Color.White);
                        bitmap.SetPixel((int)x, (int)y + 1, colorIsGreen ? Color.Green : Color.White);
                        bitmap.SetPixel((int)x + 1, (int)y + 1, colorIsGreen ? Color.Green : Color.White);
                        bitmap.SetPixel((int)x - 1, (int)y, colorIsGreen ? Color.Green : Color.White);
                        bitmap.SetPixel((int)x, (int)y - 1, colorIsGreen ? Color.Green : Color.White);
                        bitmap.SetPixel((int)x - 1, (int)y - 1, colorIsGreen ? Color.Green : Color.White);
                    }
                    catch (Exception ex)
                    {
                        //  Block of code to handle errors
                    }

            }
        }
        private void arc(Point point, double r, int sa, int ea, Bitmap bitmap){
            double x, y;
            double theta, dtheta = 1 / r, gama;
            if (sa > ea)
                ea += 360;
            theta = sa * 3.14 / 180;
            gama = ea * 3.14 / 180;
            while (theta < gama)
            {
                x = point.X + r * Math.Cos(theta);
                y = point.Y - r * Math.Sin(theta);
                bitmap.SetPixel((int)x, (int)y, Color.White);
                bitmap.SetPixel((int)x + 1, (int)y, Color.White);
                bitmap.SetPixel((int)x, (int)y + 1, Color.White);
                bitmap.SetPixel((int)x + 1, (int)y + 1, Color.White);
                bitmap.SetPixel((int)x - 1, (int)y, Color.White);
                bitmap.SetPixel((int)x, (int)y - 1, Color.White);
                bitmap.SetPixel((int)x - 1, (int)y - 1,Color.White);
                theta = theta + dtheta;
            }


        }
        void drawNum(int num,Bitmap bitmap){

            //خط اليسرة
            if (num == 0 || num == 4 || num == 5 || num == 6 || num == 7 || num == 8 || num == 9) drawLine(new Point(10, 20), new Point(10, 40), bitmap);
            if (num == 0 || num == 2 || num == 6 || num == 8) drawLine(new Point(10, 45), new Point(10, 65), bitmap);

            //خط الفوك
            if (num == 0 || num == 2 || num == 3  || num == 5 || num == 6 || num == 7 || num == 8 || num == 9) drawLine(new Point(12, 18), new Point(28, 18), bitmap);

            //خط اليمنة
            if (num == 0 || num == 1 || num == 2 || num == 3 || num == 4 || num == 7 || num == 8 || num == 9) drawLine(new Point(30, 20), new Point(30, 40), bitmap);
            if (num == 0 || num == 1 || num == 3 || num == 4 || num == 5 || num == 6 || num == 7 || num == 8 || num == 9) drawLine(new Point(30, 45), new Point(30, 65), bitmap);

            //خط النص
            if (num == 2 || num == 3 || num == 4 || num == 5 || num == 6 || num == 8 || num == 9) drawLine(new Point(12, 44), new Point(28, 44), bitmap);

            //خط الجوة
            if (num == 0 || num == 2 || num == 3 || num == 5 || num == 6 || num == 8 || num == 9) drawLine(new Point(12, 68), new Point(28, 68), bitmap);

        }
        void drawTime(int time, Bitmap bitmap1, Bitmap bitmap2, Bitmap bitmap3, Bitmap bitmap4) {

            if (time < 1000) drawNum(0, bitmap1);
            else drawNum(time/1000, bitmap1);


            int cur = time/1000;
            time = time - cur * 1000;

            if (time < 100) drawNum(0, bitmap2);
            else drawNum(time / 100, bitmap2);


            cur = time / 100;
            time = time - cur * 100;

            if (time < 10) drawNum(0, bitmap3);
            else drawNum(time / 10, bitmap3);

            cur = time / 10;
            time = time - cur * 10;

            if (time < 1) drawNum(0, bitmap4);
            else drawNum(time / 1, bitmap4);


        }
        void drawSwa(Point position, Bitmap bitmap7) {

            //S
            arc(new Point(100 + position.X, 100 + position.Y), 30, 0, 260, bitmap7);
            arc(new Point(84 + position.X, 159 + position.Y), 30, 230, 70, bitmap7);
            //W
            drawLine(new Point(140 + position.X, 70 + position.Y), new Point(170 + position.X, 200 + position.Y), bitmap7, colorIsGreen: false);
            drawLine(new Point(200 + position.X, 70 + position.Y), new Point(170 + position.X, 200 + position.Y), bitmap7, colorIsGreen: false);
            drawLine(new Point(200 + position.X, 70 + position.Y), new Point(220 + position.X, 200 + position.Y), bitmap7, colorIsGreen: false);
            drawLine(new Point(270 + position.X, 70 + position.Y), new Point(220 + position.X, 200 + position.Y), bitmap7, colorIsGreen: false);

            //A
            int x = 130;
            drawLine(new Point(120 + x + position.X, 188 + position.Y), new Point(175 + x + position.X, 70 + position.Y), bitmap7, colorIsGreen: false);
            drawLine(new Point(175 + x + position.X, 70 + position.Y), new Point(220 + x + position.X, 188 + position.Y), bitmap7, colorIsGreen: false);
            drawLine(new Point(150 + x + position.X, 125 + position.Y), new Point(195 + x + position.X, 125 + position.Y), bitmap7, colorIsGreen: false);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        
        Bitmap bitmap1 = new Bitmap(500, 500);
        Bitmap bitmap2 = new Bitmap(500, 500);
        Bitmap bitmap3 = new Bitmap(500, 500);
        Bitmap bitmap4 = new Bitmap(500, 500);
        Bitmap bitmap5 = new Bitmap(500, 500);
        Bitmap bitmap6 = new Bitmap(500, 500);
        Bitmap bitmap7 = new Bitmap(500, 500);

        int xpub = 0;
        bool flag = false;
        int latnzy = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                bitmap1 = new Bitmap(500, 500);
                bitmap2 = new Bitmap(500, 500);
                bitmap3 = new Bitmap(500, 500);
                bitmap4 = new Bitmap(500, 500);
                bitmap5 = new Bitmap(500, 500);
                bitmap6 = new Bitmap(500, 500);
                bitmap7 = new Bitmap(this.Height, this.Width);

            }catch(Exception eee){}
            DateTime localDate = DateTime.Now;
            String time = "";
            time += localDate.Hour.ToString();
            if (localDate.Minute < 10) time += 0;
            time += localDate.Minute.ToString();
            //MessageBox.Show(time);
            drawTime(Convert.ToInt16(time), bitmap1, bitmap2, bitmap3, bitmap4);
           // drawSwa(new Point(localDate.Second * localDate.Second, localDate.Second * localDate.Second), bitmap7);
            drawSwa(new Point(0, xpub), bitmap7);
            drawSwa(new Point(xpub, 0), bitmap7);
            latnzy++;
            if (flag && latnzy > 50) xpub-=10;
            else if(latnzy > 50) xpub+=10;
            if (xpub == 200) flag = true;
            else if (xpub == 0) {
                flag = false;
            }


            if (localDate.Second > 9) drawNum(Convert.ToInt16((localDate.Second / 10)), bitmap5);
            else drawNum(0, bitmap5);

            drawNum(Convert.ToInt16(localDate.Second - (localDate.Second / 10)*10), bitmap6);

            pictureBox1.Image = bitmap1;
            pictureBox2.Image = bitmap2;
            pictureBox3.Image = bitmap3;
            pictureBox4.Image = bitmap4;
            pictureBox5.Image = bitmap5;
            pictureBox6.Image = bitmap6;
            back.Image = bitmap7;


        }

        private void back_Click(object sender, EventArgs e)
        {

        }


    
    }
}
