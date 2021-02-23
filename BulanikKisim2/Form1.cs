using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulanikKisim2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
           

            double tolerans = 0.00001;

            if (radioButton1.Checked)
            {
                tolerans = 0.00001;
            }

            if (radioButton2.Checked)
            {
                tolerans= 0.0001;
            }
            if (radioButton3.Checked)
            {
                tolerans = 0.001;
            }
            if (radioButton4.Checked)
            {
                tolerans = 0.01;
            }
            if (radioButton5.Checked)
            {
                tolerans = 0.1;
            }

    double[,] A = new double[2,2];
    A[0,0] = -3;
    A[0,1] =  -3;
    A[1,0] = 1;
    A[1,1] = -9;
    double []x0=new double[2];
    x0[0] = 0;
    x0[1] = 0;
    double [,]B=new double [2,2];
    B[0,0] = 1;
    B[0,1] = 0;
    B[1,0] = 0;
    B[1,1] = 1;
    double[] U = new double[2];
    U[0] = 100;
    U[1] = 0;
    double T = 0.01;
   
    double[] x00 = new double[2];
    Bitmap grafik = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for(int k=0;k<600;k+=50)
            for(int i = 0; i < pictureBox1.Height; i++)
            {
                    grafik.SetPixel(k, i, Color.Gold);
            }

            for (int k = 0; k < pictureBox1.Height; k += 50)
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    grafik.SetPixel(i, k, Color.Gold);
                }
            for (int i = 0; true; i++) {
        double a = (A[0,0] * x0[0] + A[0,1] * x0[1]) + (B[0,0] * U[0] + B[0,1] * U[1]);
        double b = (A[1,0] * x0[0] + A[1,1] * x0[1]) + (B[1,0] * U[0] + B[1,1] * U[1]);
        x00[0] = x0[0];
        x00[1] = x0[1];
        x0[0] = x0[0] + T* a;
        x0[1] = x0[1] + T* b;

        /*cout << x0[0] - x00[0] << "--" << x0[1] - x00[1] << endl;*/
        if (Math.Abs(x0[0] - x00[0]) <= tolerans && Math.Abs(x0[1] - x00[1]) <= tolerans)
            break;

                grafik.SetPixel(i, Math.Abs((int)(x0[1] * 10) - (pictureBox1.Height - 1)), Color.Black);
                grafik.SetPixel(i, Math.Abs((int)(x0[0] * 10) - (pictureBox1.Height - 1)), Color.Red);
                //cout <<i<<"---" <<(int) (x0[0]*100) << "-----" << (int) (x0[1]*100)<<endl;
        }
            
            //for (int i = 0; i < 500; i++)
            //{
            //    grafik.SetPixel(i, 50, Color.Black);
            //}
            pictureBox1.Image = grafik;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double tend = Convert.ToInt32(textBox13.Text);
            double t0 = 0;
            double[,] A = new double[2, 2];
            A[0, 0] = Convert.ToDouble(textBox1.Text);
            A[0, 1] = Convert.ToDouble(textBox2.Text);
            A[1, 0] = Convert.ToDouble(textBox4.Text);
            A[1, 1] = Convert.ToDouble(textBox3.Text);
            double[] x0 = new double[2];
            x0[0] = Convert.ToDouble(textBox6.Text);
            x0[1] = Convert.ToDouble(textBox5.Text);
            double[,] B = new double[2, 2];
            B[0, 0] = Convert.ToDouble(textBox10.Text);
            B[0, 1] = Convert.ToDouble(textBox9.Text);
            B[1, 0] = Convert.ToDouble(textBox8.Text);
            B[1, 1] = Convert.ToDouble(textBox7.Text);
            double[] U = new double[2];
            U[0] = Convert.ToDouble(textBox14.Text);
            U[1] = Convert.ToDouble(textBox12.Text);
            double T = Convert.ToDouble(textBox11.Text);

            double[] x00 = new double[2];
            Bitmap grafik = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int k = 0; k < 600; k += 50)
                for (int i = 0; i < pictureBox1.Height; i++)
                {
                    grafik.SetPixel(k, i, Color.Gold);
                }

            for (int k = 0; k < pictureBox1.Height; k += 50)
                for (int i = 0; i < pictureBox1.Width; i++)
                {
                    grafik.SetPixel(i, k, Color.Gold);
                }
            for (int i = 0; i<600; i++)
            {
                double a1 = T * ((A[0, 0] * x0[0] + A[0, 1] * x0[1]) + (B[0, 0] * U[0] + B[0, 1] * U[1]));
                double a2 = T * ((A[1, 0] * x0[0] + A[1, 1] * x0[1]) + (B[1, 0] * U[0] + B[1, 1] * U[1]));
                x00[0] = x0[0];
                x00[1] = x0[1];
                x0[0] = x00[0] + a1 / 2;
                x0[1] = x00[1] + a2 / 2;
                double b1 = T * ((A[0, 0] * x0[0] + A[0, 1] * x0[1]) + (B[0, 0] * U[0] + B[0, 1] * U[1]));
                double b2 = T * ((A[1, 0] * x0[0] + A[1, 1] * x0[1]) + (B[1, 0] * U[0] + B[1, 1] * U[1]));

                x0[0] = x00[0] + b1 / 2;
                x0[1] = x00[1] + b2 / 2;
                double c1 = T * ((A[0, 0] * x0[0] + A[0, 1] * x0[1]) + (B[0, 0] * U[0] + B[0, 1] * U[1]));
                double c2 = T * ((A[1, 0] * x0[0] + A[1, 1] * x0[1]) + (B[1, 0] * U[0] + B[1, 1] * U[1]));

                x0[0] = x00[0] + c1;
                x0[1] = x00[1] + c2;
                double d1 = T * ((A[0, 0] * x0[0] + A[0, 1] * x0[1]) + (B[0, 0] * U[0] + B[0, 1] * U[1]));
                double d2 = T * ((A[1, 0] * x0[0] + A[1, 1] * x0[1]) + (B[1, 0] * U[0] + B[1, 1] * U[1]));

                x0[0] = x00[0] + (a1 + 2 * b1 + 2 * c1 + d1) / 6;
                x0[1] = x00[1] + (a2 + 2 * b2 + 2 * c2 + d2) / 6;

                if (t0 > tend)
                    break;
                else
                    t0 = t0 + T;

                if (Math.Abs((int)(x0[1] * 10) - (pictureBox1.Height - 1)) >= pictureBox1.Height || Math.Abs((int)(x0[0] * 10) - (pictureBox1.Height - 1)) >= pictureBox1.Height)
                    break;
                
                grafik.SetPixel(i, Math.Abs((int)(x0[1] * 10) - (pictureBox1.Height - 1)), Color.Black);
                grafik.SetPixel(i, Math.Abs((int)(x0[0] * 10) - (pictureBox1.Height - 1)), Color.Red);
                //cout <<i<<"---" <<(int) (x0[0]*100) << "-----" << (int) (x0[1]*100)<<endl;


                //for (int i = 0; i < 500; i++)
                //{
                //    grafik.SetPixel(i, 50, Color.Black);
                //}
                

            }
            pictureBox1.Image = grafik;
        }

    }
}
