using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LittleGames
{
    public partial class Wack_A_Mole : Form
    {
        public string beatname = Application.StartupPath + @"\打中.png";    //定义被打中后的图片文件存储位置
        public string molename = Application.StartupPath + @"\地鼠.png";    //定义地鼠的图片文件存储位置
        public beaten beat=new beaten() ;           //新定义一个字段，用于打地鼠及统计分数
        public Wack_A_Mole()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox1);       //地鼠1被打中
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox2);       //地鼠2被打中
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox6);       //地鼠3被打中
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox3);       //地鼠4被打中
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox4);       //地鼠5被打中
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox5);       //地鼠6被打中
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox7);       //地鼠7被打中
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox8);       //地鼠8被打中
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            beat.beatmole(pictureBox9);       //地鼠9被打中
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                timer1.Interval = 2000;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                timer1.Interval = 1000;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                timer1.Interval = 500;
            }
        }
        private void begin_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;                                        //点击开始游戏后，开始计时
            beat.score = 0;                                               //游戏开始时先清零分数
        }

        public int round = 1;                                             //定义回合数变量
        private void timer1_Tick(object sender, EventArgs e)
        {
            begin.Visible = false;                                       //游戏开始后隐藏开始按钮
            end.Visible = false;                                         //游戏开始后隐藏退出按钮
            groupBox1.Visible = false;
            playerscore.Visible = true;                                  //游戏开始后显示分数文本框
            playerscore.Text = ("您的分数为:" + beat.score);             //显示分数
            Random rd = new Random();
            int num = rd.Next(9);                                        //随机生成地鼠出现位置
            if (round <= 10)                                             //判断是否达到回合数
            {
                switch (num)                                             //地鼠先一起消失，被选中的地鼠再出现
                {
                    case 0: together(false ); pictureBox1.Visible = true; break;
                    case 1: together(false ); pictureBox2.Visible = true; break;
                    case 2: together(false ); pictureBox3.Visible = true; break;
                    case 3: together(false ); pictureBox4.Visible = true; break;
                    case 4: together(false ); pictureBox5.Visible = true; break;
                    case 5: together(false ); pictureBox6.Visible = true; break;
                    case 6: together(false ); pictureBox7.Visible = true; break;
                    case 7: together(false ); pictureBox8.Visible = true; break;
                    case 8: together(false ); pictureBox9.Visible = true; break;
                }
                round++;         //回合数加一
            }
            else     //若达到回合则游戏结束，一切清零
            {
                timer1.Enabled = false;
                together(true);
                MessageBox.Show("游戏结束");
                round = 1;
                begin.Visible = true;
                end.Visible = true;
                groupBox1.Visible = true;
                playerscore.Visible = false ;
            }
            
        }
        
        private void together(bool condition)   //让地鼠一起消失，并回到地鼠状态
        {
            pictureBox1.Visible = condition;
            pictureBox2.Visible = condition;
            pictureBox3.Visible = condition;
            pictureBox4.Visible = condition;
            pictureBox5.Visible = condition;
            pictureBox6.Visible = condition;
            pictureBox7.Visible = condition;
            pictureBox8.Visible = condition;
            pictureBox9.Visible = condition;
            pictureBox1.Image = Image.FromFile(molename);
            pictureBox2.Image = Image.FromFile(molename); 
            pictureBox3.Image = Image.FromFile(molename); 
            pictureBox4.Image = Image.FromFile(molename); 
            pictureBox5.Image = Image.FromFile(molename); 
            pictureBox6.Image = Image.FromFile(molename); 
            pictureBox7.Image = Image.FromFile(molename);
            pictureBox8.Image = Image.FromFile(molename);
            pictureBox9.Image = Image.FromFile(molename);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }              
    }

    public class beaten           //用于打地鼠及统计分数的类
    {
        public string beatname = Application.StartupPath + @"\打中.png";
        public string molename = Application.StartupPath + @"\地鼠.png";
        public int score=0;
        public void beatmole(PictureBox pictureboxbeaten)
        {
            if (pictureboxbeaten.Visible == true)
            {
                pictureboxbeaten.Image = Image.FromFile(beatname);
                score = score + 10;
            }
        }
    }
}
