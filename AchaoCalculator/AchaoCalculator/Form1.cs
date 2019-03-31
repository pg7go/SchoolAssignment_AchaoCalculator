using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AchaoCalculator
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroListView1.Items.Clear();
        }

        Random random = new Random();
        private void CreateQuestion()
        {
            int num1 = random.Next() % 100;
            int num2 = random.Next() % 100;
            int cal_type = random.Next() % 4;
            float result=0;
            string fx="";
            switch(cal_type)
            {
                case 0:
                    fx = "+";
                    result = num1 + num2;
                    break;
                case 1:
                    fx = "-";
                    result = num1 - num2;
                    break;
                case 2:
                    fx = "×";
                    result = num1 * num2;
                    break;
                case 3:
                    fx = "÷";
                    result = num1 * num2;
                    ListViewItem item2 = new ListViewItem();
                    item2.Text = result.ToString() + " " + fx + " " + num2.ToString() + " = ";
                    item2.SubItems.Add(num1.ToString());
                    metroListView1.Items.Add(item2);
                    return;
            }
            ListViewItem item = new ListViewItem();
            item.Text = num1.ToString() + " " + fx + " " + num2.ToString()+" = ";
            item.SubItems.Add(result.ToString());
            metroListView1.Items.Add(item);
        }


        private void metroTextBox1_ButtonClick(object sender, EventArgs e)
        {
            string text = metroTextBox1.Text;
            if(int.TryParse(text,out int num))
            {
                metroListView1.Items.Clear();
                for (int i = 0; i < num; i++)
                {
                    CreateQuestion();
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,"请输入正确的数字！","错误提示：",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
