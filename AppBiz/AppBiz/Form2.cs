using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Text.RegularExpressions;
using System.IO;

namespace AppBiz
{
    public partial class Form2 : Form
    {
        Message m2=new Message();
        public string se;

        public int flag=0;
        public string lim;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "zR1XLA7t6MqYvc2QZLBP0uFcmqVY9jWnwvkhOsbn",
            BasePath = "https://database-98ed4.firebaseio.com/"
        };
        IFirebaseClient client;


        public Form2()
        {
           
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel5.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            detail.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventsPanel.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Close();
        }



        private async void Form2_Load(object sender, EventArgs e)
        {
           


            maskedTextBox5.Enabled = false;
            timer1.Start();
            label21.Text = DateTime.Now.ToLongDateString();
            label22.Text = DateTime.Now.ToLongTimeString();
            client = new FireSharp.FirebaseClient(config);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy     hh:mm:ss";
          
            
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button6_Click(object sender, EventArgs e)
        {
             comboBox5.Text = dateTimePicker1.Value.ToString();
            var eventData = new EventData
            {
                EN = textBox8.Text,
                Loc = comboBox2.Text,
                Or = textBox9.Text,
                Min = maskedTextBox5.Text,
                res = comboBox3.Text,
                cat = comboBox4.Text,
                dT = comboBox5.Text,
                mes = textBox11.Text,
                email = textBox12.Text,
                ph = textBox13.Text,
                li = lim
            };
           

            if (label23.Text == "Valid" && label24.Text == "Valid") {
                try
                {


                    SetResponse response = await client.SetTaskAsync("Event/" + textBox8.Text, eventData);
                    EventData result = response.ResultAs<EventData>();
                    MessageBox.Show("Data Inserted" + result);
                }
                catch
                {
                    MessageBox.Show("Check your internet connection");
                }
                }
            else
            {
                MessageBox.Show("Validate your details");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           maskedTextBox5.Enabled = true;
            lim = "Limited";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            maskedTextBox5.Enabled = false;
            lim = "Unlimited";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void detail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label22.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void Regexp(string re, TextBox tb,Label lb,string s)
        {
            Regex regex = new Regex(re);
            if (regex.IsMatch(tb.Text))
            {
                lb.ForeColor = Color.Green;
                lb.Text = s + "Valid";

            }
            else
            {
                lb.ForeColor = Color.Red;
                lb.Text = s + "Invalid";
            }
        }

        public void Regxp(string re, TextBox tb, Label lb, string s)
        {
            Regex reg2= new Regex(re);
            if (reg2.IsMatch(tb.Text))
            {
                lb.ForeColor = Color.Green;
                lb.Text = s + "";

            }
            else
            {
                lb.ForeColor = Color.Red;
                lb.Text = s + "Invalid";
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", textBox12, label23, "");
        }

    
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$", textBox13, label24, "");


        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
          
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            
           
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
                textBox7.Enabled = false;
                textBox6.Enabled = false;
                textBox15.Enabled = false;
                textBox14.Enabled = false;
                maskedTextBox2.Enabled = false;
                maskedTextBox3.Enabled = false;
            if(checkBox1.Checked == false)
            {

                textBox7.Enabled = true;
                textBox6.Enabled = true;
                textBox15.Enabled = true;
                textBox14.Enabled = true;
                maskedTextBox2.Enabled = true;
                maskedTextBox3.Enabled = true;
            }
           
           
    }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Regexp(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", textBox6, label30, "");
        }

        private async void Insert_Click(object sender, EventArgs e)
        {
            var Employees = new Employees
            {
                companyId = maskedTextBox1.Text,
                department =textBox5.Text,
                designation =comboBox6.Text,
                email =textBox6.Text,
                fullname =textBox2.Text,
                password =textBox4.Text,
                phone =maskedTextBox2.Text,
                address =textBox7.Text,
                Hiredate =maskedTextBox4.Text,
                birthdate =maskedTextBox3.Text,
                city =textBox14.Text,
                country =textBox15.Text
            };
            se = maskedTextBox1.Text;
            m2.comboBox1.Items.Add(se);
            m2.comboBox1.GetItemText(se);
            try
            {
                SetResponse response2 = await client.SetTaskAsync("Employees/" + maskedTextBox1.Text, Employees);
                Employees result = response2.ResultAs<Employees>();
                MessageBox.Show("Data Inserted" + result);
             
            }
            catch
            {
                flag = 1;
                MessageBox.Show("Check your internet connection");
            }
            if (flag == 0)
            {
                StreamWriter sw = new StreamWriter("CompanyIdfile.txt", true);
                sw.WriteLine(maskedTextBox1.Text);
                sw.Close();
            }
            else
            {
                flag = 0;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            m2 = new Message();
            m2.Show();

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
