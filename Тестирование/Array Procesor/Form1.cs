using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Array_Procesor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int c = int.Parse(textBox1.Text);
            //string[] sNums = textBox2.Text.Split(' ');
            //if (c > sNums.Length)
            //{
            //    MessageBox.Show("Длина массива не соответсвует введенному!");
            //    return;
            //}
            //int[] nums = new int[c];
            //for (int i = 0; i < c; i++)
            //{
            //    nums[i] = int.Parse(sNums[i]);
            //}

            int[] X = { -8, -5, -2, 10, 11, 45 };
            ArrayProcessor array = new ArrayProcessor();
            array.SortAndFilter(X);
            //for (int i = 0; i < array.SortAndFilter(nums).Length; i++)
            //{
            //    label2.Text += array.SortAndFilter(nums)[i].ToString() + " ";
            //}
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
