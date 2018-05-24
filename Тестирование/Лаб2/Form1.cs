using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб2
{
    public partial class Form1 : Form
    {
         ReportViwer viwer;
        public Form1()
        {
            InitializeComponent();
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportViwer viwer = new ReportViwer(new FileService());
            viwer.PrepareDate(textBox1.Text);
        }
    }
}
