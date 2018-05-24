using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringFormat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringSafe str = new StringSafe();
            string s = str.WebString(textBox1.Text);
            MessageBox.Show(s);
            //string s = str.SaveString(textBox1.Text);
            //  MessageBox.Show(s);
        }
    }
}
