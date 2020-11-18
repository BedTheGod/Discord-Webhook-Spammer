using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webhook_Spammer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            
            try 
            {
              string link=  new WebClient().DownloadString(textBox1.Text);
                if (link.Contains("channel_id"))
                {
                    goto ID1;
                }
                else
                {
                    return;
                }
            }
           catch
            {
                MessageBox.Show("Invalid webhook link. The webhook my no longer be active.");
            }

            ID1:
            label4.Text = "Working...";
            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
            {
                DiscordLog(textBox1.Text, richTextBox1.Text);
                label4.Text = "Sent Messages: " + i.ToString();
            }
            label4.Text = "Successful!";


        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*().,;:0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        string picture = "https://i.imgur.com/6leptM3.jpg";
        public void DiscordLog(string webhook,string message)
        {
            string botName = "lol get spammed";
            if (checkBox1.Checked == true)
            {
                botName = RandomString(random.Next(5,20));
            }
            


           
            try
            {
                _ = Http.Post(webhook, new NameValueCollection()
                {
                {
                    "username",
                     botName
                },
                {
                    "avatar_url",
                    picture
                },
                {
                    "content",
                    message
                },
            });
            }
            catch
            {
              
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
