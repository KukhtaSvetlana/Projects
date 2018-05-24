using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace Web_lab8
{

    public partial class Form1 : Form
    {
        IWebDriver Brauser;
        IWebElement webElement;
        Dictionary<string, string> countries = new Dictionary<string, string>(5);

        public Form1()
        {
            InitializeComponent();
        }
        public void CeckKapcha()
        {
            while (true)
            {
                if (Brauser.FindElements(By.ClassName("box_layout")).Count == 0 &&
                    Brauser.FindElements(By.Id("")).Count == 0)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Brauser = new OpenQA.Selenium.Chrome.ChromeDriver();
            Brauser.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(5000);
            Brauser.Navigate().GoToUrl("http://google.com");
            webElement = Brauser.FindElement(By.Id("lst-ib"));
            System.Threading.Thread.Sleep(5000);
            webElement.SendKeys("vk.com" + OpenQA.Selenium.Keys.Enter);
            webElement = Brauser.FindElement(By.LinkText("ВКонтакте: Добро пожаловать"));
            webElement.Click();
            System.Threading.Thread.SpinWait(6000);
            webElement = Brauser.FindElement(By.Id("index_email"));
            CeckKapcha();
            webElement.SendKeys("380665846760" + OpenQA.Selenium.Keys.Enter);
            CeckKapcha();
            webElement = Brauser.FindElement(By.Id("index_pass"));
            System.Threading.Thread.Sleep(6000);
            CeckKapcha();
            webElement.SendKeys("1q2w3e4r5tAZ" + OpenQA.Selenium.Keys.Enter);
            CeckKapcha();
            System.Threading.Thread.Sleep(1000);
           // webElement = Brauser.FindElement(By.Id("index_login_button"));
            CeckKapcha();
           // webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
            CeckKapcha();
            System.Threading.Thread.Sleep(8000);
            CeckKapcha();
            webElement = Brauser.FindElement(By.CssSelector("#l_gr a"));
            webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
            System.Threading.Thread.Sleep(8000);
            webElement = Brauser.FindElement(By.CssSelector("#groups_list_search"));
            webElement.SendKeys("Донецк" + OpenQA.Selenium.Keys.Enter);
            System.Threading.Thread.Sleep(8000);
            List<IWebElement> News = Brauser.FindElements(By.CssSelector("a.group_row_title")).ToList();//#feed_wall .wall_text  a
            List<string> ff = new List<string>();
            for (int i = 0; i < News.Count; i++)
            {
                 textBox1.AppendText(News[i].Text + "\n");
                 ff.Add(News[i].Text + "\n");
            }
            File.Delete(@"D:\Laboratory_works\Group.txt");
            FileInfo file = new FileInfo(@"D:\Laboratory_works\Group.txt");
            StreamWriter sr = file.CreateText();
            sr.Close();
            WriteFile file2 = new WriteFile();
            string path = @"D:\Laboratory_works\Group.txt";
            file2.Write(ff, path);
            MessageBox.Show("Группы записаны");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            webElement = Brauser.FindElement(By.CssSelector("#l_aud a"));
            webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
            System.Threading.Thread.Sleep(8000);
            List<IWebElement> News1 = Brauser.FindElements(By.CssSelector("div.audio_row__performer_title")).ToList();//#feed_wall .wall_text  a
            List<string> ff = new List<string>();
            for (int i = 0; i < News1.Count; i++)
            {
                textBox1.AppendText(News1[i].Text + "\n");
                ff.Add(News1[i].Text + "\n");
            }
            File.Delete(@"D:\Laboratory_works\Музыка.txt");
            FileInfo file = new FileInfo(@"D:\Laboratory_works\Музыка.txt");
            StreamWriter sr = file.CreateText();
            sr.Close();
            WriteFile file2 = new WriteFile();
            string path = @"D:\Laboratory_works\Музыка.txt";
            file2.Write(ff, path);
            MessageBox.Show("Музыка записаны");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webElement = Brauser.FindElement(By.CssSelector("#l_msg a"));
            webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
            System.Threading.Thread.Sleep(3000);
            webElement = Brauser.FindElement(By.ClassName("_im_dialog_322266324"));
            IWebElement Sms = Brauser.FindElement(By.ClassName("_im_dialog_322266324"));
            string nn = Sms.Text.Remove(0,23);
            System.Threading.Thread.Sleep(1000);
            webElement = Brauser.FindElement(By.ClassName("_im_dialog_322266324"));
            webElement.Click();
            System.Threading.Thread.Sleep(2000);
            string text;
            using (StreamReader sr = new StreamReader(@"C:\Users\kuxta\source\repos\Web-lab8\Фразы.txt", System.Text.Encoding.Default))
            {
                text = sr.ReadToEnd();
            }
            string ss =  text.Replace("\r","");
            string[] words = ss.Split(new char[] { '-', '\n' });
            
            for (int i = 0; i < words.Length-1; i++)
            {
                countries.Add(words[i], words[++i]);
            }
            foreach (var pair in countries)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            if (countries.ContainsKey(nn))
            {
                webElement = Brauser.FindElement(By.Id("im_editable0"));
                webElement.SendKeys(countries[nn] + OpenQA.Selenium.Keys.Enter);
            }
            else
            {
                MessageBox.Show("Ключ не найден");   
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }
    }
}
