using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarkVSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Services;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using System.Data.SqlClient;

namespace кур
{
    public partial class MainForm : Form
    {
        IWebDriver Brauser;
        IWebElement webElement;
        static int i = 0;
       
        public MainForm()
        {
            InitializeComponent();
            
        }

        public void CeckKapcha()
        {
            while (true)
            {
                if (Brauser.FindElements(By.ClassName("box_layout")).Count == 0 &&
                    Brauser.FindElements(By.Id("recaptcha")).Count == 0)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
        }
        private string FindWindow(String Url)
        {
            String StartWindow = Brauser.CurrentWindowHandle;
            String Result = "";

            for (int i = 0; i < Brauser.WindowHandles.Count; i++)
            {
                if (Brauser.WindowHandles[i] != StartWindow)
                {
                    Brauser.SwitchTo().Window(Brauser.WindowHandles[i]);
                    if (Brauser.Url.Contains(Url))
                    {
                        Result = Brauser.WindowHandles[i];
                        break;
                    }
                }
            }


            //Brauser.SwitchTo().Window(StartWindow);
            return Result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChromeOptions option = new ChromeOptions();
            //option.AddArguments("--proxy-server=http://localhost:9150");//поменять порт
            option.AddArguments("--incognito");
            Brauser = new OpenQA.Selenium.Chrome.ChromeDriver(option);
            Brauser.Manage().Window.Maximize();
            Brauser.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(1000);
            Brauser.Navigate().GoToUrl("http://google.com");
            CeckKapcha();
            webElement = Brauser.FindElement(By.Id("lst-ib")); ///страх и ненавить в ласвегасе //поисковая строка 
            Search_By_Words();
            GoogleLink();
            //for (int i = 0; i < listBox1.Items.Count; i++) // поиск по ключевым словам 
            //{
            //    webElement.SendKeys(listBox1.Items[i].ToString() + OpenQA.Selenium.Keys.Enter); //вводим слово
            //    FormListLinlGoogle();

            //}

            // webElement = Brauser.FindElement(By.LinkText("ВКонтакте: Добро пожаловать"));Натяжные потолки Okeypotolo

        }
        private void Search_By_Words()
        {
                if( i < listBox1.Items.Count)
                {
                    webElement.SendKeys(listBox1.Items[i].ToString() + OpenQA.Selenium.Keys.Enter); //вводим слово в google
                    FormListLinlGoogle();
                }
                else
                {
                    MessageBox.Show("Все слова использованы");
                }  
        }
         private void FormListLinlGoogle()
         {
            List<IWebElement> News = Brauser.FindElements(By.CssSelector("div.f.hJND5c")).ToList();//#feed_wall .wall_text  a все ссылки на первой странице
            while (SearchMyLink(News)==false)
            {
                webElement = Brauser.FindElement(By.CssSelector("td a"));
                FormListLinlGoogle();
            }
         }
         private bool SearchMyLink(List<IWebElement> News)
         {
            string st = textBox3.Text.Remove(0, 7);
            for (int j = 0; j < News.Count; j++)
            {
                if (st == News[j].Text)
                {
                     OpenLink(News[j]);
                    return true;  //https://www.reg.ru/whois/check_site?site=okeypotolok.su&_csrf=c64e12bf40526ec243f993965b61cade
                }
            }
            return false;
         }
         private void OpenLink(IWebElement News)
         {
            webElement = Brauser.FindElement(By.LinkText("Натяжные потолки Okeypotolok"));
            webElement.SendKeys(OpenQA.Selenium.Keys.Control + OpenQA.Selenium.Keys.Return);
            String HabrWindow = FindWindow(textBox2.Text);
            i++;
            Search_By_Words();
        }
        private void GoogleLink()
        {
            webElement = Brauser.FindElement(By.LinkText("google"));
            webElement.SendKeys(OpenQA.Selenium.Keys.Control + OpenQA.Selenium.Keys.Return);
            String HabrWindow = FindWindow(textBox2.Text);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Brauser.Quit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<IWebElement> News = Brauser.FindElements( By.CssSelector("div .wall_post_text ") ).ToList();//#feed_wall .wall_text  a
            for (int i = 0; i < News.Count; i++)
            {
                textBox1.AppendText(News[i].Text + "\n");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Process myProcess = new Process();  
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
              
                myProcess.StartInfo.FileName = @"C:\Users\kuxta\OneDrive\Рабочий стол\Tor Browser\Browser\TorBrowser\Tor\tor.exe";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.Arguments = "-f C:\\Users\\kuxta\\OneDrive\\Рабочий стол\\Tor Browser\\Browser\\TorBrowser\\Tor\\torrc";
                myProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChromeOptions option = new ChromeOptions();
            //option.AddArguments("--proxy-server=http://localhost:9150");//поменять порт
            option.AddArguments("--incognito");
            Brauser = new OpenQA.Selenium.Chrome.ChromeDriver(option);
            Brauser.Manage().Window.Maximize();
            Brauser.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(1000);
            Brauser.Navigate().GoToUrl("http://google.com");
           // CeckKapcha();
            webElement = Brauser.FindElement(By.CssSelector("a#fsettl.Fx4vi "));
            webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
            webElement = Brauser.FindElement(By.LinkText("Настройки поиска"));
            webElement.Click(); //div.goog - slider - thumb
            webElement = Brauser.FindElement(By.CssSelector("div.goog-slider-thumb"));
            webElement = Brauser.FindElement(By.CssSelector("div#slruler.rulerResnum"));
            webElement = Brauser.FindElement(By.CssSelector("div.slmarker"));
            webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
            //webElement.Click();
            //webElement.Click();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Collection urlCrawler = new Collection(textBox3.Text);
            Task.Run(() => urlCrawler.execute());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GeneratorFacade gen;
            gen = new GeneratorFacade(new MarkovGenerator(System.IO.File.ReadAllText("markov_data/data[okeypotolok.su].txt")));
            Console.WriteLine(gen.GenerateParagraphs(20));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add( textBox4.Text);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ChromeOptions option = new ChromeOptions();
            //option.AddArguments("--proxy-server=http://localhost:9150");//поменять порт
            option.AddArguments("--incognito");
            Brauser = new OpenQA.Selenium.Chrome.ChromeDriver(option);
            Brauser.Manage().Window.Maximize();
            Brauser.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(1000);
            Brauser.Navigate().GoToUrl("https://www.reg.ru/whois/");
            CeckKapcha();
            webElement = Brauser.FindElement(By.CssSelector(".qa-whois-dname")); ///страх и ненавить в ласвегасе //поисковая строка 
            string st = textBox3.Text.Remove(0, 7);
           string domin = "", administrator = "", dataregistrashion = "", dataOkonchaniaRegistration = "";
            if (st != "")
            {
                webElement.SendKeys(st + OpenQA.Selenium.Keys.Enter);
                webElement = Brauser.FindElement(By.CssSelector(".qa-whois-check_dom"));
                webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
                List<IWebElement> News1 = Brauser.FindElements(By.CssSelector("td.b-table__cell_white-space_normal.b-table__cell_node_last")).ToList();//#feed_wall .wall_text  a
                for (int i = 0; i < News1.Count; i++)
                {
                    textBox1.AppendText(News1[i].Text + "\n");

                }
                domin = News1[0].Text;
                administrator = News1[4].Text;
                dataregistrashion = News1[8].Text;
                       dataOkonchaniaRegistration = News1[9].Text;
            }
            else
            {
                MessageBox.Show("Вы забыли ввести название сайта");
            }

                
                System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=DESKTOP-L7KO0GA\\SQLEXPRESS;Initial Catalog=Sait_Position;Integrated Security=True");
                sqlConnection1.Open();
               
                //cmd.CommandType = System.Data.CommandType.Text;
                string sql = "INSERT Сайт(Домен, Название, Сайт.Админнистратор, ДатаРегистрацииСайта, ДатаОкончанияРегистрации) VALUES (" + "'" + domin+"'" + ","+"'"+ st+"'"+","+"'" + administrator+"'" +","+"'"+dataregistrashion+"'" +","+"'"+ dataOkonchaniaRegistration+"'"+")";
                string sql1 = "INSERT Сайт(Домен, Название, Сайт.Админнистратор, ДатаРегистрацииСайта, ДатаОкончанияРегистрации) VALUES ('domin' ,'st', 'administrator', '2017-08-25',  '2017-08-25')";
                SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql,sqlConnection1);
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
            Brauser.Quit();
            MessageBox.Show("Информация получена");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ChromeOptions option = new ChromeOptions();
            //option.AddArguments("--proxy-server=http://localhost:9150");//поменять порт
            option.AddArguments("--incognito");
            Brauser = new OpenQA.Selenium.Chrome.ChromeDriver(option);
            Brauser.Manage().Window.Maximize();
            Brauser.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(1000);
            Brauser.Navigate().GoToUrl("https://seovisia.com/seo_check.php?lg=ru");
            CeckKapcha();
             ///страх и ненавить в ласвегасе //поисковая строка 
            //string st = textBox3.Text.Remove(0, 7);
            //string domin = "", administrator = "", dataregistrashion = "", dataOkonchaniaRegistration = "";
            if (textBox3.Text != "")
            {
                webElement = Brauser.FindElement(By.CssSelector("input[name=url"+"]"));
                webElement.SendKeys(textBox3.Text);
                webElement = Brauser.FindElement(By.CssSelector("input[name=keywords" + "]"));
                webElement.SendKeys(listBox1.Items[i].ToString() );
                webElement = Brauser.FindElement(By.CssSelector(".button"));
                webElement.SendKeys(OpenQA.Selenium.Keys.Enter); //td b
                webElement = Brauser.FindElement(By.TagName("td b"));
                List<IWebElement> News1 = Brauser.FindElements(By.CssSelector("td.b-table__cell_white-space_normal.b-table__cell_node_last")).ToList();//#feed_wall .wall_text  a
                for (int i = 0; i < News1.Count; i++)
                {
                    textBox1.AppendText(News1[i].Text + "\n");

                }
                //domin = News1[0].Text;
                //administrator = News1[4].Text;
                //dataregistrashion = News1[8].Text;
                //dataOkonchaniaRegistration = News1[9].Text;
            }
            else
            {
                MessageBox.Show("Вы забыли ввести название сайта");
            }


            //System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection("Data Source=DESKTOP-L7KO0GA\\SQLEXPRESS;Initial Catalog=Sait_Position;Integrated Security=True");
            //sqlConnection1.Open();

            ////cmd.CommandType = System.Data.CommandType.Text;
            //string sql = "INSERT Сайт(Домен, Название, Сайт.Админнистратор, ДатаРегистрацииСайта, ДатаОкончанияРегистрации) VALUES (" + "'" + domin + "'" + "," + "'" + st + "'" + "," + "'" + administrator + "'" + "," + "'" + dataregistrashion + "'" + "," + "'" + dataOkonchaniaRegistration + "'" + ")";
            //string sql1 = "INSERT Сайт(Домен, Название, Сайт.Админнистратор, ДатаРегистрацииСайта, ДатаОкончанияРегистрации) VALUES ('domin' ,'st', 'administrator', '2017-08-25',  '2017-08-25')";
            //SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, sqlConnection1);
            //cmd.ExecuteNonQuery();
            //sqlConnection1.Close();
            //Brauser.Quit();
            //MessageBox.Show("Информация получена");
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("KYKY5");
        }
    }  
    }

