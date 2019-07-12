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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
namespace AppBiz
{
    public partial class Message : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zR1XLA7t6MqYvc2QZLBP0uFcmqVY9jWnwvkhOsbn",
            BasePath = "https://database-98ed4.firebaseio.com/"
        };
        IFirebaseClient client;
        public Message()
        {
           
            InitializeComponent();
        }

        private void Message_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            label3.Text = DateTime.Now.ToLongDateString();
            label4.Text= DateTime.Now.ToShortTimeString();
            StreamReader sr = new StreamReader("CompanyIdfile.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                comboBox1.Items.Add(line);
            }
            sr.Close();
        }
       

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var Messdbcs = new Messdbcs
            {
                companyId = comboBox1.Text,
                Message = richTextBox1.Text,
                Date = label3.Text,
                Time=label4.Text
            };
            if (comboBox1.Enabled == true)
            {
                try
                {
                    SetResponse response = await client.SetTaskAsync("Message/" + comboBox1.Text, Messdbcs);
                    Messdbcs result = response.ResultAs<Messdbcs>();
                    MessageBox.Show("Message Send Successfully");
                }
                catch
                {
                    MessageBox.Show("Check your internet connection");
                }
            }
            else if(comboBox1.Enabled == false)
            {
                int flag = 0;
                StreamReader sr = new StreamReader("CompanyIdfile.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        Messdbcs.companyId = line;
                        SetResponse response = await client.SetTaskAsync("Message/" + line, Messdbcs);
                        Messdbcs result = response.ResultAs<Messdbcs>();
                    }
                    catch
                    {
                        flag = 1;
                        MessageBox.Show("Check your internet connection");
                        break;
                    }
                }
                sr.Close();

                if (flag != 1) {
                    MessageBox.Show("Message Send Successfully");
                    flag = 0;
                }

            }
        }
    }
}
