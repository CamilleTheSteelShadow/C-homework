using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public int N { get; set; }                     // 递归深度
        public double Th1 { get; set; }                // 右分支角度
        public double Th2 { get; set; }                // 左分支角度
        public double Per1 { get; set; }               // 右分支长度
        public double Per2 { get; set; }               // 左分支长度
        public double Length { get; set; }             // 树枝长度
        public double BifurcateFactor { get; set; }    //两棵子树分叉的因子

        public bool isRandom { get; set; }             //是否随机产生参数

        private Graphics graphics;
        private Pen pen;
        private Random rd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*默认值*/
            N = 12;
            Th1 = Math.Round(30 * Math.PI / 180, 2);
            Th2 = Math.Round(20 * Math.PI / 180, 2);
            Per1 = 0.7;
            Per2 = 0.8;
            Length = 100;
            BifurcateFactor = 1;
            isRandom = false;

            /*Data Binding*/
            txtBoxN.DataBindings.Add("Text", this, "N");
            txtBoxTh1.DataBindings.Add("Text", this, "Th1");
            txtBoxTh2.DataBindings.Add("Text", this, "Th2");
            txtBoxPer1.DataBindings.Add("Text", this, "Per1");
            txtBoxPer2.DataBindings.Add("Text", this, "Per2");
            txtBoxLengh.DataBindings.Add("Text", this, "Length");
            txtBoxBifurcate.DataBindings.Add("Text", this, "BifurcateFactor");

            checkBoxRd.DataBindings.Add("Checked", this, "isRandom");

            graphics = this.drawPanel.CreateGraphics();
            pen = new Pen(Color.Cyan);
            pen.Width += 1;
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            if(isRandom)
            {
                GetRandomProperty();
            }

            txtBoxPer1.Invalidate();

            graphics.Clear(Color.White);

            DrawCayleyTree(N, drawPanel.Width / 2, drawPanel.Height - 10, Length, -Math.PI / 2);
        }

        private void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if(n==0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            double x2 = x0 + leng * BifurcateFactor * Math.Cos(th);
            double y2 = y0 + leng * BifurcateFactor * Math.Sin(th);

            DrawLine(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, Per1 * leng, th + Th1);
            DrawCayleyTree(n - 1, x2, y2, Per2 * leng, th - Th2);
        }

        private void DrawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void GetRandomProperty()
        {
            double tmp1, tmp2;
            do
            {
                tmp1 = rd.Next(15, 60);
                tmp2 = rd.Next(15, 60);
            } while (Math.Abs(Th1 - Th2) > 25 && Math.Abs(Th1 - Th2) < 35);

            Th1 = Math.Round(tmp1 * Math.PI / 180, 2);
            Th2 = Math.Round(tmp2 * Math.PI / 180, 2);

            txtBoxTh1.Text = Th1.ToString();
            txtBoxTh2.Text = Th2.ToString();

            do
            {
                Per1 = 0.6 + rd.NextDouble() / 8;
                Per2 = 0.6 + rd.NextDouble() / 8;
            } while (Math.Abs(Per1 - Per2) < 0.1);

            Length = rd.Next(90, 150);
            txtBoxLengh.Text = Length.ToString();

            BifurcateFactor = Math.Round(0.8 + rd.NextDouble() / 8, 2);
            txtBoxBifurcate.Text = BifurcateFactor.ToString();
        }

        private void DrawPanelResized(object sender, EventArgs e)
        {
            if (graphics == null) return;       // 避免在生成窗体时出问题

            graphics.Dispose();
            graphics = this.drawPanel.CreateGraphics();     // Panel大小变化后，graphic的绘制大小不会自动随之变化，所以重新获取一次

            this.DrawButton_Click(sender, e);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            dialogColor.ShowDialog();
            pen.Color = dialogColor.Color;
            btnColor.BackColor = dialogColor.Color;
        }
    }
}
